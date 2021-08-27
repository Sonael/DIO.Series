using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpçãoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch(opcaoUsuario)
               {
                   case "1":
                    ListarSeries();
                    break;

                   case "2":
                    InserirSerie();
                    break;

                   case "3":
                   AtualizarSerie();
                   break;

                   case "4":
                   ExcluirSerie();
                   break;

                   case "5":
                   VisualisarSerie();
                   break;

                   case "C":
                   Console.Clear();
                   break;

                   default:
                   throw new ArgumentOutOfRangeException();

               }

               opcaoUsuario = ObterOpçãoUsuario();
           }

           Console.WriteLine("Obrigado por utilziar nossos serviços.");
           Console.ReadLine();
        }


        private static void VisualisarSerie()
        {
            ListarSeries();
            Console.WriteLine("Digite o Id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }


        private static void ExcluirSerie()
        {
            ListarSeries();
            Console.WriteLine("Digite o Id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Deseja realmente excluir esse filme?(S/n)");
            string resp = Console.ReadLine();

            if(resp.ToUpper() == "N")
            {
                Console.WriteLine("Ação cancelada");
            }
            else
            {
                repositorio.Exclui(indiceSerie);
            }

        }


        private static void AtualizarSerie()
        {
            ListarSeries();
            Console.WriteLine("Digite o Id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
            }

            Console.WriteLine("Digite o genero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de incio da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie SerieAtualizada = new Serie(indiceSerie,
            (Genero)entradaGenero,
            entradaTitulo,
            entradaDescricao,
            entradaAno);

            repositorio.Atualiza(indiceSerie,SerieAtualizada);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Lista de Séries: ");

            var lista = repositorio.Lista();

            if ( lista.Count == 0)
            {
                Console.WriteLine("Nehuma série cadastrada.");

                return;
            }

            foreach( var serie in lista)
            {
                var excluido = serie.retonaExcluido();
                Console.WriteLine($"#ID {serie.retonarId()}: - {serie.retornaTitulo()}{(excluido ? " - *Excluido*":"")}");
            }
            Console.WriteLine();
        }


        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
            }

            Console.WriteLine("Digite o genero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de incio da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.ProximoId(),
            (Genero)entradaGenero,
            entradaTitulo,
            entradaDescricao,
            entradaAno);
            repositorio.Insere(novaSerie);
        }


        private static string ObterOpçãoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Série ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
