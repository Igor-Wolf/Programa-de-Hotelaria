using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programa_de_Hotelaria.Models
{

    public class Reserva
    {
        public Reserva (int diasReservados){

            DiasReservados = diasReservados;

        }

        public int DiasReservados { get; set; }
        public Suite Suite { get; set; }



        public void CadastrarSuite (Suite suite){


            Suite = suite;

        }

        public string retornoDEValorAPagar(){


            if (DiasReservados >= 10)
            {

                return $"O valor a ser pago ao final é de R${Math.Round(DiasReservados * Suite.ValorDiaria * Suite.Capacidade * 0.90M, 2)} com o desconto de 10%";
            }
            else
            {

                return $"O valor a ser pago ao final é de R${Math.Round(DiasReservados * Suite.ValorDiaria * Suite.Capacidade, 2)}";
            }



        }

        
    }
}