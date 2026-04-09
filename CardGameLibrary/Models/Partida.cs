using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Models
{
    /// Representa uma partida completa do jogo.
    public class Partida
    {
        /// Identificador único da partida.
        public Guid Id { get; set; }

        /// Nome do jogo.
        public string NomeJogo { get; set; }

        /// Lista de jogadores da partida.
        public List<Jogador> Jogadores { get; set; }

        /// Lista de rodadas da partida.
        public List<Rodada> Rodadas { get; set; }

        /// Data e hora de início da partida.
        public DateTime DataInicio { get; set; }

        /// Data e hora de término da partida.
        public DateTime? DataFim { get; set; }

        /// Vencedor da partida (pode ser null em caso de empate).
        public Jogador? Vencedor { get; set; }

        /// Rodada atual da partida (pode ser null).
        public Rodada? RodadaAtual { get; set; }

        /// Configurações da partida.
        public Dictionary<string, object> Configuracoes { get; set; }

        /// Construtor da classe Partida.
        /// <param name="nomeJogo">Nome do jogo.</param>
        /// <param name="jogadores">Lista de jogadores.</param>
        public Partida(string nomeJogo, List<Jogador> jogadores)
        {
            Id = Guid.NewGuid();
            NomeJogo = nomeJogo;
            Jogadores = jogadores;
            Rodadas = new List<Rodada>();
            DataInicio = DateTime.Now;
            Configuracoes = new Dictionary<string, object>();
        }

        /// Inicia uma nova rodada.
        public Rodada IniciarNovaRodada()
        {
            int numeroRodada = Rodadas.Count + 1;
            RodadaAtual = new Rodada(numeroRodada);
            Rodadas.Add(RodadaAtual);
            return RodadaAtual;
        }

        /// Adiciona um movimento à rodada atual.
        public void AdicionarMovimento(Movimento movimento)
        {
            if (RodadaAtual != null)
            {
                RodadaAtual.AdicionarMovimento(movimento);
            }
        }

        /// Obtém a pontuação total de um jogador.
        public int ObterPontuacaoJogador(Jogador jogador)
        {
            int total = 0;
            foreach (var rodada in Rodadas)
            {
                if (rodada.Vencedor == jogador)
                {
                    total += rodada.PontosRodada;
                }
            }
            return total;
        }

        /// Retorna o jogador com maior pontuação.
        private Jogador? ObterVencedor()
        {
            Jogador? vencedor = null;
            int maiorPontuacao = -1;

            foreach (var jogador in Jogadores)
            {
                int pontuacao = ObterPontuacaoJogador(jogador);
                if (pontuacao > maiorPontuacao)
                {
                    maiorPontuacao = pontuacao;
                    vencedor = jogador;
                }
            }

            return vencedor;
        }

        /// Finaliza a partida.
        public void FinalizarPartida()
        {
            DataFim = DateTime.Now;
            Vencedor = ObterVencedor();
        }

        /// Exibe o histórico completo da partida.
        public void ExibirHistorico()
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Partida: {NomeJogo}");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Início: {DataInicio:dd/MM/yyyy HH:mm:ss}");

            if (DataFim.HasValue)
                Console.WriteLine($"Fim: {DataFim.Value:dd/MM/yyyy HH:mm:ss}");

            Console.WriteLine("========================================");
            Console.WriteLine("Jogadores:");

            foreach (var jogador in Jogadores)
            {
                Console.WriteLine($"  - {jogador.Nome} | Pontuação: {ObterPontuacaoJogador(jogador)}");
            }

            Console.WriteLine("========================================");
            Console.WriteLine($"Total de rodadas: {Rodadas.Count}");

            if (Vencedor != null)
                Console.WriteLine($"Vencedor: {Vencedor.Nome}");

            Console.WriteLine("========================================");
        }
    }
}