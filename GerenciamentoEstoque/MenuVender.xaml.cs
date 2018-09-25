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
    /// Interaction logic for MenuVender.xaml
    /// </summary>
    public partial class MenuVender : Page
    {
        private readonly MainWindow mainWindow;
        public MenuVender(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
        }
        private void Voltar_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateToMenu();
        }

        private void Vender_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Cliente_TextBox.Text != "")
            {
                mainWindow.Navigate(new MenuNovoCliente(mainWindow));
            }
            else
            {

            }
        }
    }
}
