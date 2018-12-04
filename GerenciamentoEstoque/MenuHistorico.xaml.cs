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
using System.Data.SqlClient;
using System.Data;

namespace GerenciamentoEstoque
{
    /// <summary>
    /// Interaction logic for MenuHistorico.xaml
    /// </summary>
    public partial class MenuHistorico : Page
    {
        private readonly MainWindow mainWindow;
        public MenuHistorico(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
            DataTable dataTable = new DataTable("Estoque");
            SqlDataAdapter dataAdapter = InterfaceBD.GetDataAdapter($"SELECT * FROM Historico");
            dataAdapter.Fill(dataTable);
            Produto_DataGrid.ItemsSource = dataTable.DefaultView;

        }

        private void Voltar_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateToMenu();
        }
    }
}
