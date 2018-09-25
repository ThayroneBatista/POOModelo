using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Modelo;
using System.Collections;
using System.Data;

namespace BLL
{
    public class ProdutoBLL
    {
        public ArrayList produtosEmFalta()
        {
            ProdutoDAL obj = new ProdutoDAL();
            return obj.produtosEmfalta();
        }

        public void incluir(Produto produto)
        {
            if (produto.nome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório.");
            }
            if (produto.preco < 0)
            {
                throw new Exception("O preço do produto não pode ser negativo.");
            }
            if (produto.estoque < 0)
            {
                throw new Exception("Estoque do produto não pode ser negativo.");
            }

            ProdutoDAL obj = new ProdutoDAL();
            obj.incluir(produto);
        }

        public void alterar(Produto produto)
        {
            ProdutoDAL obj = new ProdutoDAL();
            obj.alterar(produto);
        }

        public void excluir(int codigo)
        {
            ProdutoDAL obj = new ProdutoDAL();
            obj.excluir(codigo);
        }

        public DataTable listagem()
        {
            ProdutoDAL obj = new ProdutoDAL();
            return obj.listagem();
        }
    }
}
