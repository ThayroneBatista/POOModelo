using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    class Venda
    {
        private int _codigo;

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private DateTime _data;

        public DateTime data
        {
            get { return _data; }
            set { _data = value; }
        }

        private int _quantidade;

        public int quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        private bool _faturado;

        public bool faturado
        {
            get { return _faturado; }
            set { _faturado = value; }
        }

        private int _codigoCliente;

        public int codigoCliente
        {
            get { return _codigoCliente; }
            set { _codigoCliente = value; }
        }

        private int _codigoProduto;

        public int codigoProduto
        {
            get { return _codigoProduto; }
            set { _codigoProduto = value; }
        }

        private string _nomeCliente;

        public string nomeCliente
        {
            get { return _nomeCliente; }
            set { _nomeCliente = value; }
        }
    }
}
