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
        EditText txtNombreTicket;
        EditText txtOrigen;
        EditText txtDestino;
        EditText txtValor;
        Button btnModificar;
        Button btnDelete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.Modificar);
            txtNombreTicket = FindViewById<EditText>(Resource.Id.txtNombreTicket);
            txtOrigen = FindViewById<EditText>(Resource.Id.txtOrigen);
            txtDestino = FindViewById<EditText>(Resource.Id.txtDestino);
            txtValor = FindViewById<EditText>(Resource.Id.txtValor);
            btnModificar = FindViewById<Button>(Resource.Id.btnModificar);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);

            btnModificar.Click += BtnModificar_Click;
            btnDelete.Click += BtnDelete_Click;

            // Create your application here
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}