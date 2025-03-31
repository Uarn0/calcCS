using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calc;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
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
    }

    private void BtnEquals_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            OntxtDisplay.Text = txtDisplay.Text;

            string expression = txtDisplay.Text.Replace(",", ".").Replace("×", "*").Replace("÷", "/");

            if (expression.Count(c => "+-*/".Contains(c)) != 1)
            {
                txtDisplay.Text = "Error";
                return;
            }
            object result = new System.Data.DataTable().Compute(expression, null);

            txtDisplay.Text = result.ToString();
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
        if (!txtDisplay.Text.Contains(","))
            txtDisplay.Text += ",";
    }

    private void BtnDivide_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "÷";
    }

    private void Btn9_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "9";
    }

    private void Btn8_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "8";
    }

    private void Btn7_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "7";
    }

    private void Btn6_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "6";
    }

    private void Btn5_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "5";
    }

    private void Btn4_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "4";
    }

    private void Btn3_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "3";
    }

    private void Btn0_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "0";
    }

    private void Btn2_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "2";
    }

    private void Btn1_Click(object sender, RoutedEventArgs e)
    {
        txtDisplay.Text += "1";
    }

    private void BtnClear_Click(object sender, RoutedEventArgs e)
    {
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