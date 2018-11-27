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
    /// Interaction logic for MenuConsulta.xaml
    /// </summary>
    public partial class MenuConsulta : Page
    {
        private readonly MainWindow mainWindow;
        public MenuConsulta(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
        }

        private void Voltar_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateToMenu();
        }

        private void ProcurarID_Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = new DataTable("Estoque");
            SqlDataAdapter dataAdapter = InterfaceBD.GetDataAdapter($"SELECT * FROM Estoque WHERE Id LIKE '%{Id_TextBox.Text}%'");
            dataAdapter.Fill(dataTable);
            Produto_DataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void ProcurarNome_Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = new DataTable("Estoque");
            SqlDataAdapter dataAdapter = InterfaceBD.GetDataAdapter($"SELECT * FROM Estoque WHERE Nome LIKE '%{Name_TextBox.Text}%'");
            dataAdapter.Fill(dataTable);
            Produto_DataGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}
