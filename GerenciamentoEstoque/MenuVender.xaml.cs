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
            update_table();
        }
        private void update_table()
        {
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
            SqlDataReader dataReader = InterfaceBD.GetDatareader("SELECT * FROM Clientes");
            bool found = false;
            while (dataReader.Read())
            {
                string cliente = Convert.ToString(dataReader["Nome"]).Trim();
                if (Cliente_TextBox.Text == cliente)
                {
                    found = true;
                }
            }

            dataReader.Close();
            InterfaceBD.SqlRunCommand("")
            if (!found)
            {
                MessageBox.Show("Cliente nao cadastrado");
            }
            else
            {
                if (Quantidade_TextBox.Text != "" && Convert.ToInt32(Quantidade_TextBox.Text) != 0)
                {
                    bool sucess = Convert.ToBoolean(InterfaceBD.SqlRunCommand($"UPDATE Estoque SET Quantidade=(Quantidade-{Convert.ToInt32(Quantidade_TextBox.Text)}) WHERE Nome='{Produto_TextBox.Text}'"));
                    if (sucess)
                    {
                        MessageBox.Show("Venda concluida com sucesso");
                        update_table();
                    }
                    else
                    {
                        MessageBox.Show("produto nao encontrado");
                    }
                }
                else
                {
                    MessageBox.Show("quantidade invalida");
                }
            }
        }

        private void Novo_Cliente_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Navigate(new MenuNovoCliente(mainWindow));
        }
    }
}
