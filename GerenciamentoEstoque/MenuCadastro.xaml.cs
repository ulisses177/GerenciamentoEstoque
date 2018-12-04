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
    /// Interaction logic for MenuCadastro.xaml
    /// </summary>
    public partial class MenuCadastro : Page
    {
        private readonly MainWindow mainWindow;
        public MenuCadastro(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
        }

        private void Voltar_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateToMenu();
        }

        private void Cadastrar_Button_Click(object sender, RoutedEventArgs e)
        {
            InterfaceBD.SqlRunCommand($"INSERT INTO Estoque (Id, Nome, Preco, Quantidade) VALUES ('{Id_TextBox.Text}','{Nome_TextBox.Text}','{Preco_TextBox.Text}','{Quantidade_TextBox.Text}')");
            MessageBox.Show($"Produto \"{Nome_TextBox.Text}\" cadastrado");
        }
    }
}
