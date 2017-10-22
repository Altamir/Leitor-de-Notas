using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Leitor_De_Notas
{
    [Activity(Label = "Home")]
    public class Home : Activity
    {

        TextView tx_result;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);
            FindViewById<Button>(Resource.Id.button1).Click += Home_Click;
            FindViewById<Button>(Resource.Id.bt_scanner).Click += Home_Click1;
            tx_result = FindViewById<TextView>(Resource.Id.tx_result);
        }

        private async void Home_Click1(object sender, EventArgs e)
        {

            //var objScanner = new ZXing.Mobile.MobileBarcodeScanner();
            //var objResult = await objScanner.Scan();

            //if (objResult != null)
            //{
            //    tx_result.Text = "Código lido: " + objResult.Text;
            //}

        }

        private void Home_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(Login.LoginActivity));
        }
    }
}