using Microsoft.EntityFrameworkCore;
using ProyectotTUSBOLETOS.Context;
using ProyectotTUSBOLETOS.Services;
using ProyectotTUSBOLETOS.Vistas;
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

namespace ProyectotTUSBOLETOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        UsuarioServices services = new UsuarioServices();
        VendedorServices ventas = new VendedorServices();

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUserName.Text;
            string password = txtPassword.Password;

            var response = services.Login(user, password);
            //ventas.PasarDatos(response);

            //MessageBox.Show($"{response.Nombre} {response.PkUsuario}");

            if(response != null)
            {
                if (response.Roles.Nombre == "Super Admin")
                {
                    Gerente inicio = new Gerente();
                    Close();
                    inicio.Show();
                }
                else
                {
                    Vendedor inicio = new Vendedor();
                    Close();
                    inicio.Show();
                }
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
                txtPassword.Clear();    
                txtUserName.Clear();
            }
        }
    }
}
