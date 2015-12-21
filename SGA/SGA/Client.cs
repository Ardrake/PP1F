using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA
{
    public class Client
    {
        private string nomClient = "";
        private string nipClient = "";

        public string NomClient
        {
            get { return nomClient; }
        }

        public string NIP
        {
            get { return nipClient; }
        }

        public Client(string Nom, string NIP)
        {
            nomClient = Nom;
            nipClient = NIP;
        }

        public override string ToString()
        {
            return string.Format("nom client: {0}", nomClient);
        }
    }
}
