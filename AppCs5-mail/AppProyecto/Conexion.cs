using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using Path = System.IO.Path;
namespace AppProyecto
{
    #region uso de datos de un usuario



    public class Login
    {


        public Login() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string User { get; set; }


        [MaxLength(20)]
        public string Password { get; set; }





    }
    #endregion

    #region Uso de datos para el crear ticket
    public class CrearTicket
    {

        public CrearTicket() { }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength (20)]

        public string NameTicket { get; set; }
        [MaxLength(20)]
        public string OrigenTicket { get; set; }
        [MaxLength(20)]
        public string DestinoTicket { get; set; }
        [MaxLength(30)]
        public double ValorTicket { get; set; }


    }
    #endregion
    #region Manejo de datos y conexion a BD

    public class Auxiliar
    {
        static object locker = new object();
        SQLiteConnection conexion;



        public Auxiliar()
        {//constructor

            conexion = conectarBD();
            conexion.CreateTable<Login>();
            conexion.CreateTable<CrearTicket>();

        }

        public SQLite.SQLiteConnection conectarBD()
        {

            SQLiteConnection conexionBaseDatos;
            string NombreArchivo = "Basedatos.db3";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completaRuta = Path.Combine(ruta, NombreArchivo);
            conexionBaseDatos = new SQLiteConnection(completaRuta);
            return conexionBaseDatos;
        }
        //Seleccionar 1 usuario
        public Login SeleccionarUno(string NombreUsuario, string ClaveUsuario) {

            lock (locker)
            {
                return conexion.Table<Login>().FirstOrDefault(x => x.User == NombreUsuario && x.Password == ClaveUsuario);



            }


        }
        //selecionar un Ticket
        public CrearTicket SelecionarUnTicket(int Id)
        {
            lock (locker) { 
            
            return conexion.Table<CrearTicket>().FirstOrDefault(x => x.Id == Id);
            }

        }



        //selecionar muchos registros

        public IEnumerable<Login> SeleccionarTodo()
        {

            lock (locker)
            {

                return (from i in conexion.Table<Login>() select i).ToList();

            }
        }

        //seleccionar todos los registros del ticket

        public IEnumerable<CrearTicket> SelecionarTodosTicket()
        {
            lock (locker)
            {
                return ( from i in conexion.Table<CrearTicket>() select i).ToList();
            }

        }

        //Guardar o Actualizar

        public int Guardar(Login registro)
        {

            lock (locker)
            {
                if (registro.Id == 0)
                {

                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }


        }

        //guardar ticket

        public int GuardarTicket(CrearTicket registro)
        {

            lock (locker)
            {
                if (registro.Id == 0)
                {

                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }


        }


        //Eliminar 
        public int Eliminar(int ID)
        {

            lock (locker)
            {

                return conexion.Delete<Login>(ID);
            }
        }

        //Eliminar Ticket

        public int EliminarTicket(int ID)
        {

            lock (locker)
            {

                return conexion.Delete<CrearTicket>(ID);
            }
        }


    }











    #endregion



    
}