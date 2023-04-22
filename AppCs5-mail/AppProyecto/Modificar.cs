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
    [Activity(Label = "Modificar")]
    public class Modificar : Activity

    {
        EditText txtId;
        EditText txtNombreTicket;
        EditText txtOrigen;
        EditText txtDestino;
        EditText txtValor;
        Button btnModificar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.Modificar);
            txtId = FindViewById<EditText>(Resource.Id.txtId);
            txtNombreTicket = FindViewById<EditText>(Resource.Id.txtNombreTicket);
            txtOrigen = FindViewById<EditText>(Resource.Id.txtOrigen);
            txtDestino = FindViewById<EditText>(Resource.Id.txtDestino);
            txtValor = FindViewById<EditText>(Resource.Id.txtValor);
            btnModificar = FindViewById<Button>(Resource.Id.btnModificar);


            btnModificar.Click += BtnModificar_Click;

            // Create your application here
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            int Id;
            try
            {
                if (!string.IsNullOrEmpty(txtId.Text.Trim()) && !string.IsNullOrEmpty(txtNombreTicket.Text.Trim())) 
                {
                    if (int.TryParse(txtOrigen.Text.Trim(), out Id))
                    {
                        new Auxiliar().GuardarTicket(new CrearTicket() { Id = Id, NameTicket = txtNombreTicket.Text });
                        Toast.MakeText(this, "Registro Guardado", ToastLength.Long).Show();

                    }
                    else
                    {

                        Toast.MakeText(this, "Por favor ingrese los datos Correctamente", ToastLength.Long).Show();

                    }
                }
            
                else
                {

                    Toast.MakeText(this, "Por favor ingrese los datos solicitados", ToastLength.Long).Show();

                }

            }
            catch(Exception ex)
            {
                Toast.MakeText(this,ex.Message, ToastLength.Long).Show();


            }
        }
    }
}