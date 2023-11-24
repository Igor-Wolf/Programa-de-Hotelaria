using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Programa_de_Hotelaria.Models;

Pessoas p1 = new Pessoas();
dynamic auxiliar = 0;
string escolhaSuite = ""; 
decimal valorSuite=0.0M;




//---------------------------------------------------------- FUNÇÕES AUXILIARES

bool verificarInteiro(){
    
    try{

        auxiliar = Convert.ToInt32(auxiliar);
        return true;

    }
    catch{

        return false;

    }
      
}

void cabecalho(){

    Console.WriteLine("----------------------------------------------------------------------------------------");
}

void limpatela(){

    Console.WriteLine("\n\nPressione qulquer tecla para continuar...");
    Console.ReadLine();
    Console.Clear();

}

    
//---------------------------------------------------------- CABEÇALHOS


void menu1(){

    cabecalho();
    Console.WriteLine("                                 CADASTRAR HOSPEDES");
    cabecalho();

}

void menu2(){

    cabecalho();
    Console.WriteLine("                                 CADASTRAR SUITES");
    cabecalho();

}
void menu3(){

    cabecalho();
    Console.WriteLine("                                 REALIZAR RESERVA");
    cabecalho();

}
void menu4(){

    cabecalho();
    Console.WriteLine("                                 RECIBO DE HOSPEDAGEM");
    cabecalho();

}


//------------------------------------------------------------------------------------------------------------------------ PROGRAMA PRINCIPAL
limpatela();
//---------------------------------------------------------- CADASTRA HOSPEDES

while(true){

    menu1();
    Console.WriteLine("Seja bem vindo ao reserva de vagas Online do Hotel Boa Vista\n\nDeseja realizar o cadastro de novos hospedes? [S] [N]");
    auxiliar = Console.ReadLine();
    limpatela();

    if (auxiliar=="S" || auxiliar=="s"){
        menu1();
        p1.adicionarPessoa();

    }
    else if (auxiliar=="N" || auxiliar=="n"){        
        break;
    }
    else{
        menu1();
        Console.WriteLine("Valor inválido");
    }
    limpatela();
    
}

//---------------------------------------------------------- CADASTRA SUÍTE

while (true)
{
    menu2();
    Console.WriteLine("Em qual tipo de suite deseja se hopedar?\n");
    Console.WriteLine("1 - Premium   R$30.00 por diária por pessoa\n2 - Plus      R$50.00 por diária por pessoa\n3 - Master    R$80.00 por diária por pessoa\n");
    auxiliar = Console.ReadLine();

    verificarInteiro();
    
    if(auxiliar== 1 || auxiliar== 2 || auxiliar==3){
        

        switch (auxiliar)
        {
            case 1:
                escolhaSuite = "Premium";
                valorSuite = 30.00M;
                break;
            case 2:
                escolhaSuite = "Plus";
                valorSuite = 50.00M;
                break;
            case 3:
                escolhaSuite = "Master";
                valorSuite = 80.00M;
                break;
        }
        limpatela();
        break;
    }
    else{

        Console.WriteLine("Digite um valor numérico válido");

    }
    limpatela();
}
while(true){
    menu2();
    Console.WriteLine("Confirme a quantidade de pessoas hospedadas:");
    auxiliar=Console.ReadLine();
    verificarInteiro();

    if (auxiliar.GetType() != typeof(int)){

        Console.WriteLine("Digite um valor numérico");
    }
    else if (auxiliar!= p1.tamanhoDaLista()){

        Console.WriteLine("Valor incompativel com a quantidade de pessoas registradas");

    }
    else{
               
        limpatela();
        break;
    }
    limpatela();
}

Suite suite = new Suite(tipoSuite: escolhaSuite, capacidade: auxiliar, valorDiaria: valorSuite);


//---------------------------------------------------------- REALIZAR A RESERVA

while (true){

    menu3();
    Console.WriteLine("Digite a quantidade de dias hospedados");
    auxiliar=Console.ReadLine();
    verificarInteiro();

    if (auxiliar.GetType() != typeof(int)){

        Console.WriteLine("Digite um valor numérico");
    }
    else{

        limpatela();
        break;
    }
    limpatela();    
}

Reserva reserva = new Reserva(diasReservados: auxiliar);
reserva.CadastrarSuite(suite);

//---------------------------------------------------------- MOSTRAR DADOS CADASTRADOS NA TELA

menu4();
Console.WriteLine("Os hospedes registrados são:\n");
p1.listarNaTela();
Console.WriteLine($"O tipo de suite escolhida foi {suite.TipoSuite} com capacidade para {suite.Capacidade} pessoas e com diárias de R${suite.ValorDiaria}");
Console.WriteLine(reserva.retornoDEValorAPagar());
DateTime data = DateTime.Now;
Console.WriteLine($"Operação realizada no dia {data} {TimeZoneInfo.Local.DisplayName}");

limpatela();
Console.WriteLine("Recibo impresso em .txt");


//---------------------------------------------------------- IMPRIMIR RECIBO EM .TXT

List<string> save =
[
    "----------------------------------------------------------------------------------------------",
    "                                 RECIBO DE HOSPEDAGEM",
    "----------------------------------------------------------------------------------------------",
    
];
save.Add("Os hospedes registrados são:");
save.Add("");
foreach(string item in p1.retornarValor()){

                save.Add(item);

            }
save.Add("");
save.Add($"O tipo de suite escolhida foi {suite.TipoSuite} com capacidade para {suite.Capacidade} pessoas e com diárias de R${suite.ValorDiaria}");
save.Add(reserva.retornoDEValorAPagar());
save.Add("");
save.Add($"Operação realizada no dia {data} {TimeZoneInfo.Local.DisplayName}");

File.AppendAllLines("save.txt", save);
// File.WriteAllLines("save.txt", save);
