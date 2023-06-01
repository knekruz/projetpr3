using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApplicationMobile.ViewModels
{
    public class QRCodePageViewModel : ObservableRecipient
    {
        private string _qrCodeValue;
        private string _scannedQRCodeText;

        public QRCodePageViewModel()
        {
            GenerateQRCodeCommand = new AsyncRelayCommand(GenerateQRCode);
        }

        public IAsyncRelayCommand GenerateQRCodeCommand { get; }

        public string QRCodeValue
        {
            get => _qrCodeValue;
            set => SetProperty(ref _qrCodeValue, value);
        }

        public string ScannedQRCodeText
        {
            get => _scannedQRCodeText;
            set => SetProperty(ref _scannedQRCodeText, value);
        }

        private Task GenerateQRCode()
        {
            // Generate a random string
            var randomString = Guid.NewGuid().ToString();

            // Update the QRCodeValue, which will trigger the UI to update
            QRCodeValue = randomString;

            return Task.CompletedTask;
        }
    }
}
