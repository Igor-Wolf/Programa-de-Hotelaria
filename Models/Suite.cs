using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Programa_de_Hotelaria.Models
{
    public class Suite
    {
        
        public Suite(string tipoSuite, int capacidade, decimal valorDiaria) {

            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
            
        }
        public string TipoSuite { get; set; }
        public int Capacidade{ get; set; }
        public decimal ValorDiaria{ get; set; }

    }

}