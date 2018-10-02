using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace DAL
{
    public class ProdutoDAL
    {
        public void incluir(Produto produto)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.stringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into produtos (nome, preco, estoque) values (@nome, @preco, @estoque); select @@IDENTITY";
                cmd.Parameters.AddWithValue("@nome", produto.nome);
                cmd.Parameters.AddWithValue("@preco", produto.preco);
                cmd.Parameters.AddWithValue("@estoque", produto.estoque);
                cn.Open();
                produto.codigo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public void alterar(Produto produto)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.stringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "update produtos set nome = @nome, preco = @preco, estoque = @estoque where codigo = @codigo";
                cmd.Parameters.AddWithValue("@codigo", produto.codigo);
                cmd.Parameters.AddWithValue("@nome", produto.nome);
                cmd.Parameters.AddWithValue("@preco", produto.preco);
                cmd.Parameters.AddWithValue("@estoque", produto.estoque);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public void excluir(int codigo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.stringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from produtos where codigo = @codigo";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("Não foi possível excluir o produto " + codigo);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable listagem()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from produtos", Dados.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable produtosEmfalta()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from produtos where estoque = 0", Dados.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
    }
}
