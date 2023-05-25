using System.Windows;
using System.Windows.Media;

namespace YourGradeScore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string result;
        string clipboardData;
        Digits num = new Digits();

        public MainWindow()
        {
            InitializeComponent();
            input.Foreground = Brushes.Gray;
        }

        private void button_Click(object sender, RoutedEventArgs e) // Calculate Button
        {
            float average;
            string grade;

            if (input.Foreground == Brushes.Gray) return;
            else
            {
                average = num.ClearGrades(input.Text);
                grade = num.GradeCalculator(average);

                result = average.ToString("F1");
                gradeWin.Content = grade;

                if (result == "NaN")
                {
                    resultWin.Content = "nil";
                    gradeWin.Content = "nil";
                }
                else resultWin.Content = result;
            }

            switch (grade)
            {
                case "5":
                    gradeWin.Foreground = Brushes.DeepPink;
                    break;
                case "4":
                    gradeWin.Foreground = Brushes.SpringGreen;
                    break;
                case "3":
                    gradeWin.Foreground = Brushes.Yellow;
                    break;
                case "2":
                    gradeWin.Foreground = Brushes.Red;
                    break;
                case "1":
                    gradeWin.Foreground = Brushes.DarkRed;
                    break;
                default:
                    break;
            }

        }

        private void input_GotFocus(object sender, RoutedEventArgs e)
        {
            if (input.Foreground == Brushes.Gray)
            {
                input.Text = "";
                input.Foreground = Brushes.Black;
            }
        }

        private void pasteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                clipboardData = Clipboard.GetText();
                input.Foreground = Brushes.Black;
                input.Text = clipboardData.Replace(" ", string.Empty);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            input.Foreground = Brushes.Black;
            input.Text = "";
        }
    }
}
