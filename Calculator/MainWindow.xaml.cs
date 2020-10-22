using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set textbox content to 0
            Textbox.Text = "0";
        }

        /// <summary>
        /// Handles number or "," button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Cast the sender to a button
            var button = (Button)sender;

            // If textbox content is 0, replace the content with clicked number or ","
            // Else add clicked number or "," to textbox
            if (Textbox.Text == "0")
            {
                Textbox.Text = button.Content.ToString();
            } else
            {
                Textbox.AppendText(button.Content.ToString());
            }
        }

        /// <summary>
        /// Handles operator button click event
        /// </summary>
        /// <param name="sender"><param>
        /// <param name="e"></param>
        private void ButtonOperator_Click(object sender, RoutedEventArgs e)
        {
            // Cast the sender to a button
            var button = (Button)sender;

            // If trying to add duplicate operator, keep displaying one. If the operator is different, change to that

            // Add the clicked operator to textbox
            Textbox.AppendText($" {button.Content.ToString()} ");
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            // Delete textbox content
            string text = Textbox.Text;

            // If textbox content is longer than 0 and the second to last character is ' ', delete 2 last characters
            // Else if textbox content is longer than 0, delete the last character
            // Else change textbox content to "0"
            if (text.Length > 1 && text[text.Length - 1] == ' ')
            {
                text = text.Substring(0, text.Length - 2);
            } else if (text.Length > 1)
            {
                text = text.Substring(0, text.Length - 1);
            } else
            { 
                text = "0";
            }

            Textbox.Text = text;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            //Delete the last character
            Textbox.Text = "0";
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            // Get text from textbox and split it into 3 parts
            string[] parts = Textbox.GetLineText(0).Split(' ');

            // Initialize first and second values
            double firstVal = 0;
            double secondVal = 0;

            // If neither values haven't been entered, present an error ???

            // If no operator hasn't been entered, present an error ???

            // If either the first or second value hasn't been entered, set it to the other entered value
            // Else set variables to their corresponding values
            if (parts[0] == "")
            {
                firstVal = double.Parse(parts[2]);
                secondVal = double.Parse(parts[2]);
            } else if (parts[2] == "")
            {
                firstVal = double.Parse(parts[0]);
                secondVal = double.Parse(parts[0]);
            } else
            {
                firstVal = double.Parse(parts[0]);
                secondVal = double.Parse(parts[2]);
            }

            // Initialize the result variable
            double result = 0;

            // Set result to the result of the calculation with the correct operator
            switch (parts[1])
            {
                case "/":
                    result = firstVal / secondVal;
                    break;
                case "*":
                    result = firstVal * secondVal;
                    break;
                case "-":
                    result = firstVal - secondVal;
                    break;
                case "+":
                    result = firstVal + secondVal;
                    break;
            }

            // Set textbox to result
            Textbox.Text = result.ToString();
        }
    }
}
