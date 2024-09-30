// File Path: Pages/MainPage.xaml.cs
using Microsoft.Maui.Controls;
using TesseractOcrMaui; // Include library namespace
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using MauiApp2.Services;

namespace MauiApp2.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly TranslationService _translationService;

        public MainPage(ITesseract tesseract)
        {
            InitializeComponent();
            _translationService = new TranslationService();
            Tesseract = tesseract;
        }
        ITesseract Tesseract { get; }

        private async void OnPickImageClicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync();
            if (result != null)
            {
                await ProcessImage(result.FullPath);
            }
        }

        private async void OnCaptureImageClicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                await ProcessImage(result.FullPath);
            }
        }

        private async Task ProcessImage(string filePath)
        {
            CapturedImage.Source = ImageSource.FromFile(filePath);

            // Perform OCR using Tesseract
            var result = await Tesseract.RecognizeTextAsync(filePath);
            var recognizedText = result.RecognisedText;
            DetectedText.Text = recognizedText;

            // Translate the recognized text
            var translatedText = await _translationService.TranslateTextAsync(recognizedText, "en", "hi");
            TranslatedText.Text = translatedText;
        }
    }
}
