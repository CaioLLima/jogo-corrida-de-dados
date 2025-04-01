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
                {   //Usuario
                    //Cabeçalho
                    ExibirCabeçalho("Usuario");

                    //Sorteio do lançamento do dado
                    int resultado = SorteioLançamentoDados();

                    //Exibição do lançamento
                    ExibirLançamento(resultado);

                    //Atualiza posicao usuario
                    posicaoUsuario += resultado;

                    //Verifica se usuario ganhou
                    if (posicaoUsuario >= LIMITELINHACHEGADA)
                    {
                        Console.WriteLine($"O jogador chegou a linha de chegada.");
                        jogoEmAndamento = false;
                        Console.ReadLine();
                    }
                    else
                        Console.WriteLine($"O jogador está na posição: {posicaoUsuario} de {LIMITELINHACHEGADA}.");
                        Console.ReadLine();

                    //Computador
                    //Cabeçalho
                    ExibirCabeçalho("Computador");

                    //Sorteio do lançamento do dado
                    int resultadoComputador = SorteioLançamentoDados();

                    //Exibição do lançamento
                    ExibirLançamento(resultadoComputador);

                    //Atualiza posicao usuario
                    posicaoComputador += resultadoComputador;

                    //Verifica se usuario ganhou
                    if (posicaoComputador >= LIMITELINHACHEGADA)
                    {
                        Console.WriteLine($"O computador chegou a linha de chegada.");
                        jogoEmAndamento = false;
                        Console.ReadLine();
                    }
                    else
                        Console.WriteLine($"O computador está na posição: {posicaoComputador} de {LIMITELINHACHEGADA}.");
                        Console.ReadLine();
                   
                } while (jogoEmAndamento);

                //Verificar se quer executar novamente
                string opcaoContinuar = PerguntaJogarNovamente();
                if (opcaoContinuar != "s")
                    break;
            }
        }

        static void ExibirCabeçalho(string nome)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Turno do {nome}");
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
