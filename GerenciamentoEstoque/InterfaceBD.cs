using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GerenciamentoEstoque
{
    static class InterfaceBD
    {
        //TABELAS:
        //    LOGIN GERENTES/VENDEDORES
        //    PRODUTOS NO ESTOQUE
        //    PRODUTOS DO FORNECEDOR
        //    CLIENTES
        //    HISTORICO DE COMPRAS
        static public SqlConnection SQLconnection { get; set; }
        static public void inicializar()
        {
            SQLconnection = new SqlConnection(Properties.Settings.Default.Connection_String);
            try
            {
                SQLconnection.Open();
            }
            catch (SqlException ex)
            {
                string erro = ex.Message;
                System.Windows.Application.Current.Shutdown();
            }
        }
        static InterfaceBD()
        {

        }
        static public SqlDataReader GetDatareader(string Command)
        {
            SqlCommand command = new SqlCommand(Command, SQLconnection);
            SqlDataReader dataReader = command.ExecuteReader();
            return dataReader;
        }
        static public SqlDataAdapter GetDataAdapter(string Command)
        {
            SqlCommand command = new SqlCommand(Command, SQLconnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            return dataAdapter;
        }
        static public int SqlRunCommand(string Command)
        {
            SqlCommand command = new SqlCommand(Command, SQLconnection);
            return command.ExecuteNonQuery();
        }
        static public bool conectar()
        {
            return true;
        }
        static public void buscar()
        {

        }
        static public void excluir()
        {

        }
        static public void cadastrar()
        {

        }
        static public void atualizar()
        {

        }
    }
}
