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
                    if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15)
                    {
                        
                        Console.WriteLine("Caiu em uma casa especial, avance 3 casas.");
                        Console.WriteLine("----------------------------------");
                        posicaoUsuario += 3;
                    }
                        
                    //Recuo
                    else if (posicaoUsuario == 7 || posicaoUsuario == 13 || posicaoUsuario == 20)
                    {
                        
                        Console.WriteLine("Caiu em uma casa especial, retorne 2 casas.");
                        Console.WriteLine("----------------------------------");
                        posicaoUsuario -=  2;
                    }
                       

                    // Rodada extra
                    if (resultado == 6)

                    {
                        Console.WriteLine($"O jogador está na posição: {posicaoUsuario} de {LIMITELINHACHEGADA}.");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("\nVocê tirou 6 no dado, pode jogar o dado novamente!!");
                        continue;

                    }
                   
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

                    //Atualiza posicao computador
                    posicaoComputador += resultadoComputador;
                    //Avanço Extra
                    if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15)
                    {
                        
                        Console.WriteLine("O computador caiu em uma casa especial, avançou 3 casas.");
                        Console.WriteLine("----------------------------------");
                        posicaoComputador += 3;
                    }
                        
                    //Recuo
                    else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
                    {
                        
                        Console.WriteLine("O computador caiu em uma casa especial, retornou 2 casas.");
                        Console.WriteLine("----------------------------------");
                        posicaoComputador -= 2;
                    }
                        

                    // Rodada extra
                    if (resultadoComputador == 6)
                    {
                        Console.WriteLine($"O Computador está na posição: {posicaoComputador} de {LIMITELINHACHEGADA}.");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("\nO computador tirou 6 no dado, irá jogar o dado novamente!!");
                        resultadoComputador = SorteioLançamentoDados();
                        ExibirLançamento(resultadoComputador);
                        posicaoComputador += resultadoComputador;
                        if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15)
                        {
                            Console.WriteLine("O computador caiu em uma casa especial, avançou 3 casas.");
                            Console.WriteLine("----------------------------------");
                            posicaoComputador += 3;
                        }

                        //Recuo
                        else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
                        {
                            Console.WriteLine("O computador caiu em uma casa especial, retornou 2 casas.");
                            Console.WriteLine("----------------------------------");
                            posicaoComputador -= 2;
                        }
                    }

                    //Verifica se computador ganhou
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

        static string PerguntaJogarNovamente()
        {
            Console.WriteLine("Deseja continuar? (s/n)");
            string opcaoContinuar = Console.ReadLine().ToLower();
                return opcaoContinuar;
        }

    }

}
