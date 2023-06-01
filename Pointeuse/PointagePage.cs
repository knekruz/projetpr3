using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using QRCoder;
using ZXing;
using Pointeuse.Service;
using Pointeuse.Models;

namespace Pointeuse
{
    public partial class PointagePage : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        private const string Key = "abcdefghijklmnopqrstuvwxzy012345";
        private readonly ApiService _apiService;

        public PointagePage()
        {
            InitializeComponent();
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            _apiService = new ApiService();
        }

        public class QrCodeResult
        {
            public string timestamp { get; set; }
            public int studentId { get; set; }
        }

        private string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                    }

                    array = memoryStream.ToArray();
                }
            }

            return Convert.ToBase64String(array);
        }

        private string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private void btnQrcode_Click(object sender, EventArgs e)
        {
            var timestamp = DateTime.Now.ToString();
            var encryptedTimestamp = EncryptString(timestamp);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(encryptedTimestamp, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            int qrCodeSize = Math.Min(pbQrcode.Width, pbQrcode.Height);
            Bitmap qrCodeImage = qrCode.GetGraphic(qrCodeSize / 20);
            Bitmap resizedImage = new Bitmap(qrCodeImage, new Size(pbQrcode.Width, pbQrcode.Height));

            pbQrcode.SizeMode = PictureBoxSizeMode.StretchImage;
            pbQrcode.Image = resizedImage;
        }

        private void btnQrcodeScan_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[0].MonikerString);
            FinalFrame.NewFrame += FinalFrame_NewFrame;
            FinalFrame.Start();
            timer1.Start();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox2.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private async void timer1_Tick(object sender, EventArgs e)  // Make the method async
        {
            if (pictureBox2.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox2.Image);

                if (result != null)
                {
                    // Parse the result as a JSON object.
                    QrCodeResult qrResult = Newtonsoft.Json.JsonConvert.DeserializeObject<QrCodeResult>(result.ToString());

                    try
                    {
                        string decryptedTimestamp = DecryptString(qrResult.timestamp);
                        label1.Text = decryptedTimestamp; // Display the decrypted timestamp in label1.
                        label2.Text = qrResult.studentId.ToString(); // Display the student ID in label2.

                        // Create a new pointage with the scanned data
                        var pointage = new Pointage
                        {
                            TimestampPointage = DateTime.Parse(decryptedTimestamp),
                            StudentId = qrResult.studentId
                        };

                        // Post the pointage to your API
                        var success = await _apiService.PostPointageAsync(pointage);
                        if (!success)
                        {
                            MessageBox.Show("Failed to post the pointage data.");
                        }
                    }
                    catch (Exception)
                    {
                        label1.Text = "Failed to decrypt the timestamp.";
                    }

                    timer1.Stop();

                    if (FinalFrame.IsRunning == true)
                    {
                        FinalFrame.Stop();
                    }
                }
            }
        }

        private void PointagePage_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
            }
        }
    }
}
