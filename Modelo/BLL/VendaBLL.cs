using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DAL;
using System.Data;
namespace BLL
{
    public class VendaBLL
    {
        private VendaDAL objDAL;

        public VendaBLL()
        {
            objDAL = new VendaDAL();
        }

        public DataTable listaDeProdutos
        {
            get
            {
                return objDAL.listaDeProdutos;
            }
        }

        public void excluir(int cod)
        {
            ProdutoDAL obj = new ProdutoDAL();
            obj.excluir(cod);
        }

        public DataTable listaDeClientes
        {
            get
            {
                return objDAL.listaDeClientes;
            }
        }

        public void incluir(Venda venda)
        {
            objDAL.incluir(venda);
        }
    }
}
