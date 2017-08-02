using System;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace XamarinCalc
{
    [Activity(Label = "Calculator - BMI")]
    public class BMIActivity : Activity
    {
        private TextView txtNum1;
        private TextView txtNum2;
        private double num1;
        private double num2;
        private Button btnCalculateBMI;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.BMI);
            InitializeControls();
        }

        private void InitializeControls()
        {
            btnCalculateBMI = FindViewById<Button>(Resource.Id.btnCalculateBMI);
            txtNum1 = FindViewById<TextView>(Resource.Id.txtNum1);
            txtNum2 = FindViewById<TextView>(Resource.Id.txtNum2);
            btnCalculateBMI.Click += CalcBMI;
        }

        private void CalcBMI(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNum1.Text) || String.IsNullOrEmpty(txtNum2.Text) || String.Equals(txtNum1.Text, ".") || String.Equals(txtNum2.Text, "."))//due to the input type of 'txtNum's there can't be more than 1 '.' 
            {
                Toast.MakeText(this, "Invalid input", ToastLength.Short).Show();
                return;
            }
            num1 = Convert.ToDouble(txtNum1.Text);
            num2 = Convert.ToDouble(txtNum2.Text);
            double result = num1 / num2 / num2;
            Log.Info("Button, BMI", num1.ToString());
            Log.Info("Button, BMI", num2.ToString());
            Log.Info("Button, BMI", result.ToString());
            Toast.MakeText(this, "BMI: " + result.ToString(), ToastLength.Long).Show();
        }
    }
}