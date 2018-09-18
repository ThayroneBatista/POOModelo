using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

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
    }
}
