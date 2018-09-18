using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    class Produto
    {
        private int _codigo;

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _nome;

        public string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private decimal _preco;

        public decimal preco
        {
            get { return _preco; }
            set { _preco = value; }
        }
        private int _estoque;

        public int estoque
        {
            get { return _estoque; }
            set { _estoque = value; }
        }
    }
}
