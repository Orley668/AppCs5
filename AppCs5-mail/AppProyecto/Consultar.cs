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
    [Activity(Label = "Consultar")]
    public class Consultar : Activity
    {
        EditText txtId;
        EditText txtNombreTicket;
        EditText txtOrigen;
        EditText txtDestino;
        EditText txtValor;
        Button btnConsultar;
        Button btnModificar;
        Button btnDelete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.Consultar);
            txtId = FindViewById<EditText>(Resource.Id.txtId);
            txtNombreTicket = FindViewById<EditText>(Resource.Id.txtNombreTicket);
            txtOrigen = FindViewById<EditText>(Resource.Id.txtOrigen);
            txtDestino = FindViewById<EditText>(Resource.Id.txtDestino);
            txtValor = FindViewById<EditText>(Resource.Id.txtValor);
            btnModificar = FindViewById<Button>(Resource.Id.btnModificar);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnConsultar=FindViewById<Button>(Resource.Id.btnConsultar);
            btnModificar.Click += BtnModificar_Click;
            btnDelete.Click += BtnDelete_Click;
            btnConsultar.Click += BtnConsultar_Click;
            // Create your application here
        }

     

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int Id;
            try
            {
                if (!string.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    if (int.TryParse(txtId.Text.Trim(), out Id))
                    {
                        new Auxiliar().EliminarTicket(Id);
                        Toast.MakeText(this, "Registro Eliminado", ToastLength.Long).Show();

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
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();


            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                CrearTicket Consultar = null;
                if (!string.IsNullOrEmpty(txtNombreTicket.Text.Trim()))
                {
                    Consultar = new Auxiliar().SelecionarUnTicket(txtNombreTicket.Text.Trim());
                    if (Consultar != null)
                    {

                        txtNombreTicket.Text = Consultar.NameTicket.ToString();
                        txtDestino.Text = Consultar.DestinoTicket.ToString();
                        txtOrigen.Text = Consultar.OrigenTicket.ToString();
                        txtValor.Text = Consultar.ValorTicket.ToString();
                        txtId.Text=Consultar.Id.ToString();
                    }
                    else
                    {

                        Toast.MakeText(this, "Registro no Encontrado", ToastLength.Long).Show();
                    }



                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
          


        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Modificar));
            StartActivity(i);
        }
    }
}