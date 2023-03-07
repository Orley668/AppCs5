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
    [Activity(Label = "DeleteTicket")]
    public class DeleteTicket : Activity
    {
        EditText txtArea;
        EditText txtInformation;
        
        Button btnDelete;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            txtArea= FindViewById<EditText>(Resource.Id.txtArea);
            txtInformation = FindViewById<EditText>(Resource.Id.txtInformation);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnDelete.Click += BtnDelete_Click;

            // Create your application here
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}