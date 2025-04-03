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
                    //Caiu em uma casa normal
                    posicaoUsuario += resultado;

                    //Avanço Extra
                    posicaoUsuario = AvançoExtra(posicaoUsuario);

                    //Recuo 
                    posicaoUsuario = PenalidadeRecuar(posicaoUsuario);

                    // Rodada extra
                    posicaoUsuario = RodadaExtra("Usuário", resultado, posicaoUsuario, LIMITELINHACHEGADA);

                    //Verifica se usuario ganhou
                    jogoEmAndamento = VerificaSeJogoTerminou("Usuário", posicaoUsuario, LIMITELINHACHEGADA, jogoEmAndamento);

                    //Computador
                    //Cabeçalho
                    ExibirCabeçalho("Computador");

                    //Sorteio do lançamento do dado
                    int resultadoComputador = SorteioLançamentoDados();

                    //Exibição do lançamento
                    ExibirLançamento(resultadoComputador);

                    //Atualiza posicao computador
                    posicaoComputador += resultadoComputador;

                    //Avanço Extra
                    posicaoComputador = AvançoExtra(posicaoComputador);

                    //Recuo
                    posicaoComputador = PenalidadeRecuar(posicaoComputador);


                    // Rodada extra
                    posicaoComputador = RodadaExtra("Computador", resultado, posicaoComputador, LIMITELINHACHEGADA);

                    //Verifica se computador ganhou
                    jogoEmAndamento = VerificaSeJogoTerminou("Computador", posicaoComputador, LIMITELINHACHEGADA, jogoEmAndamento);

                } while (jogoEmAndamento);

                //Verificar se quer executar novamente
                //while(true)
                // IniciarJogo();
                //if (!VerificaSeQuerNovamente)
                //break;
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
            

            if(nome == "Usuario")
            {
                Console.WriteLine("----------------------------------");
                Console.Write("Pressione ENTER para lançar o dado...");
                Console.ReadLine();
            }
            
                
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

        static int AvançoExtra(int posicao)
        {
            if (posicao == 5 || posicao == 10 || posicao == 15)
            {
                Console.WriteLine("Caiu em uma casa especial, avançará 3 casas.");
                Console.WriteLine("----------------------------------");
                return posicao += 3;
            }
            return posicao;
        }

        static int PenalidadeRecuar(int posicao)
        {
            if (posicao == 7 || posicao == 13 || posicao == 20)
            {

                Console.WriteLine("Caiu em uma casa especial, retornará 2 casas.");
                Console.WriteLine("----------------------------------");
                return posicao -= 2;
            }
            return posicao;
        }

        static int RodadaExtra(string nome, int resultado, int posicao, int LIMITELINHACHEGADA)
        {
            if (nome == "Usuário" && resultado == 6)
            {
                Console.WriteLine($"O jogador está na posição: {posicao} de {LIMITELINHACHEGADA}.");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("\nVocê tirou 6 no dado, pode jogar o dado novamente!!");
                //Cabeçalho
                ExibirCabeçalho("Usuario");

                //Sorteio do lançamento do dado
                resultado = SorteioLançamentoDados();

                //Exibição do lançamento
                ExibirLançamento(resultado);

                //Atualiza posicao usuario  
                //Caiu em uma casa normal
                posicao += resultado;

                //Avanço Extra
                posicao = AvançoExtra(posicao);

                //Recuo 
                posicao = PenalidadeRecuar(posicao);

                return posicao;
            }

            else if(nome == "Computador" && resultado == 6)
            {
                Console.WriteLine($"O computador está na posição: {posicao} de {LIMITELINHACHEGADA}.");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("\nO computador tirou 6 no dado, irá jogar o dado novamente!!");
                //Cabeçalho
                ExibirCabeçalho("Computador");

                //Sorteio do lançamento do dado
                resultado = SorteioLançamentoDados();

                //Exibição do lançamento
                ExibirLançamento(resultado);

                //Atualiza posicao usuario  
                //Caiu em uma casa normal
                posicao += resultado;

                //Avanço Extra
                posicao = AvançoExtra(posicao);

                //Recuo 
                posicao = PenalidadeRecuar(posicao);

                return posicao;
            }
            return posicao;

        }

        static bool VerificaSeJogoTerminou(string nome, int posicao, int LIMITELINHACHEGADA, bool jogoEmAndamento)
        {
            if (nome == "Usuário" && posicao >= LIMITELINHACHEGADA)
            {
                Console.WriteLine($"Parabéns, o jogador chegou a linha de chegada.");

                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
                return jogoEmAndamento = false;
            }
            else if(nome == "Usuário" && posicao < LIMITELINHACHEGADA) { 
                Console.WriteLine($"O jogador está na posição: {posicao} de {LIMITELINHACHEGADA}.");
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
                return jogoEmAndamento = true; 
            }
            else if (nome == "Computador" && posicao >= LIMITELINHACHEGADA)
            {
                Console.WriteLine($"O jogador chegou a linha de chegada.");
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
                return jogoEmAndamento = false;
            }
            else if (nome == "Computador" && posicao < LIMITELINHACHEGADA)
            { 
                Console.WriteLine($"O jogador está na posição: {posicao} de {LIMITELINHACHEGADA}.");
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
                return jogoEmAndamento = true; 
            }
            return jogoEmAndamento;
        }

        static string PerguntaJogarNovamente()
        {
            Console.WriteLine("Deseja continuar? (s/n)");
            string opcaoContinuar = Console.ReadLine().ToLower();
                return opcaoContinuar;
        }

    }

}
