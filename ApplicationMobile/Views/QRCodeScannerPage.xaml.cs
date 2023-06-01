using ApplicationMobile.Services;
using ApplicationMobile.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ApplicationMobile.Views
{
    public partial class QRCodeScannerPage : ContentPage, INotifyPropertyChanged
    {
        private UserService _userService;
        private string _scannedQRCode;
        private string _qRCodeJSON;
        private Student _currentStudent;

        // NotifyPropertyChanged for ScannedQRCode
        public event PropertyChangedEventHandler PropertyChanged;
        public string ScannedQRCode
        {
            get => _scannedQRCode;
            set
            {
                _scannedQRCode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScannedQRCode)));
            }
        }

        // NotifyPropertyChanged for QRCodeJSON
        public string QRCodeJSON
        {
            get => _qRCodeJSON;
            set
            {
                _qRCodeJSON = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QRCodeJSON)));
            }
        }

        public QRCodeScannerPage()
        {
            InitializeComponent();
            _userService = DependencyService.Get<UserService>();
            barcodeReader.BarcodesDetected += CameraBarcodeReaderView_BarcodesDetected;
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _currentStudent = await _userService.GetStudentAsync();

            // Handle a potential null reference here
            if (_currentStudent == null)
            {
                // Log an error, display a message, or handle this scenario appropriately.
            }
        }

        private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            Dispatcher.Dispatch(() =>
            {
                // Check if barcodes were detected
                if (e.Results != null && e.Results.Count() > 0)
                {
                    ScannedQRCode = e.Results[0].Value;

                    // Create a new object with the barcode value (timestamp) and studentId
                    var data = new
                    {
                        timestamp = ScannedQRCode,
                        studentId = _currentStudent.Id  // assuming that your Student model has an Id property
                    };

                    // Convert the object to JSON
                    QRCodeJSON = JsonConvert.SerializeObject(data);

                    // Display the JSON in the label
                    barcodeResult.Text = QRCodeJSON;

                    // Update the ScannedQRCodeImage with the JSON
                    ScannedQRCodeImage.Value = QRCodeJSON;
                }
            });
        }
    }
}
