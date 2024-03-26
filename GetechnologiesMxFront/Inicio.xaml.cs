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
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registrar a = new Registrar();
            a.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            string correo = txtCorreo.Text;
            string contra= txtContra.Text;

            if (Funciones.Login.verificaLogin(correo,contra))
            {
                Principal a= new Principal();
                a.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("El Usuario No Existe");
            }
        }
    }
}
