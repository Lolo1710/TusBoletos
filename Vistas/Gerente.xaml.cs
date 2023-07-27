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
    /// Lógica de interacción para Gerente.xaml
    /// </summary>
    public partial class Gerente : Window
    {
        public Gerente()
        {
            InitializeComponent();
        }

        private void btnAddUSer_Click(object sender, RoutedEventArgs e)
        {
            Sistema sistema = new Sistema();
            Close();
            sistema.Show();
        }

        private void btnAddEventos_Click(object sender, RoutedEventArgs e)
        {
            Eventos evento = new Eventos();
            Close();
            evento.Show();
        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            Ventas venta = new Ventas();
            Close();
            venta.Show();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Gerente gerente = new Gerente();
            gerente.Show();
            this.Close();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ejecutar = new MainWindow();
            ejecutar.Show();
            Close();
        }
    }
}
