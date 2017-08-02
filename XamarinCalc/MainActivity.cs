using System;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Content;

namespace XamarinCalc
{
    [Activity(Label = "Calculator - General", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private TextView txtNum1;
        private TextView txtNum2;

        private double Num1;
        private double Num2;
        private double Result;

        private Button btnplus;
        private Button btnminus;
        private Button btnmul;
        private Button btndivide;

        private Button btnBMI;

        //make a new list to hold the answers
        private List<string> AnswerList = new List<string>();

        //make a listview to tie into the one on the View
        //private ListView lvAnswer;

        //Make an adapter to tie the List to the Listview.
        //private ArrayAdapter<string> AnswerAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            InitializeControls();
        }

        //you need to bind the controls you just made in the Activity to the controls in the Xaml - this will only work AFTER you have built it as it needs to create the Resource first
        void InitializeControls()
        {
            btnplus = FindViewById<Button>(Resource.Id.btnPlus);
            btnminus = FindViewById<Button>(Resource.Id.btnMinus);
            btnmul = FindViewById<Button>(Resource.Id.btnMul);
            btndivide = FindViewById<Button>(Resource.Id.btnDivide);
            btnBMI = FindViewById<Button>(Resource.Id.btnBMI);
            txtNum1 = FindViewById<TextView>(Resource.Id.txtNum1);
            txtNum2 = FindViewById<TextView>(Resource.Id.txtNum2);
            //here we bind the btn we have made to a click even, which is just another method. (This can be inline but I like it this way to keep things simpler) 
            btnplus.Click += OnBtnOperator_Click;
            btnminus.Click += OnBtnOperator_Click;
            btnmul.Click += OnBtnOperator_Click;
            btndivide.Click += OnBtnOperator_Click;
            btnBMI.Click += OnBtnBMI_Click;



        }

        private void OnBtnBMI_Click(object sender, EventArgs e)
        {
            Intent BMICalc = new Intent(this,typeof(BMIActivity));
            StartActivity(BMICalc);
        }

        private void OnBtnOperator_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNum1.Text) || String.IsNullOrEmpty(txtNum2.Text) || String.Equals(txtNum1.Text, ".") || String.Equals(txtNum2.Text,"."))//due to the input type of 'txtNum's there can't be more than 1 '.' 
            {
                Toast.MakeText(this,"Invalid input",ToastLength.Short).Show();
                return;
            }
            string symbol=" ? ";
            string tag = "Button";
            Num1 = Convert.ToDouble(txtNum1.Text);
            Num2 = Convert.ToDouble(txtNum2.Text);

            switch (((Button)sender).Text)
            {
                case "/":
                    Result = Num1 / Num2;
                    symbol = " / ";
                    tag += ", Divide";
                    break;
                case "*":
                    Result = Num1 * Num2;
                    symbol = " * ";
                    tag += ", Multiply";
                    break;
                case "+":
                    Result = Num1 + Num2;
                    symbol = " + ";
                    tag += ", Add";
                    break;
                case "-":
                    Result = Num1 - Num2;
                    symbol = " - ";
                    tag += ", Subtract";
                    break;

            }
            string result = (Num1 + symbol + Num2 + " = " + Result).ToString();
            Log.Info(tag, Num1.ToString());
            Log.Info(tag, Num2.ToString());
            Log.Info(tag, result);
            Toast.MakeText(this, "The Result is " + Result, ToastLength.Long).Show();

        }
    }
}

