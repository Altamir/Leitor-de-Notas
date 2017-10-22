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
using Android;

namespace Leitor_De_Notas.Login
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        EditText ed_login;
        EditText ed_pass;

        TextView tx_msgError;       
        Button bt_logar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            
            ed_login = FindViewById<EditText>(Resource.Id.et_login);
            ed_pass = FindViewById<EditText>(Resource.Id.et_pass);

            tx_msgError = FindViewById<TextView>(Resource.Id.lb_msg_error);
            tx_msgError.Visibility = Android.Views.ViewStates.Gone;
            bt_logar = FindViewById<Button>(Resource.Id.bt_logar);

            bt_logar.Click += Bt_logar_ClickAsync;
        }

        private async void Bt_logar_ClickAsync(object sender, System.EventArgs e)
        {
          var l =   Acr.UserDialogs.UserDialogs.Instance.Loading();
            bool ok = true;
            if (string.IsNullOrWhiteSpace(ed_login.Text))
            {
                ed_login.SetError("Login é obrigatorio", null);
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(ed_pass.Text))
            {
                ed_pass.SetError("Senha é obrigatorio", null);
                ok = false;
            }
            if (ok)
            {
                var login = await Notas_Util.LoginService.LoginAsync(ed_login.Text, ed_pass.Text);
                if (login)
                {
                    StartActivity(typeof(Home));
                }
                else
                {
                    tx_msgError.Text = "Login ou senha incorreto!";
                    tx_msgError.Visibility = Android.Views.ViewStates.Visible;
                }

            }
            l.Hide();
        }

        public override void OnBackPressed()
        {
           
        }
    }
}