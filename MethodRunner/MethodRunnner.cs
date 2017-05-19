using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodRunner
{
    public partial class MethodRunnner : Form
    {
        private Label[] numberLabel;
        private Label methodOutputLabel;
        private Label lambdaOutputLabel;
        private Button submit;
        private TextBox[] numberInput;
        private TextBox methodOutput;
        private TextBox lambdaOutput;

        public MethodRunnner()
        {
            InitializeComponent();
            this.Size = new Size(500, 500);
            numberLabel = new Label[3];
            numberInput = new TextBox[3];
            for(int i=0;i<numberLabel.Length;i++)
            {
                numberLabel[i] = new Label();
                numberLabel[i].Text = "Number " + Convert.ToString(i + 1);
                numberLabel[i].Width = 75;
                numberLabel[i].Location = new Point(0, i * 50 + 5);

                numberInput[i] = new TextBox();
                numberInput[i].Width = 25;
                numberInput[i].Location = new Point(80, i * 50 + 3);

                Controls.Add(numberLabel[i]);
                Controls.Add(numberInput[i]);
            }

            submit = new Button();
            submit.Text = "Go!";
            submit.Click += runMethods;
            submit.Location = new Point(125, 2);

            methodOutputLabel = new Label
            {
                Text = "Method output",
                Width = 150,
                Location = new Point(0, 175)
            };

            lambdaOutputLabel = new Label
            {
                Text = "Lambda output",
                Width = 150,
                Location = new Point(250, 175)
            };

            methodOutput = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Size = new Size(200, 250),
                Location = new Point(0, 200)
            };

            lambdaOutput = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Size = new Size(200, 250),
                Location = new Point(250, 200)
            };

            Controls.Add(submit);
            Controls.Add(methodOutputLabel);
            Controls.Add(lambdaOutputLabel);
            Controls.Add(methodOutput);
            Controls.Add(lambdaOutput);
        }

        private void MethodRunnner_Load(object sender, EventArgs e)
        {

        }

        public void runMethods(object sender, EventArgs e)
        {
            string[] input = new string[3];
            for (int i = 0; i < 3; i++)
            {
                input[i] = numberInput[i].Text;
            }
            if(IsNumber(input))
            {
                int[] intInput = Array.ConvertAll(input, s => int.Parse(s));
                methodOutput.AppendText("TimesThree(" + Convert.ToString(intInput[0]) + ") = " + Convert.ToString(TimesThree(intInput[0]))+ "\n");
                methodOutput.AppendText("AddNumbers(" + input[0] + ", " + input[1] + ", " + input[2] + ") = " + Convert.ToString(AddNumbers(intInput)) + "\n");
                methodOutput.AppendText("IsEven(" + Convert.ToString(intInput[0]) + ") = " + Convert.ToString(IsEven(intInput[0])) + "\n");
                lambdaOutput.AppendText("timesThree(" + Convert.ToString(intInput[0]) + ") = " + Convert.ToString(timesThree(intInput[0])) + "\n");
                lambdaOutput.AppendText("addNumbers(" + input[0] + ", " + input[1] + ", " + input[2] + ") = " + Convert.ToString(addNumbers(intInput)) + "\n");
                lambdaOutput.AppendText("isEven(" + Convert.ToString(intInput[0]) + ") = " + Convert.ToString(isEven(intInput[0])) + "\n");
            }
            else
            {
                MessageBox.Show("De ingevoerde waarden zijn leeg of ongeldig", "Foutmelding");
            }
        }

        public bool IsNumber(String[] s)
        {
            bool b = true;
            
            for (int i = 0; i < s.Length; i++)
            {
                if (!Regex.IsMatch(s[i], @"^\d+$"))
                {
                    b = false;
                }
            }
            return b;
        }

        public int TimesThree(int i)
        {
            return i * 3;
        }

        Func<int, int> timesThree = x => 3 * x;        
        
        public int AddNumbers(int[] i)
        {
            return i.Sum();
        }

        Func<int[], int> addNumbers = x => x.Sum();

        public Boolean IsEven(int i)
        {
            return !Convert.ToBoolean(i % 2);
        }

        Func<int, bool> isEven = x => !Convert.ToBoolean(x % 2);
    }
}   
