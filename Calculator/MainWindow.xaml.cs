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
            if (Textbox.Text == "0" || Textbox.Text == "NaN" || Textbox.Text == "∞")
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

            // Get textbox content
            string text = Textbox.Text;

            // If trying to add duplicate operator, keep displaying one. If the operator is different, change to that
            // Else add clicked operator to textbox
            if (text.Length >= 3)
            {
                if (text[text.Length - 2] == '/' || text[text.Length - 2] == '*' || text[text.Length - 2] == '-' || text[text.Length - 2] == '+')
                {
                    Textbox.Text = text.Substring(0, text.Length - 2) + button.Content.ToString() + " ";
                } else
                {
                    Textbox.AppendText($" {button.Content.ToString()} ");
                }
            } else
            {
                Textbox.AppendText($" {button.Content.ToString()} ");
            }
        }

        /// <summary>
        /// Handles delete button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            // Get textbox content
            string text = Textbox.Text;

            // If textbox content is longer than 1 and the last character is ' ', delete 3 last characters
            // Else if textbox content is longer than 1, delete the last character
            // Else change textbox content to "0"
            if (text.Length > 1 && text[text.Length - 1] == ' ')
            {
                text = text.Substring(0, text.Length - 3);
            } else if (text.Length > 1)
            {
                text = text.Substring(0, text.Length - 1);
            } else
            { 
                text = "0";
            }

            Textbox.Text = text;
        }

        /// <summary>
        /// Handles clear button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            //Set textbox content to 0 (clear textbox)
            Textbox.Text = "0";
        }

        /// <summary>
        /// Handles enter button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            // Get text from textbox and split it into array with 3 parts
            string[] parts = Textbox.GetLineText(0).Split(' ');

            // Initialize first and second values
            double firstVal = 0;
            double secondVal = 0;

            // Initialize the result variable
            double result = 0;

            // Do nothing on clicking enter if only the first value has been entered, no operator has been entered, or only "," has been entered on either side of the calculation
            if (parts.Length >= 3 && parts[2] != ",")
            {
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
}
