using GetechnologiesMxFront.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GetechnologiesMxFront
{
    /// <summary>
    /// Lógica de interacción para Registrar.xaml
    /// </summary>
    public partial class Registrar : Window
    {
        public Registrar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inicio a= new Inicio();
            a.Show();   
            this.Close();   
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string correo= txtCorreo.Text;
            string contraseña = txtContra.Text;

            if (correo.Equals("") && txtContra.Equals("")) MessageBox.Show("Todos los campos son obligatorios");
            else
            {
                Usuario usuario = new Usuario();
                usuario.correo= txtCorreo.Text;
                usuario.contra= txtContra.Text;

                Usuario use = Funciones.Registro.incribir(usuario);

                if (use.contra!=null)
                {
                    MessageBox.Show("Usuario Registrado Con Exito");
                    Inicio a = new Inicio();
                    a.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al registrar el usuario intente de nuevo...");
                }

            }

        }
    }
}
