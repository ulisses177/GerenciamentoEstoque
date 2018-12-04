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
    /// Interaction logic for MenuExcluir.xaml
    /// </summary>
    public partial class MenuExcluir : Page
    {
        private readonly MainWindow mainWindow;
        public MenuExcluir(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
        }

        private void Voltar_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateToMenu();
        }

        private void Excluir_Button_Click(object sender, RoutedEventArgs e)
        {
            int sucess = Convert.ToInt32(InterfaceBD.SqlRunCommand($"DELETE FROM Estoque WHERE Nome='{Produto_TextBox.Text}'"));
            if(sucess > 0)
                MessageBox.Show($"Produto \"{Produto_TextBox.Text}\" excluido com sucesso");
            else
                MessageBox.Show($"Produto \"{Produto_TextBox.Text}\" nao encontrado");
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
