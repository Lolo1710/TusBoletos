using ProyectotTUSBOLETOS.Context;
using ProyectotTUSBOLETOS.Entities;
using ProyectotTUSBOLETOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectotTUSBOLETOS.Vistas
{
    /// <summary>
    /// Lógica de interacción para Eventos.xaml
    /// </summary>
    public partial class Eventos : Window
    {
        public Eventos()
        {
            InitializeComponent();
            GetUserTable();
        }

        EventosServices eventos = new EventosServices();

        private void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtAsientos.Clear();
            txtPrecio.Clear();
            dateInput.SelectedDate = null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Evento evento = new Evento();
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtAsientos.Text) && !string.IsNullOrEmpty(txtPrecio.Text) && dateInput.SelectedDate != null)
            {
                if (txtID.Text == "")
                {
                    evento.Nombre = txtNombre.Text;
                    evento.Descripcion = txtDescripcion.Text;
                    evento.Asientos = int.Parse(txtAsientos.Text);
                    evento.Fecha = dateInput.SelectedDate.Value;
                    evento.Precio = int.Parse(txtPrecio.Text);
                    eventos.AddEvent(evento);

                    Limpiar();

                    MessageBox.Show("Se agrego correctamente");
                    GetUserTable();
                }
                else
                {
                    evento.PkEvento = int.Parse(txtID.Text);
                    evento.Nombre = txtNombre.Text;
                    evento.Descripcion = txtDescripcion.Text;
                    evento.Fecha = dateInput.SelectedDate.Value;
                    evento.Asientos = int.Parse(txtAsientos.Text);
                    evento.Precio = decimal.Parse(txtPrecio.Text);

                    eventos.UpdateEvent(evento);

                    Limpiar();

                    MessageBox.Show("Se actualizo correctamente");
                    GetUserTable();
                }
            }
            else
            {
                MessageBox.Show("Faltan datos por agregar");
            }
        }

        public void GetUserTable()
        {
            EventTable.ItemsSource = eventos.GetEventos();
        }

        public void EditItem(object sender, RoutedEventArgs e)
        {
            Evento evento = new Evento();
            evento = (sender as FrameworkElement).DataContext as Evento; //Esta funcion traera la selecion de la fila 

            txtID.Text = evento.PkEvento.ToString();
            txtNombre.Text = evento.Nombre.ToString();
            txtDescripcion.Text = evento.Descripcion.ToString();
            txtAsientos.Text = evento.Asientos.ToString();
            dateInput.SelectedDate = evento.Fecha;
            txtPrecio.Text = evento.Precio.ToString();
        }

        public void Delete(object sender, RoutedEventArgs e)
        {
            using (var _context = new ApplicationDbContext())
            {
                Evento evento = new Evento();
                EventosServices services = new EventosServices();
                evento = (sender as FrameworkElement).DataContext as Evento;
                evento.PkEvento.ToString();
                services.DeleteEvent(evento);

                MessageBox.Show("Se elimino el usuario");
                GetUserTable();
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Gerente gerente = new Gerente();
            gerente.Show();
            this.Close();
        }

        private void EventTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
