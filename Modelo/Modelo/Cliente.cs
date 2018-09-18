using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Cliente
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
        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _telefone;

        public string telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

    }
}
