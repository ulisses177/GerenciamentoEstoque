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
using System.Data;
using System.Data.SqlClient;

namespace GerenciamentoEstoque
{
    /// <summary>
    /// Interaction logic for MenuNovoCliente.xaml
    /// </summary>
    public partial class MenuNovoCliente : Page
    {
        private readonly MainWindow mainWindow;
        public MenuNovoCliente(MainWindow window)
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
            string nome = Nome_TextBox.Text;
            string RG = RG_TextBox.Text;
            string CPF = CPF_TextBox.Text;
            string Telefone = Telefone_TextBox.Text;

            if (nome == "")
            {
                MessageBox.Show("campo nome invalido");
            }
            else if (RG == "")
            {
                MessageBox.Show("campo RG invalido");
            }
            else if (CPF == "")
            {
                MessageBox.Show("campo CPF invalido");
            }
            else if (Telefone == "")
            {
                MessageBox.Show("campo telefone invalido");
            }
            else
            {
                InterfaceBD.SqlRunCommand($"INSERT INTO Cliente (Nome, RG, CPF, Telefone) VALUES ('{nome}','{RG}','{CPF}','{Telefone}')");
                MessageBox.Show($"Cliente \"{nome}\" cadastrado");
                mainWindow.Navigate(new MenuVender(mainWindow));
            }
        }
    }
}
