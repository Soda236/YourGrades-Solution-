using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace YourGradeScore
{
    internal class Digits
    {
        string pattern = @"\d+";
        Regex regex;
        MatchCollection matches;
        float result;
        int amount;
        int sum;
        int grade;

        public float ClearGrades(string draft)
        {
            sum = 0;
            regex = new Regex(pattern);

            try
            {
                matches = regex.Matches(draft);
                amount = matches.Count;


                foreach (Match match in matches)
                {
                    sum += int.Parse(match.Value);
                }

                result = (float)sum / amount;
                Console.WriteLine(result);
            }
            catch (Exception)
            
            {
                MessageBox.Show("The input value is incorrect", "Excepiton", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return result;

        }

        public string GradeCalculator(float average)
        {
            if (average > 4.5) grade = 5;
            else if (average > 3.5) grade = 4;
            else if (average > 2.5) grade = 3;
            else if (average > 1.5) grade = 2;
            else grade = 1;

            return grade.ToString();
        }

    }
}
