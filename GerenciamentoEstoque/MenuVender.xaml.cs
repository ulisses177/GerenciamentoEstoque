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
    /// Interaction logic for MenuVender.xaml
    /// </summary>
    public partial class MenuVender : Page
    {
        private readonly MainWindow mainWindow;
        public MenuVender(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
                DataTable dataTable = new DataTable("Estoque");
                SqlDataAdapter dataAdapter = InterfaceBD.GetDataAdapter("SELECT * FROM Estoque");
                dataAdapter.Fill(dataTable);
                Produto_DataGrid.ItemsSource = dataTable.DefaultView;
        }
        private void Voltar_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateToMenu();
        }

        private void Vender_Button_Click(object sender, RoutedEventArgs e)
        {
            SqlDataReader dataReader = InterfaceBD.GetDatareader("SELECT * FROM Cliente");
            bool found = false;
            while (dataReader.Read())
            {
                string cliente = Convert.ToString(dataReader["Nome"]).Trim();
                if (Cliente_TextBox.Text == cliente)
                {
                    found = true;
                }
            }

            if (!found)
            {
                MessageBox.Show("Cliente nao cadastrado");
            }

            dataReader.Close();
        }

        private void Novo_Cliente_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Navigate(new MenuNovoCliente(mainWindow));
        }
    }
}
