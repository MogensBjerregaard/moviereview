using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace MovieReviewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ITextAnalyticsClient _client = new TextAnalyticsClient(new ApiKeyServiceClientCredentials())
        {
            Endpoint = "https://westus.api.cognitive.microsoft.com"
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var inputString = InputReview.Text;
            InputReview.Text = "";
            Review.Content = "";
            Review.Content = inputString;
            var result = _client.SentimentAsync(
                new MultiLanguageBatchInput(
                    new List<MultiLanguageInput>()
                    {
                        new MultiLanguageInput("en", "0", inputString)
                    })).Result;
            var score = result.Documents[0].Score;
            Score.Value = 0;
            Score.Value = (double) (score ?? 0);

        }
    }
}
