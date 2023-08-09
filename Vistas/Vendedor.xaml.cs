using Microsoft.EntityFrameworkCore;
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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectotTUSBOLETOS.Vistas
{
    /// <summary>
    /// Lógica de interacción para Vendedor.xaml
    /// </summary>
    public partial class Vendedor : Window
    {
        decimal total = 0;
        int IDEvento = 0;

        VendedorServices vendedor = new VendedorServices();

        public Vendedor()
        {
            InitializeComponent();
            GetEvents();
            Saludo();
            Bienvenida();
        }

        private void Saludo()
        {
            string saludo = vendedor.Saludo();
            lblBienvenida.Content = saludo;
        }

        public void GetEvents()
        {
            List<Evento> list = vendedor.GetEventos();

            List<Evento> eventosConAsientos = list.Where(evento => evento.Asientos > 0).ToList();

            Eventos.ItemsSource = eventosConAsientos;
        }

        public void Seleccionar(object sender, RoutedEventArgs e)
        {
            Evento evento = new Evento();
            evento = (sender as FrameworkElement).DataContext as Evento; //Esta funcion traera la selecion de la fila 

            IDEvento = int.Parse(evento.PkEvento.ToString());
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (IDEvento != 0) 
            {
                if (!string.IsNullOrEmpty(txtCantidad.Text))
                {
                    int cantidad = int.Parse(txtCantidad.Text);
                    total = vendedor.Calcular(IDEvento, cantidad);
                    txtPrecio.Text = total.ToString();
                }
                else
                {
                    MessageBox.Show("Por favor ingresa la cantidad de boletos a cotizar");
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un evento antes de calcular");
            }
        }

        private void btnEmitir_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCantidad.Text) && !string.IsNullOrEmpty(txtPrecio.Text))
            {
                int cantidad = int.Parse(txtCantidad.Text);
                vendedor.Ordenar(IDEvento, cantidad, total);

                GetEvents();

                txtCantidad.Clear();
                txtPrecio.Clear();
            }
            else
            {
                MessageBox.Show("Ingresa la cantidad de boletos y verifica que tenga un precio asignado, de lo contrario comunicate con el gerente");
            }
        }
        public void ventacompleta()
        {
            MessageBox.Show("Se registro la venta correctamente");
        }

        public void ventaincompleta()
        {
            MessageBox.Show("No hay suficientes asientos para realizar la venta");
        }

        public void sinAsientos()
        {
            MessageBox.Show("No quedan asientos disponibles");
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow vendedor = new MainWindow ();
            vendedor.Show();
            this.Close();
        }

        private void Bienvenida()
        {
            Usuario usuario = new Usuario();
            int id = Auth.Authentication.PkUser;
            using (var _context = new ApplicationDbContext())
            {
                usuario = _context.Usuarios.Find(id);
            }
            lblBienvenida.Content = $"Bienvenido {usuario.Nombre}";
        }

        private void Eventos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
