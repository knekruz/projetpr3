using Microsoft.Maui.Controls;
using ApplicationMobile.ViewModels;
using Newtonsoft.Json;

namespace ApplicationMobile.Views
{
    public partial class QRCodePage : ContentPage
    {
        QRCodePageViewModel _viewModel;

        public QRCodePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new QRCodePageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Listen for the "UpdateScannedQRCodeText" message
            MessagingCenter.Subscribe<QRCodeScannerPage, string>(this, "UpdateScannedQRCodeText", (sender, scannedQRCode) =>
            {
                // Update the scanned QR code text
                _viewModel.ScannedQRCodeText = scannedQRCode;

                // Update the labelQRvalue with the scanned QR code value
                labelQRvalue.Text = scannedQRCode;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Unsubscribe from the "UpdateScannedQRCodeText" message
            MessagingCenter.Unsubscribe<QRCodeScannerPage, string>(this, "UpdateScannedQRCodeText");
        }
    }

}
