using System;
using System.Collections.Generic;
using CardGameLibrary.Models;
using CardGameLibrary.Enums;

namespace CardGameApp
{
    /// Classe que representa o jogo de Blackjack (21)
    public class BlackjackGame
    {
        private Baralho _baralho;
        private Jogador _jogador;
        private Jogador _computador;
        private Partida _partida;
        private bool _jogadorEmPe;
        private bool _computadorEmPe;

        /// Construtor do jogo Blackjack
        public BlackjackGame(string nomeJogador)
        {
            _baralho = new Baralho();
            _jogador = new Jogador(nomeJogador);
            _computador = new Jogador("Computador");

            List<Jogador> jogadores = new List<Jogador> { _jogador, _computador };
            _partida = new Partida("Blackjack", jogadores);

            _jogadorEmPe = true;
            _computadorEmPe = true;
        }

        /// Inicia o jogo completo
        public void IniciarJogo()
        {
            bool continuarJogando = true;

            while (continuarJogando)
            {
                IniciarRodada();

                // Vez do jogador
                if (_jogadorEmPe)
                {
                    VezDoJogador();
                }

                // Vez do computador
                if (_computadorEmPe && _jogador.Mao.ValorTotal <= 21)
                {
                    VezDoComputador();
                }

                // Mostra mao final
                MostrarMesa(true);

                // Determina vencedor da rodada
                DeterminarVencedor(_partida.RodadaAtual);

                // Mostra placar atualizado
                MostrarPlacar();

                // Pergunta se quer continuar
                continuarJogando = JogarNovamente();
            }

            // Finaliza a partida
            _partida.FinalizarPartida();

            // Exibe histórico final
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("          FIM DE JOGO - HISTORICO        ");
            Console.WriteLine("=========================================\n");

            _partida.ExibirHistorico();

            Console.WriteLine("\nObrigado por jogar Blackjack!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        /// Mostra o placar atual do jogo
        private void MostrarPlacar()
        {
            int jogadorPontos = _partida.ObterPontuacaoJogador(_jogador);
            int computadorPontos = _partida.ObterPontuacaoJogador(_computador);

            Console.WriteLine("=========================================");
            Console.WriteLine("              PLACAR ATUAL              ");
            Console.WriteLine("=========================================");
            Console.WriteLine($"  {_jogador.Nome,-15} {jogadorPontos,5} pontos");
            Console.WriteLine($"  Computador{" ",-9} {computadorPontos,5} pontos");
            Console.WriteLine($"  Rodadas jogadas{" ",-5} {_partida.Rodadas.Count,5}");
            Console.WriteLine("=========================================\n");
        }

        /// Inicia uma nova rodada
        private void IniciarRodada()
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("           BLACKJACK 21                 ");
            Console.WriteLine("=========================================\n");

            Console.WriteLine($"Jogador: {_jogador.Nome}");
            Console.WriteLine($"Partida ID: {_partida.Id.ToString().Substring(0, 8)}...");
            Console.WriteLine($"Rodada: {_partida.Rodadas.Count + 1}\n");

            // Reinicia o baralho se necessario
            if (_baralho.QuantidadeRestante() < 20)
            {
                Console.WriteLine("Baralho com poucas cartas. Reiniciando e embaralhando...");
                _baralho.Reiniciar();
                _baralho.Embaralhar();
            }

            // Limpa as maos
            _jogador.Mao.Limpar();
            _computador.Mao.Limpar();
            _jogadorEmPe = true;
            _computadorEmPe = true;

            // Inicia nova rodada na partida
            Rodada rodada = _partida.IniciarNovaRodada();

            // Distribui as cartas iniciais
            _jogador.Mao.AdicionarCarta(_baralho.Comprar());
            _computador.Mao.AdicionarCarta(_baralho.Comprar());
            _jogador.Mao.AdicionarCarta(_baralho.Comprar());
            _computador.Mao.AdicionarCarta(_baralho.Comprar());

            // Registra os movimentos
            _partida.AdicionarMovimento(new Movimento(_jogador, "recebeu 2 cartas"));
            _partida.AdicionarMovimento(new Movimento(_computador, "recebeu 2 cartas"));

            // Mostra a mesa
            MostrarMesa(false);
        }

        /// Mostra a mesa com as cartas
        private void MostrarMesa(bool mostrarCartaComputador)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("              MESA DE JOGO               ");
            Console.WriteLine("-----------------------------------------");

            // Mostra mao do computador
            int totalComputador = _computador.Mao.ValorTotal;
            if (mostrarCartaComputador)
            {
                Console.Write($"COMPUTADOR ({totalComputador} pts): ");
                foreach (var carta in _computador.Mao.Cartas)
                {
                    Console.Write($"[{carta.ObterNome()}] ");
                }
            }
            else
            {
                Console.Write($"COMPUTADOR (?? pts): [???] ");
                for (int i = 1; i < _computador.Mao.Quantidade; i++)
                {
                    Console.Write($"[{_computador.Mao.Cartas[i].ObterNome()}] ");
                }
            }
            Console.WriteLine("\n-----------------------------------------");

            // Mostra mao do jogador
            Console.Write($"{_jogador.Nome} ({_jogador.Mao.ValorTotal} pts): ");
            foreach (var carta in _jogador.Mao.Cartas)
            {
                Console.Write($"[{carta.ObterNome()}] ");
            }
            Console.WriteLine("\n-----------------------------------------\n");
        }

        /// Verifica se o jogador estourou (passou de 21)
        private bool VerificarEstouro(Jogador jogador)
        {
            if (jogador.Mao.ValorTotal > 21)
            {
                // Se passou de 21, verifica se tem As para reduzir
                int quantidadeAs = 0;
                foreach (var carta in jogador.Mao.Cartas)
                {
                    if (carta.Valor == ValorCarta.As)
                        quantidadeAs++;
                }

                if (quantidadeAs > 0)
                {
                    // Ajusta o valor do As de 11 para 1
                    int novoTotal = jogador.Mao.ValorTotal - (quantidadeAs * 10);
                    if (novoTotal <= 21)
                    {
                        Console.WriteLine($"{jogador.Nome} ajustou As(es) de 11 para 1!");
                        Console.WriteLine($"   Novo total: {novoTotal}\n");
                        return false;
                    }
                }

                return true;
            }
            return false;
        }

        /// Verifica se fez 21 (Blackjack)
        private bool VerificarVinteUm(Jogador jogador)
        {
            if (jogador.Mao.ValorTotal == 21)
            {
                Console.WriteLine($"{jogador.Nome} fez 21! BLACKJACK!\n");
                return true;
            }
            return false;
        }

        /// Vez do jogador
        private void VezDoJogador()
        {
            while (_jogadorEmPe)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("              SUA VEZ!                  ");
                Console.WriteLine("=========================================");

                Console.WriteLine("O que voce deseja fazer?");
                Console.WriteLine("  [1] Comprar carta (Hit)");
                Console.WriteLine("  [2] Parar (Stand)");
                Console.Write("\nEscolha: ");

                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    // Compra uma carta
                    Carta novaCarta = _baralho.Comprar();
                    _jogador.Mao.AdicionarCarta(novaCarta);

                    Movimento movimento = new Movimento(_jogador, "comprou carta", novaCarta);
                    _partida.AdicionarMovimento(movimento);

                    Console.WriteLine($"\nVoce comprou: {novaCarta.ObterNome()}");
                    Console.WriteLine($"  Total atual: {_jogador.Mao.ValorTotal}\n");

                    // Verifica se fez 21
                    if (VerificarVinteUm(_jogador))
                    {
                        _jogadorEmPe = false;
                    }
                    // Verifica se estourou
                    else if (VerificarEstouro(_jogador))
                    {
                        Console.WriteLine("VOCE ESTOUROU! Passou de 21.\n");
                        _jogadorEmPe = false;
                        _computadorEmPe = false;
                    }

                    MostrarMesa(false);
                }
                else if (opcao == "2")
                {
                    Console.WriteLine("\nVoce decidiu parar!\n");
                    _jogadorEmPe = false;
                }
                else
                {
                    Console.WriteLine("Opcao invalida! Tente novamente.\n");
                }
            }
        }

        /// Vez do computador
        private void VezDoComputador()
        {
            if (!_jogadorEmPe && _computadorEmPe && _jogador.Mao.ValorTotal <= 21)
            {
                MostrarMesa(true);
                Console.WriteLine("=========================================");
                Console.WriteLine("           VEZ DO COMPUTADOR            ");
                Console.WriteLine("=========================================");

                // Computador compra enquanto tiver menos de 17
                while (_computador.Mao.ValorTotal < 17)
                {
                    Carta novaCarta = _baralho.Comprar();
                    _computador.Mao.AdicionarCarta(novaCarta);

                    Movimento movimento = new Movimento(_computador, "comprou carta", novaCarta);
                    _partida.AdicionarMovimento(movimento);

                    Console.WriteLine($"Computador comprou: {novaCarta.ObterNome()}");
                    Console.WriteLine($"   Total do computador: {_computador.Mao.ValorTotal}\n");

                    if (VerificarEstouro(_computador))
                    {
                        Console.WriteLine("COMPUTADOR ESTOUROU! Voce venceu!\n");
                        _computadorEmPe = false;
                        return;
                    }
                }

                Console.WriteLine($"Computador parou com {_computador.Mao.ValorTotal} pontos.\n");
                _computadorEmPe = false;
            }
        }

        /// Determina o vencedor da rodada
        private void DeterminarVencedor(Rodada rodada)
        {
            int pontosJogador = _jogador.Mao.ValorTotal;
            int pontosComputador = _computador.Mao.ValorTotal;

            Console.WriteLine("=========================================");
            Console.WriteLine("              RESULTADO                 ");
            Console.WriteLine("=========================================");

            Console.WriteLine($"\n{_jogador.Nome}: {pontosJogador} pontos");
            Console.WriteLine($"Computador: {pontosComputador} pontos\n");

            // Regras do Blackjack
            if (pontosJogador > 21 && pontosComputador > 21)
            {
                Console.WriteLine("Ambos estouraram! Ninguem ganhou.\n");
                rodada.FinalizarRodada(null, 0);
                Console.WriteLine($"{_jogador.Nome} ganhou 0 pontos! Total: {_partida.ObterPontuacaoJogador(_jogador)}");
                Console.WriteLine($"Computador ganhou 0 pontos! Total: {_partida.ObterPontuacaoJogador(_computador)}\n");
            }
            else if (pontosJogador > 21)
            {
                Console.WriteLine("Voce estourou! Computador venceu!\n");
                rodada.FinalizarRodada(_computador, 100);
                Console.WriteLine($"{_jogador.Nome} ganhou 0 pontos! Total: {_partida.ObterPontuacaoJogador(_jogador)}");
                Console.WriteLine($"Computador ganhou 100 pontos! Total: {_partida.ObterPontuacaoJogador(_computador)}\n");
            }
            else if (pontosComputador > 21)
            {
                Console.WriteLine("PARABENS! Computador estourou! VOCE VENCEU!\n");
                rodada.FinalizarRodada(_jogador, 100);
                Console.WriteLine($"{_jogador.Nome} ganhou 100 pontos! Total: {_partida.ObterPontuacaoJogador(_jogador)}");
                Console.WriteLine($"Computador ganhou 0 pontos! Total: {_partida.ObterPontuacaoJogador(_computador)}\n");
            }
            else if (pontosJogador > pontosComputador)
            {
                Console.WriteLine($"PARABENS {_jogador.Nome}! VOCE VENCEU!\n");
                rodada.FinalizarRodada(_jogador, 100);
                Console.WriteLine($"{_jogador.Nome} ganhou 100 pontos! Total: {_partida.ObterPontuacaoJogador(_jogador)}");
                Console.WriteLine($"Computador ganhou 0 pontos! Total: {_partida.ObterPontuacaoJogador(_computador)}\n");
            }
            else if (pontosComputador > pontosJogador)
            {
                Console.WriteLine("Computador venceu! Tente novamente!\n");
                rodada.FinalizarRodada(_computador, 100);
                Console.WriteLine($"{_jogador.Nome} ganhou 0 pontos! Total: {_partida.ObterPontuacaoJogador(_jogador)}");
                Console.WriteLine($"Computador ganhou 100 pontos! Total: {_partida.ObterPontuacaoJogador(_computador)}\n");
            }
            else
            {
                Console.WriteLine("Empate! Ninguem ganhou pontos.\n");
                rodada.FinalizarRodada(null, 0);
                Console.WriteLine($"{_jogador.Nome} ganhou 0 pontos! Total: {_partida.ObterPontuacaoJogador(_jogador)}");
                Console.WriteLine($"Computador ganhou 0 pontos! Total: {_partida.ObterPontuacaoJogador(_computador)}\n");
            }
        }

        /// Pergunta se o jogador quer jogar novamente
        private bool JogarNovamente()
        {
            Console.Write("\nDeseja jogar mais uma rodada? (S/N): ");
            string opcao = Console.ReadLine().ToUpper();
            return opcao == "S";
        }
    }
}