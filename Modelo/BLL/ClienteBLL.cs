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
    public class ClienteBLL
    {
        public void incluir(Cliente cliente)
        {
            if (cliente.nome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente é obrigatório");
            }

            cliente.email = cliente.email.ToLower();

            ClienteDAL obj = new ClienteDAL();
            obj.incluir(cliente);

        }

        public void alterar(Cliente cliente)
        {
            ClienteDAL obj = new ClienteDAL();
            obj.alterar(cliente);
        }
        public void excluir(int codigo) 
        {
            if (codigo < 1)
            {
                throw new Exception("Selecione um cliente antes de excluí-lo ");
            }
            ClienteDAL obj = new ClienteDAL();
        }
        public DataTable listagem()
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.listagem();
        }
    }
}
