using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Dados
    {
        private string _stringDeConexao  = "Data Source=DESKTOP-TB0OPVD;Initial Catalog=BDBiblio;Integrated Security=SSPI";

        public string stringDeConexao
        {
            get { return _stringDeConexao; }
        }
    }
}
