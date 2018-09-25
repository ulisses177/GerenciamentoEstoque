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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool LoginGerente { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            LoginGerente = false;
            MainFrame.NavigationService.Navigate(new MenuLogin(this));
        }

        public void Navigate(Page page)
        {
            MainFrame.NavigationService.Navigate(page);
        }

        public void NavigateToMenu()
        {
            if (LoginGerente)
                Navigate(new MenuGerente(this));
            else
                Navigate(new MenuVendedor(this));
        }
    }
}
