using Android.App;
using Android.Widget;
using Android.OS;

namespace Leitor_De_Notas
{
    [Activity(Label = "Leitor_De_Notas", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Acr.UserDialogs.UserDialogs.Init(this);
            StartActivity(typeof(Leitor_De_Notas.Login.LoginActivity));
        }
    }
}

