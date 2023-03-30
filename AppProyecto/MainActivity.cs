using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace AppProyecto
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtUsuario;
        EditText txtClave;
        Button btnIngresar;
        Button btnRegistrar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            txtUsuario = FindViewById<EditText>(Resource.Id.txtUser);
            txtClave = FindViewById<EditText>(Resource.Id.txtPassword);
            btnIngresar = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegistrar = FindViewById<Button>(Resource.Id.btnSingIn);

            btnIngresar.Click += BtnIngresar_Click;
            btnRegistrar.Click += BtnRegistrar_Click;
        }

        private void BtnRegistrar_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(RegistrarUsuario));
            StartActivity(i);
        }

        private void BtnIngresar_Click(object sender, System.EventArgs e)
        {
            try
            {
                Login resultado = null;
                if (!string.IsNullOrEmpty(txtUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtClave.Text.Trim()))
                {
                    resultado = new Auxiliar().SeleccionarUno(txtUsuario.Text.Trim(), txtClave.Text.Trim());
                    if (resultado != null)
                    {
                        txtUsuario.Text = resultado.User.ToString();
                        Toast.MakeText(this, "Login realizado con exito", ToastLength.Short).Show();
                        var bienvenido = new Intent(this, typeof(Menu));
                        bienvenido.PutExtra("usuario", FindViewById<EditText>(Resource.Id.txtUser).Text);
                        StartActivity(bienvenido);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Nombre de usuario y/o clave inválida(s)", ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "Nombre de usuario y/o clave son vacios", ToastLength.Long).Show();
                }

            }
            catch
            {

            }
        }


    }
}