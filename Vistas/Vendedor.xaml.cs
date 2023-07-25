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
            GetUserTable();
            Saludo();
        }

        private void Saludo()
        {
            string saludo = vendedor.Saludo();
            lblBienvenida.Content = saludo;
        }

        public void GetUserTable()
        {
            Eventos.ItemsSource = vendedor.GetEventos();
        }

        public void Seleccionar(object sender, RoutedEventArgs e)
        {
            Evento evento = new Evento();
            evento = (sender as FrameworkElement).DataContext as Evento; //Esta funcion traera la selecion de la fila 

            IDEvento = int.Parse(evento.PkEvento.ToString());
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            int cantidad = int.Parse(txtCantidad.Text);
            total = vendedor.Calcular(IDEvento, cantidad);
            txtPrecio.Text = total.ToString();
        }

        private void btnEmitir_Click(object sender, RoutedEventArgs e)
        {
            int cantidad = int.Parse(txtCantidad.Text);
            vendedor.Ordenar(IDEvento, cantidad, total);

            MessageBox.Show("Se registro la venta correctamente");

            txtCantidad.Clear();
            txtPrecio.Clear();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            Gerente gerente = new Gerente();
            gerente.Show();
            this.Close();
        }
    }
}
