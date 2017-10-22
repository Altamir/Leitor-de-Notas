using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace NotasUITest
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                    .Android
                    .InstalledApp("Leitor_De_Notas.Leitor_De_Notas")
                    .EnableLocalScreenshots()
                    .StartApp();
        }

        [Test]
        public void App_error_login()
        {
            
            app.Screenshot("First screen.");
            app.EnterText("et_login", "Altamir");
            app.EnterText("et_pass", "123456");
            app.DismissKeyboard();
            app.Tap("bt_logar");
            app.WaitForElement(c =>
               c.Text("Login ou senha incorreto!"),
               "Wait msg error ",
               TimeSpan.FromSeconds(10));
            app.Screenshot("Error login");
        }

        [Test]
        public void App_Login_login()
        {
            app.EnterText("et_login", "Altamir");
            app.EnterText("et_pass", "12345");
            app.DismissKeyboard();
            app.Tap("bt_logar");
            app.WaitFor(() => 
                app.Query(e => e.Marked("tx_result"))
                .First().Enabled,"Wait for page");
        }
    }
}

