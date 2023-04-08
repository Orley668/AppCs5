﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppProyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppProyecto
{
    [Activity(Label = "UserRegister")]
    public class RegistrarUsuario : Activity
    {
        EditText txtNuevoUsuario;
        EditText txtNuevaClaveUsuario;
        Button btnRegistrarUsuario;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserRegister);
          
            txtNuevoUsuario = FindViewById<EditText>(Resource.Id.txtNuevoUsuario);
            txtNuevaClaveUsuario = FindViewById<EditText>(Resource.Id.txtNuevaClaveUsuario);
            btnRegistrarUsuario = FindViewById<Button>(Resource.Id.btnRegistrarUsuarioNuevo);

            btnRegistrarUsuario.Click += BtnRegistrarUsuario_Click;
        }

        private void BtnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNuevoUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtNuevaClaveUsuario.Text.Trim()))
                {
                    new Auxiliar().Guardar(new Login() { Id = 0, User = txtNuevoUsuario.Text.Trim(), Password = txtNuevaClaveUsuario.Text.Trim() });
                    Toast.MakeText(this, "Registro guardado", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese un nombre de usuario y una clave", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }


    }
}