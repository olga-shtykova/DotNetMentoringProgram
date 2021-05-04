using GreetingStandardLibrary;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] array = System.Environment.GetCommandLineArgs();

            #region Task 1
            //if (args.Length == 0 || args[0].Any(char.IsDigit))
            //{
            //    MessageBox.Show("Incorrect input");
            //}

            //if (args.Length > 0 || args[0].All(char.IsLetter))
            //{
            //    MessageBox.Show($"Hello, {args[1]}!");
            //}           

            #endregion

            #region Task 2
            string time = DateTime.Now.ToString("HH:mm:ss");

            MessageBox.Show(UserInput.GreetUser(time, array, 1));
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            MessageBox.Show($"Hello, {name}");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox1.Text.Length < 2 || textBox1.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Input is incorrect. Try again.");
            }
        }
    }
}
