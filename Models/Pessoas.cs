using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Programa_de_Hotelaria.Models
{
    public class Pessoas
    {
        List<string> nomecompleto = new List<string>();
        public void adicionarPessoa(){

            string nome = "";
            
            Console.WriteLine("Digite o nome da pessoa");
            nome = Console.ReadLine();
            nomecompleto.Add(nome);
        }

        public void listarNaTela(){


            foreach(string item in nomecompleto){

                Console.WriteLine(item);

            }

        }

        public int tamanhoDaLista(){

            return nomecompleto.Count;

        }
        public List<string> retornarValor(){
                   

            return nomecompleto;

        }

        
    }
}