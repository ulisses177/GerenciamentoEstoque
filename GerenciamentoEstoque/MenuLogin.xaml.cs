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

namespace GerenciamentoEstoque
{
    /// <summary>
    /// Interaction logic for LoginMenu.xaml
    /// </summary>
    public partial class MenuLogin : Page
    {
        private readonly MainWindow mainWindow;
        public MenuLogin(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            SqlDataReader dataReader = InterfaceBD.GetDatareader("SELECT * FROM Login");
            bool founduser = false;
            bool found = false;
            while (dataReader.Read())
            {
                string user = Convert.ToString(dataReader["User"]);
                user = user.Trim();
                if (Login_TextBox.Text == user)
                {
                    founduser = true;
                    string password = Convert.ToString(dataReader["Password"]);
                    password = password.Trim();

                    if (Senha_TextBox.Password == password)
                    {
                        found = true;
                        mainWindow.LoginGerente = Convert.ToBoolean(dataReader["IsAdmin"]);
                        mainWindow.NavigateToMenu();
                    }
                }
            }

            if (!founduser)
            {
                MessageBox.Show("Usuario nao encontrado");
            }
            if (founduser && !found)
            {
                MessageBox.Show("Senha invalida");
            }

            dataReader.Close();
        }
    }
}
