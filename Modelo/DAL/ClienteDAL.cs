using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Modelo;
using System.Data;

namespace DAL
{
    public class ClienteDAL
    {
        public void incluir(Cliente cliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.stringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into clientes (nome, email, telefone) values (@nome, @email, @telefone); select @@IDENTITY";
                cmd.Parameters.AddWithValue("@nome", cliente.nome);
                cmd.Parameters.AddWithValue("@email", cliente.email);
                cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
                cn.Open();
                cliente.codigo = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void alterar(Cliente cliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.stringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "update clientes set nome = @nome, email = @email, telefone = @telefone where codigo = @codigo";
                cmd.Parameters.AddWithValue("@codigo", cliente.codigo);
                cmd.Parameters.AddWithValue("@nome", cliente.nome);
                cmd.Parameters.AddWithValue("@email", cliente.email);
                cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
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
                cmd.CommandText = "delete from clientes where codigo = @codigo";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("Não foi possível excluir o cliente " + codigo);
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
            SqlDataAdapter da = new SqlDataAdapter("select * from clientes", Dados.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
    }
}
