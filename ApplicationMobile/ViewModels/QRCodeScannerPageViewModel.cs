using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace ApplicationMobile.ViewModels
{
    public class QRCodeScannerPageViewModel : ObservableRecipient
    {
        public QRCodeScannerPageViewModel()
        {
            ScanQRCodeCommand = new AsyncRelayCommand(ScanQRCode);
        }

        public IAsyncRelayCommand ScanQRCodeCommand { get; }

        private async Task ScanQRCode()
        {
            // Call a method to scan a QR code, this will vary based on the library you're using to scan QR codes.
            // var result = await ScanQRCodeAsync();

            // Handle the result of the scan.

            // To Do: Implement QR code scanning.
        }
    }
}
