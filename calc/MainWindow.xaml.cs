using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calc;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private bool isResultDisplayed = false;

    private object lastResult = "";
    private bool isPanelOpen = false;
    public MainWindow()
    {

        InitializeComponent();
        btnUndo.Click += BtnUndo_Click;
        btnClear.Click += BtnClear_Click;
        btnEquals.Click += BtnEquals_Click;

        btn0.Click += Btn0_Click;
        btn1.Click += Btn1_Click;
        btn2.Click += Btn2_Click;
        btn3.Click += Btn3_Click;
        btn4.Click += Btn4_Click;
        btn5.Click += Btn5_Click;
        btn6.Click += Btn6_Click;
        btn7.Click += Btn7_Click;
        btn8.Click += Btn8_Click;
        btn9.Click += Btn9_Click;
        btnDot.Click += BtnDot_Click;
        
        btnDivide.Click += BtnDivide_Click;
        btnMult.Click += BtnMult_Click;
        btnPlus.Click += BtnPlus_Click;
        btnMinus.Click += BtnMinus_Click;
        btnProcent.Click += BtnProcent_Click;
        btnPosNeg.Click += BtnPosNeg_Click;
        btnMore.Click += BtnMore_Click;
        btnPi.Click += BtnPi_Click;
        btnLogariphm.Click += BtnLogariphm_Click;
        btnEpsilon.Click += BtnEpsilon_Click;
        btnDegree.Click += BtnDegree_Click;
        btnSqrt.Click += BtnSqrt_Click;
    }

    private void BtnSqrt_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "√";
    }



    private void BtnDegree_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "^";
    }

    private void BtnEpsilon_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "e";
    }

    private void BtnLogariphm_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "ln";
    }

    private void BtnPi_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "π";
    }

    private void ExpandLastColumn()
    {
        LastColumn.Width = new GridLength(1, GridUnitType.Star);
    }
    private void CollapseLastColumn()
    {
        LastColumn.Width = new GridLength(0);
    }
    private void BtnMore_Click(object sender, RoutedEventArgs e)
    {
        if (isPanelOpen)
        {
            CollapseLastColumn();
            btnMore.Content = "≡";
        }
        else
        {
            ExpandLastColumn();
            btnMore.Content = "⭕";
        }

        isPanelOpen = !isPanelOpen;
    }

    private void BtnPosNeg_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (txtDisplay.Text.Length == 0)
                return;

            // Якщо перший символ - мінус або плюс, то просто змінюємо знак
            if (txtDisplay.Text.StartsWith("-"))
            {
                txtDisplay.Text = txtDisplay.Text.Substring(1);  // Видаляємо мінус
            }
            else if (txtDisplay.Text.StartsWith("+"))
            {
                txtDisplay.Text = txtDisplay.Text.Substring(1);  // Видаляємо плюс
            }
            else
            {
                txtDisplay.Text = "-" + txtDisplay.Text;  // Додаємо мінус
            }
        }
        catch
        {
            txtDisplay.Text = "Error";
        }
    }


    private void BtnProcent_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "%";
    }
    

    private void BtnEquals_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            OntxtDisplay.Text = txtDisplay.Text;

            string expression = txtDisplay.Text
                .Replace(",", ".")
                .Replace("×", "*")
                .Replace("÷", "/")
                .Replace("π", "3.141592653589793")
                .Replace("e", "2.718281828459045");

            expression = Regex.Replace(expression, @"√(\d+(\.\d+)?)", m =>
            {
                double number = double.Parse(m.Groups[1].Value);
                return Math.Sqrt(number).ToString().Replace(",", ".");
            });

            expression = Regex.Replace(expression, @"ln(\d+(\.\d+)?)", m =>
            {
                double number = double.Parse(m.Groups[1].Value);
                return Math.Log(number).ToString().Replace(",", ".");
            });

            expression = Regex.Replace(expression, @"(\d+(\.\d+)?)\^(\d+(\.\d+)?)", m =>
            {
                double baseNum = double.Parse(m.Groups[1].Value);
                double exponent = double.Parse(m.Groups[3].Value);
                return Math.Pow(baseNum, exponent).ToString().Replace(",", ".");
            });
            expression = Regex.Replace(expression, @"(\d+(\.\d+)?)([\+\-\*/])(\d+(\.\d+)?)%", m =>
            {
                double x = double.Parse(m.Groups[1].Value);
                string op = m.Groups[3].Value;
                double y = double.Parse(m.Groups[4].Value);

                double percentOfX = x * y / 100.0;
                return $"{x}{op}{percentOfX.ToString().Replace(",", ".")}";
            });


            var result = new DataTable().Compute(expression, "");
            txtDisplay.Text = result.ToString();
            lastResult = result;
            isResultDisplayed = true;
        }
        catch
        {
            txtDisplay.Text = "Error";
        }
    }


    private void BtnMinus_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "-";
    }

    private void BtnPlus_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "+";
    }

    private void BtnMult_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "×";
    }

    private void BtnDot_Click(object sender, RoutedEventArgs e)
    {
            txtDisplay.Text += ",";
    }

    private void BtnDivide_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "÷";
    }

    private void Btn9_Click(object sender, RoutedEventArgs e)
    {
        if (isResultDisplayed && txtDisplay.Text == lastResult.ToString())
        {
            OntxtDisplay.Text = "";
            txtDisplay.Text = "9";  
            isResultDisplayed = false; 
        }
        else
        {
            txtDisplay.Text += "9";
        }
    }

    private void Btn8_Click(object sender, RoutedEventArgs e)
    {
        if (isResultDisplayed && txtDisplay.Text == lastResult.ToString())
        {
            OntxtDisplay.Text = "";
            txtDisplay.Text = "8";
            isResultDisplayed = false;
        }
        else
        {
            txtDisplay.Text += "8";
        }
    }

    private void Btn7_Click(object sender, RoutedEventArgs e)
    {
        if (isResultDisplayed && txtDisplay.Text == lastResult.ToString())
        {
            OntxtDisplay.Text = "";
            txtDisplay.Text = "7";
            isResultDisplayed = false;
        }
        else
        {
            txtDisplay.Text += "7";
        }
    }

    private void Btn6_Click(object sender, RoutedEventArgs e)
    {
        if (isResultDisplayed && txtDisplay.Text == lastResult.ToString())
        {
            OntxtDisplay.Text = "";
            txtDisplay.Text = "6";
            isResultDisplayed = false;
        }
        else
        {
            txtDisplay.Text += "6";
        }
    }

    private void Btn5_Click(object sender, RoutedEventArgs e)
    {
        if (isResultDisplayed && txtDisplay.Text == lastResult.ToString())
        {
            OntxtDisplay.Text = "";
            txtDisplay.Text = "5";
            isResultDisplayed = false;
        }
        else
        {
            txtDisplay.Text += "5";
        }
    }

    private void Btn4_Click(object sender, RoutedEventArgs e)
    {
        if (isResultDisplayed && txtDisplay.Text == lastResult.ToString())
        {
            OntxtDisplay.Text = "";
            txtDisplay.Text = "4";
            isResultDisplayed = false;
        }
        else
        {
            txtDisplay.Text += "4";
        }
    }

    private void Btn3_Click(object sender, RoutedEventArgs e)
    {
        if (isResultDisplayed && txtDisplay.Text == lastResult.ToString())
        {
            OntxtDisplay.Text = "";
            txtDisplay.Text = "3";
            isResultDisplayed = false;
        }
        else
        {
            txtDisplay.Text += "3";
        }
    }

    private void Btn0_Click(object sender, RoutedEventArgs e)
    {
        if (isResultDisplayed && txtDisplay.Text == lastResult.ToString())
        {
            OntxtDisplay.Text = "";
            txtDisplay.Text = "0";
            isResultDisplayed = false;
        }
        else
        {
            txtDisplay.Text += "0";
        }
    }

    private void Btn2_Click(object sender, RoutedEventArgs e)
    {
        if(isResultDisplayed && txtDisplay.Text == lastResult.ToString())
        {
            OntxtDisplay.Text = "";
            txtDisplay.Text = "2";
            isResultDisplayed = false;
        }
        else
        {
            txtDisplay.Text += "2";
        }
    }

    private void Btn1_Click(object sender, RoutedEventArgs e)
    {
        if (isResultDisplayed && txtDisplay.Text == lastResult.ToString())
        {
            OntxtDisplay.Text = "";
            txtDisplay.Text = "1";
            isResultDisplayed = false;
        }
        else
        {
            txtDisplay.Text += "1";
        }
    }

    private void BtnClear_Click(object sender, RoutedEventArgs e)
    {
        OntxtDisplay.Text = "";
        txtDisplay.Text = "";
    }
    

    private void BtnUndo_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(txtDisplay.Text))
        {
            txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
        }
    }

    //private void BtnClearEntry_Click(object sender, RoutedEventArgs e)
    //{
    //    if (!string.IsNullOrEmpty(txtDisplay.Text))
    //    {
    //        string[] parts = txtDisplay.Text.Split(new char[] { '+', '-', '*', '÷' });
    //        if(parts.Length > 0)
    //        {
    //            txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - parts[^1].Length);
    //        }
    //    }
    //}

}