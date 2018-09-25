using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Modelo;

namespace DAL
{
    public class VendaDAL
    {
        public DataTable listaDeProdutos
        {
            get
            {
                SqlConnection cn = new SqlConnection(Dados.stringDeConexao);
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("dbo.prSelectAllProdutos", cn);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                cn.Close();
                return tabela;
            }
        }

        public DataTable listaDeClientes
        {
            get 
            {
                SqlConnection cn = new SqlConnection(Dados.stringDeConexao);
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("dbo.prSelectAllClientes", cn);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                cn.Close();
                return tabela;
            }
        }

        public void incluir(Venda venda) 
        {
            SqlConnection con = new SqlConnection();
            SqlTransaction t = null;
            try
            {
                con.ConnectionString = Dados.stringDeConexao;
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandText = @"insert into vendas (CodigoCliente, CodigoProduto, Data, Quantidade, Faturado) values " + 
                                     "(@codigoCliente, @codigoProduto, @data, @quantidade, @faturado);" +
                                        "select @@Identity;";

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandText = @"update produtos set estoque = estoque - @quantidade;";

                con.Open();

                t = con.BeginTransaction(IsolationLevel.Serializable);
                cmd1.Transaction = t;
                cmd2.Transaction = t;

                cmd1.Parameters.AddWithValue("@codigoCliente", venda.codigoCliente);
                cmd1.Parameters.AddWithValue("@codigoProduto", venda.codigoProduto);
                cmd1.Parameters.AddWithValue("@data", venda.data);
                cmd1.Parameters.AddWithValue("@quantidade", venda.quantidade);
                cmd1.Parameters.AddWithValue("@faturado", venda.faturado);
                cmd2.Parameters.AddWithValue("@codigoProduto", venda.codigoProduto);
                cmd2.Parameters.AddWithValue("@quantidade", venda.quantidade);

                venda.codigo = Convert.ToInt32(cmd1.ExecuteScalar());
                cmd2.ExecuteNonQuery();
                t.Commit();

            }
            catch (Exception ex)
            {
                t.Rollback();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
