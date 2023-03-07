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


        EditText txtProblem;
        EditText txtArea;
        EditText txtInformation;
        Button btnSave;
      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            txtProblem = FindViewById<EditText>(Resource.Id.txtProblem);
            txtArea = FindViewById<EditText>(Resource.Id.txtArea);
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            btnSave.Click += BtnSave_Click;


            // Create your application here
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}