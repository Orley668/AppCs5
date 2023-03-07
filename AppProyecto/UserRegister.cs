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

namespace AppProyecto
{
    [Activity(Label = "UserRegister")]
    public class UserRegister : Activity
    {

        EditText txtName;
        EditText txtSurname;
        EditText txtAge;
        EditText txtEmail;
        EditText txtPassword;
        EditText txtConfirmPassword;
        Button btnSingIn;


     
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            txtName = FindViewById<EditText>(Resource.Id.txtName);
            txtSurname = FindViewById<EditText>(Resource.Id.txtSurName);
            txtAge = FindViewById<EditText>(Resource.Id.txtAge);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            txtConfirmPassword = FindViewById<EditText>(Resource.Id.txtConfirmPassword);
            btnSingIn = FindViewById<Button>(Resource.Id.btnSingIn);

            btnSingIn.Click += BtnSingIn_Click;



            // Create your application here
        }

        private void BtnSingIn_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }
    }
}