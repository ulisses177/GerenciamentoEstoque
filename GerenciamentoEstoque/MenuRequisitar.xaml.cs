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
    /// Interaction logic for MenuRequisitar.xaml
    /// </summary>
    public partial class MenuRequisitar : Page
    {
        private readonly MainWindow mainWindow;
        public MenuRequisitar(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
        }
        private void Voltar_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateToMenu();
        }

        private void Requisitar_Button_Click(object sender, RoutedEventArgs e)
        {
            SqlDataReader dataReader = InterfaceBD.GetDatareader($"SELECT * FROM Fornecedor WHERE Nome='{Produto_TextBox.Text}'");
            if (dataReader.Read())
            {
                int Id = Convert.ToInt32(dataReader["Id"]);
                string Nome = Convert.ToString(dataReader["Nome"]);
                double Preco = Convert.ToDouble(dataReader["Preco"]);
                dataReader.Close();
                SqlDataReader dataReader2 = InterfaceBD.GetDatareader($"SELECT * FROM Estoque WHERE Nome='{Produto_TextBox.Text}'");
                if (dataReader2.Read())
                {
                    dataReader2.Close();
                    InterfaceBD.SqlRunCommand($"UPDATE Estoque SET Quantidade=(Quantidade+{Convert.ToInt32(Quantidade_TextBox.Text)}) WHERE Nome='{Produto_TextBox.Text}'");
                }
                else
                {
                    dataReader2.Close();
                    InterfaceBD.SqlRunCommand($"INSERT INTO Estoque (Id, Nome, Preco, Quantidade) VALUES ('{Id}','{Nome}', '{Preco}', '{Quantidade_TextBox.Text}' )");
                }
                MessageBox.Show("Pedido efetuado com sucesso");
            }
            else
            {
                MessageBox.Show("Produto nao disponivel pelo fornecedor");
                mainWindow.Navigate(new MenuCadastro(mainWindow));
                dataReader.Close();
            }
        }
        private void ProcurarID_Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = new DataTable("Estoque");
            SqlDataAdapter dataAdapter = InterfaceBD.GetDataAdapter($"SELECT * FROM Fornecedor WHERE Id LIKE '%{Id_TextBox.Text}%'");
            dataAdapter.Fill(dataTable);
            Produto_DataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void ProcurarNome_Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = new DataTable("Estoque");
            SqlDataAdapter dataAdapter = InterfaceBD.GetDataAdapter($"SELECT * FROM Fornecedor WHERE Nome LIKE '%{Name_TextBox.Text}%'");
            dataAdapter.Fill(dataTable);
            Produto_DataGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}
