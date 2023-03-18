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
            SetContentView(Resource.Layout.UserRegister);

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

            try
            {
                if (!string.IsNullOrEmpty(txtNuevoUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtNuevoUsuario.Text)
                {

                    new Auxiliar().Guardar(new Login() { Id = 0, User = txtNuevoUsuario.Text.Trim(), Password = txtNuevacontraseña })
                        Toast.MakeText(this, "Registro guardado", ToastLength.Long).Show();
                }
                else
                {

                    Toast.MakeText(this, "Por favor ingrese un hombre de usuario y una clave", ToastLength.Long).Show();
                }

            }
        
    
            catch (Exception ex)
            {

                Toast.MakeText(this,ex.ToString(), ToastLength.Long).Show();


            }
            
        }
    }
}