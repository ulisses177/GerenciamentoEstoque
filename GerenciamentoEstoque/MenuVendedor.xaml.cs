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

namespace GerenciamentoEstoque
{
    /// <summary>
    /// Interaction logic for MenuVendedor.xaml
    /// </summary>
    public partial class MenuVendedor : Page
    {
        private readonly MainWindow mainWindow;
        public MenuVendedor(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Navigate(new MenuLogin(mainWindow));
        }

        private void Consultar_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Navigate(new MenuConsulta(mainWindow));
        }

        private void Vender_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Navigate(new MenuVender(mainWindow));
        }

        private void NovoCliente_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Navigate(new MenuNovoCliente(mainWindow));
        }
    }
}
