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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetechnologiesMxFront
{
    /// <summary>
    /// Lógica de interacción para Personas.xaml
    /// </summary>
    public partial class Personas : Page
    {
        List<Persona> personas = new List<Persona>();
        public Personas()
        {
            InitializeComponent();
            llenarGrid();
            llenarCombo();
            llenarComboIdentificacion();            
            limpiarCampos();
            cboPersonas.SelectedIndex = 0;
            cboIdentificacion.SelectedIndex = 0;    
        }

        private void llenarComboIdentificacion()
        {
            cboIdentificacion.Items.Insert(0, "Credencial");
            cboIdentificacion.Items.Insert(1, "CURP");
            cboIdentificacion.Items.Insert(2, "Cartilla Militar");
            cboIdentificacion.Items.Insert(3, "Licencia");


        }

        private void llenarGrid(int idPersona = 0)
        {
            
            if (idPersona == 0)
            {
                personas = Funciones.Personas.getPersonas();
                gdPersonas.ItemsSource = personas;
            }
            else
            {
                if (Convert.ToInt16(cboPersonas.SelectedIndex) > 0)
                {
                    int index = cboPersonas.SelectedIndex - 1;
                    Persona per = Funciones.Personas.getPersonasByID(personas[index].Id);
                    List<Persona> list = new List<Persona>();
                    list.Add(per);
                    gdPersonas.ItemsSource = list;
                }
                else
                {
                    gdPersonas.ItemsSource = personas;
                }

            }
        }

        private void llenarCombo()
        {
            cboPersonas.Items.Clear();
            cboPersonas.Items.Insert(0, "Todos");
            for (int i = 0; i < personas.Count; i++)
            {
                string nombre = personas[i].Nombre + personas[i].ApellidoPaterno;
                cboPersonas.Items.Insert(i + 1, nombre);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validaciones())
            {
                Persona persona = new Persona();
                persona.Nombre =txtNombre.Text;
                persona.ApellidoPaterno = txtApellido.Text;
                persona.ApellidoMaterno=txtApellidoMaterno.Text;                
                persona.Identificacion = cboIdentificacion.SelectedValue.ToString();
                persona=Funciones.Personas.crearPersona(persona);
                if (persona.Nombre != null)
                {                                
                    llenarGrid();
                    llenarCombo();
                    limpiarCampos();
                    MessageBox.Show("La persona con el ID: " + persona.Id+ " Ha sido registrada");
                }
                else
                {
                    MessageBox.Show("La persona no se pudo registrar");
                }
            }
            else
            {
                MessageBox.Show("Hace Falta un campo obligatorio...");
            }
        }

        public bool validaciones()
        {
            if (txtNombre.Text.Equals("") &&
                txtApellido.Text.Equals("") &&
                Convert.ToInt16(cboPersonas.SelectedIndex) < 0) return false;
            else return true;
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtApellidoMaterno.Text = "";
            cboIdentificacion.SelectedIndex = 0;
            cboPersonas.SelectedIndex = 0;
        }

        private void cboPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToInt16(cboPersonas.SelectedIndex) > 0)
            {
                llenarGrid(Convert.ToInt16(cboPersonas.SelectedIndex));
            }
            else
            {
                llenarGrid();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Persona a= new Persona();
            if (gdPersonas.SelectedIndex > 0)
            {
                if (gdPersonas.SelectedIndex <= personas.Count)
                {
                    int index = gdPersonas.SelectedIndex;
                    Persona per = Funciones.Personas.eliminarPersonaById(personas[index].Id);
                    if (per.Nombre!=null)
                    {
                        llenarGrid();
                        llenarCombo();
                        limpiarCampos();
                        MessageBox.Show("La persona con el id: " + per.Id + " Ha sido eliminada con exito");
                    }
                    else
                    {
                        MessageBox.Show("Hubo un erro al eliminar a al pesona...");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un valor existente");
                }
            }

        }
    }
}
