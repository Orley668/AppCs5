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
    [Activity(Label = "CreateTicket")]
    public class CreateTicket : Activity
    {


        EditText txtNameTicket ;
        EditText txtOrigen;
        EditText txtDestino;
        EditText txtValor ;
        Button btnCrearTicket;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateTicket);
            txtNameTicket = FindViewById<EditText>(Resource.Id.txtNameTicket);
            txtOrigen = FindViewById<EditText>(Resource.Id.txtOrigen);
            txtDestino = FindViewById<EditText>(Resource.Id.txtDestino);
            txtValor = FindViewById<EditText>(Resource.Id.txtValor);
            btnCrearTicket = FindViewById<Button>(Resource.Id.btnCrearTicket);
            btnCrearTicket.Click += BtnCrearTicket_Click;


            // Create your application here
        }

        private void BtnCrearTicket_Click(object sender, EventArgs e)
        {
           try
            {

                if (!string.IsNullOrEmpty(txtNameTicket.Text.Trim()))
                {

                    new Auxiliar().GuardarTicket(new CrearTicket()
                    {
                        Id = 0,
                        NameTicket = txtNameTicket.Text.Trim(),
                        OrigenTicket = txtOrigen.Text.Trim(),
                        DestinoTicket = txtDestino.Text.Trim(),
                        ValorTicket = double.Parse(txtValor.Text.Trim())
                    });
                    Toast.MakeText(this,"Registro Guardado",ToastLength.Long).Show();
                    txtNameTicket.Text ="";
                    txtOrigen.Text = "";
                    txtDestino.Text = "";
                    txtValor.Text = "";
                    btnCrearTicket.Text = "";


                }
                else
                {
                    Toast.MakeText(this, "Ingrese los campos requeridos", ToastLength.Long).Show();
                   
                }
            }
            catch
            {



            }











        }

       
    }
}