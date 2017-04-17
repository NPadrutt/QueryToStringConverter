using System;
using System.Linq;
using System.Text;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QueryToStringConverter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text;
            InputQueryTextBlock.Document.GetText(TextGetOptions.UseCrlf, out text);

            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            var outputStringBuilder = new StringBuilder();

            lines.RemoveAll(string.IsNullOrWhiteSpace);

            for (var index = 0; index < lines.Count; index++)
            {
                var line = lines[index];

                if (index == lines.Count - 1)
                {
                    outputStringBuilder.AppendLine("\"" + line + " \" ");
                }
                else
                {
                    outputStringBuilder.AppendLine("\"" + line + " \" + ");
                }
            }

            OutputQueryTextBlock.Document.SetText(TextSetOptions.None, outputStringBuilder.ToString());
        }
    }
}
