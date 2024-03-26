using GetechnologiesMxFront.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetechnologiesMxFront
{
    /// <summary>
    /// Lógica de interacción para Facturas.xaml
    /// </summary>
    public partial class Facturas : Page
    {
        List<Persona> personas = new List<Persona>();
        public Facturas()
        {
            InitializeComponent();
            
            personas = Funciones.Personas.getPersonas();            
            llenarCombo();
            cboPersonas.SelectedIndex = 0;
        }

        private void llenarCombo()
        {
            
            cboPersonas.Items.Insert(0,"Seleccione Una Persona");
            for (int i = 0; i < personas.Count; i++)
            {
                string nombre = personas[i].Nombre + personas[i].ApellidoPaterno;
                cboPersonas.Items.Insert(i+1, nombre);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(cboPersonas.SelectedIndex) > 0)
            {
                
                if (!validacion()) 
                {
                    MessageBox.Show("El monto no es valido");
                    limpiarcambios();
                    return;
                }
                Factura factura = new Factura();
                factura.IdPersona = personas[cboPersonas.SelectedIndex - 1].Id;
                factura.Fecha = dpfecha.SelectedDate;
                factura.Monto = Convert.ToDecimal(txtMonto.Text);

                factura= Funciones.Facturas.crearFactura(factura);

                if (factura.IdPersona != null)
                {
                    MessageBox.Show("Factura: "+ factura.Id+" Registrada con exito");                    
                    llenarGrid();
                    limpiarcambios();
                }
                else
                {
                    MessageBox.Show("Hubo un error al cargar la factura");
                    limpiarcambios();
                }


            }
            else
            {
                MessageBox.Show("Seleccione a una persona");
            }


        }
        private void seleccionarPersona(object sender, SelectionChangedEventArgs e)
        {
            llenarGrid();
        }

        private bool validacion()
        {
            
            Regex val = new Regex(@"^[0-9]+([.][0-9]+)?$");
            if (!val.IsMatch(txtMonto.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void limpiarcambios()
        {
            txtMonto.Text = "";
            cboPersonas.SelectedIndex= 0;
        }

        private void llenarGrid()
        {
            if (Convert.ToInt16(cboPersonas.SelectedIndex) > 0)
            {
                int index = cboPersonas.SelectedIndex - 1;
                List<Factura> list = Funciones.Facturas.GetFacturas(personas[index].Id);
                gdrFacturas.ItemsSource = list;
            }
        }

        private void validaTexto(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
