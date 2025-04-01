namespace JogoCorridaDeDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int LIMITELINHACHEGADA = 30;

            while (true)
            {
                int posicaoUsuario = 0, posicaoComputador = 0;
                bool jogoEmAndamento = true;

                do
                {
                    //Cabeçalho
                    ExibirCabeçalho();

                    //Sorteio do lançamento do dado
                    int resultado = SorteioLançamentoDados();

                    //Exibição do lançamento
                    ExibirLançamento(resultado);

                    posicaoUsuario += resultado;

                    if (posicaoUsuario >= LIMITELINHACHEGADA)
                    {
                        Console.WriteLine($"O jogador chegou a linha de chegada.");
                        jogoEmAndamento = false;
                        Console.ReadLine();
                    }
                    else
                        Console.WriteLine($"O jogador está na posição: {posicaoUsuario} de {LIMITELINHACHEGADA}.");




                    Console.ReadLine();
                } while (jogoEmAndamento);

                //Verificar se quer executar novamente
                string opcaoContinuar = PerguntaJogarNovamente();
                if (opcaoContinuar != "s")
                    break;
            }
        }

        static void ExibirCabeçalho()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("----------------------------------");

            Console.Write("Pressione ENTER para lançar o dado...");
            Console.ReadLine();
        }

        static int SorteioLançamentoDados()
        {
            Random rdn = new Random();
            int jogarDados = rdn.Next(1, 7);
            return jogarDados;
        }

        static void ExibirLançamento(int resultado)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"O valor sorteado foi {resultado}");
            Console.WriteLine("----------------------------------");
        }

        static string PerguntaJogarNovamente()
        {
            Console.WriteLine("Deseja continuar? (s/n)");
            string opcaoContinuar = Console.ReadLine().ToLower();
                return opcaoContinuar;
        }

    }

}
