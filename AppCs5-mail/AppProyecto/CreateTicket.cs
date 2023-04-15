using Android.App;
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
    [Activity(Label = "Create_Ticket")]

    public class Create_Ticket : Activity
    {

        EditText txtNombreTicket;
        EditText txtOrigen;
        EditText txtDestino;
        EditText txtValor;
        Button btnCrearTicket;
        Button btnConsultar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateTicket);
            txtNombreTicket = FindViewById<EditText>(Resource.Id.txtNombreTicket);
            txtOrigen = FindViewById<EditText>(Resource.Id.txtOrigen);
            txtDestino = FindViewById<EditText>(Resource.Id.txtDestino);
            txtValor = FindViewById<EditText>(Resource.Id.txtValor);
            btnCrearTicket = FindViewById<Button>(Resource.Id.btnCrearTicket);
            btnConsultar = FindViewById<Button>(Resource.Id.btnConsultar);

            btnCrearTicket.Click += BtnCrearTicket_Click;
            btnConsultar.Click += BtnConsultar_Click;


        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {


            Intent i = new Intent(this, typeof(Modificar));
            StartActivity(i);


        }

        private void BtnCrearTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombreTicket.Text.Trim()))
                {
                    new Auxiliar().GuardarTicket(new CrearTicket()
                    {
                        Id = 0,
                        NameTicket = txtNombreTicket.Text.Trim(),
                        OrigenTicket = txtOrigen.Text.Trim(),
                        DestinoTicket = txtDestino.Text.Trim(),
                        ValorTicket = double.Parse(txtValor.Text.Trim())
                    });
                    Toast.MakeText(this, "Registro Guardado", ToastLength.Long).Show();
                    txtNombreTicket.Text = "";
                    txtOrigen.Text = "";
                    txtDestino.Text = "";
                    txtValor.Text = "";
                }
                else
                {
                    Toast.MakeText(this, "Ingrese los campos requeridos", ToastLength.Long).Show();
                }

            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }




    }
}