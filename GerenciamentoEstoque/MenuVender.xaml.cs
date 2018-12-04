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
            string cliente = "";
            SqlDataReader dataReader = InterfaceBD.GetDatareader("SELECT * FROM Clientes");
            bool found = false;
            while (dataReader.Read())
            {
                cliente = Convert.ToString(dataReader["CPF"]).Trim();
                if (Cliente_TextBox.Text == cliente)
                {
                    found = true;
                }
            }

            dataReader.Close();
            if (!found)
            {
                MessageBox.Show("Cliente nao cadastrado");
            }
            else
            {
                if (Quantidade_TextBox.Text != "" && Convert.ToInt32(Quantidade_TextBox.Text) != 0)
                {
                    int sucess = InterfaceBD.SqlRunCommand($"UPDATE Estoque SET Quantidade=(Quantidade-{Convert.ToInt32(Quantidade_TextBox.Text)}) WHERE Nome='{Produto_TextBox.Text}'");
                    if (sucess > 0)
                    {
                        MessageBox.Show("Venda concluida com sucesso");
                        update_table();
                        dataReader = InterfaceBD.GetDatareader($"SELECT * FROM Estoque WHERE Nome='{Produto_TextBox.Text}'");
                        dataReader.Read();
                        int Id = Convert.ToInt32(dataReader["Id"]);
                        string Nome = Convert.ToString(dataReader["Nome"]);
                        double Preco = Convert.ToDouble(dataReader["Preco"]);
                        dataReader.Close();

                        InterfaceBD.SqlRunCommand($"INSERT INTO Historico (Id, Produto, Quantidade, Preco, CPF_Cliente) VALUES ('{Id}','{Nome}','{Quantidade_TextBox.Text}','{Preco}','{cliente}')");
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
