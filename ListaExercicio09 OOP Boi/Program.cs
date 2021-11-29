using System;
using System.Collections.Generic;
using System.IO;

namespace ListaExercicio09_OOP_Boi
{
    internal class Program
    {
        static void Main(string[] args)
        {


            ListaBoi listaBoi = new ListaBoi();
            var boi = listaBoi.LerArquivo1();

            Racas listaRaca = new Racas();
            var raca = listaRaca.LerArquivo2();

            Preco preco = new Preco();


            Console.WriteLine();
            Console.WriteLine(preco.CalculaPreco(boi, raca));


            preco.SalvarArquivo(boi,raca);







        }
    }


    public class ListaBoi
    {
        public int Id { get; set; }
        public string Raca { get; set; }
        public decimal Pesagem { get; set; }
        public decimal FatorMultiplicacao { get; set; }

        public ListaBoi[] LerArquivo1()
        {
            var pathFile1 = Path.Combine(Directory.GetCurrentDirectory(), "ListaBoi.txt");
            var lines = File.ReadAllLines(pathFile1);

            int qnt = lines.Length;
            var boi = new ListaBoi[qnt - 1];

            var j = 0;

            for (int i = 1; i < qnt; i++)
            {
                var valor = lines[i].Split(';');



                boi[j] = new ListaBoi
                {
                    Id = (Convert.ToInt32(valor[0])),
                    Raca = valor[1],
                    Pesagem = (Convert.ToDecimal(valor[2])),
                    FatorMultiplicacao = (Convert.ToDecimal(valor[3]))
                };
                j++;

            }
            return boi;



        }
    }


    public class Racas //lista 2
    {
        public string Raca { get; set; }
        public decimal PrecoArroba { get; set; }

        public Racas[] LerArquivo2()
        {
            var pathFile2 = Path.Combine(Directory.GetCurrentDirectory(), "ArquivoListaPreco.txt");
            var lines = File.ReadAllLines(pathFile2);

            var qnt = lines.Length;
            var raca = new Racas[qnt - 1];
            var j = 0;

            for (int i = 1; i < qnt; i++)
            {
                var valor = lines[i].Split(';');



                raca[j] = new Racas
                {
                    Raca = valor[0],
                    PrecoArroba = Convert.ToDecimal(valor[1])
                };

                j++;

            }
            return raca;

        }



    }
    public class Preco
    {
        private decimal _calculoPeso;

        public string nomeBoi(ListaBoi[] boi)
        {
            var nome = boi[1].Raca;
            return nome;
        }

        public decimal CalculaPreco(ListaBoi[] boi, Racas[] raca)
        {

            decimal peso;
            decimal preco;
            decimal fatorMult;

            List<decimal> valorPeso = new List<decimal>();


            Array.Sort(boi, delegate (ListaBoi x, ListaBoi y)
            {
                return x.Raca.CompareTo(y.Raca);

            });



            for (int i = 0; i < boi.Length; i++)
            {
                for (int j = 0; j < raca.Length; j++)
                {
                    if (boi[i].Raca == raca[j].Raca)
                    {
                        peso = boi[i].Pesagem;
                        preco = raca[i].PrecoArroba;
                        fatorMult = boi[i].FatorMultiplicacao;

                        decimal calculoPreco = (peso * preco * fatorMult);

                        _calculoPeso = calculoPreco;
                        Console.WriteLine("Raça: " + boi[i].Raca + "  Id: " + boi[i].Id + "  Preço: R$" + _calculoPeso);


                        valorPeso.Add(_calculoPeso);

                    }
                }
            }


            return _calculoPeso;

        }

        public void SalvarArquivo(ListaBoi[] boi, Racas[] raca)
        {
            var raca1 = Path.Combine(Directory.GetCurrentDirectory(), "RelatorioSimples1.txt");
            var raca2 = Path.Combine(Directory.GetCurrentDirectory(), "RelatorioSimples2.txt");
            var raca3 = Path.Combine(Directory.GetCurrentDirectory(), "RelatorioSimples3.txt");



            string[,] relatorio = new string[boi.Length, 4];
            List<string> listaNova = new List<string>();

            for (int i = 0; i < boi.Length; i++)
            {
                relatorio[i, 0] = boi[i].Raca;
                relatorio[i, 1] = (Convert.ToString(boi[i].Pesagem));
                relatorio[i, 2] = (Convert.ToString(raca[i].PrecoArroba));
                relatorio[i, 3] = (Convert.ToString(_calculoPeso));


            }

            for (int i = 0; i < boi.Length; i++)
            {
                string valor;

                

                if (relatorio[i, 0] == "Brahman")
                {
                    

                     valor = relatorio[i, 0] + "; "
                        + relatorio[i, 1] + "; "
                        + relatorio[i, 2] + "; "
                        + relatorio[i, 3];

                    File.WriteAllText(raca1, valor);
                    Console.WriteLine("Relatorio gerado: {0}", DateTime.Now.Date);
                }
                else if (relatorio[i, 0] == "Angus")
                {
                     valor = relatorio[i, 0] + "; "
                        + relatorio[i, 1] + "; "
                        + relatorio[i, 2] + "; "
                        + relatorio[i, 3];
                    File.WriteAllText(raca2, valor);
                    Console.WriteLine("Relatorio gerado: {0}", DateTime.Now.Date);
                }
                else if (relatorio[i, 0] == "Nelore")
                {
                     valor = relatorio[i, 0] + "; "
                        + relatorio[i, 1] + "; "
                        + relatorio[i, 2] + "; "
                        + relatorio[i, 3];
                    File.WriteAllText(raca3, valor);
                    Console.WriteLine("Relatorio gerado: {0}", DateTime.Now.Date);



                }




            }

        }















    }




}



