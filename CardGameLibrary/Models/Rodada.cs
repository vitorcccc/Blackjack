using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Models
{
    /// Representa uma rodada do jogo.
    public class Rodada
    {
        /// Número da rodada.
        public int NumeroRodada { get; set; }

        /// Data e hora de início da rodada.
        public DateTime InicioRodada { get; set; }

        /// Data e hora de término da rodada.
        public DateTime? FimRodada { get; set; }

        /// Lista de movimentos realizados na rodada.
        public List<Movimento> Movimentos { get; set; }

        /// Vencedor da rodada (pode ser null em caso de empate).
        public Jogador? Vencedor { get; set; }

        /// Pontos ganhos na rodada.
        public int PontosRodada { get; set; }

        /// Construtor da classe Rodada.
        /// <param name="numeroRodada">Número da rodada.</param>
        public Rodada(int numeroRodada)
        {
            NumeroRodada = numeroRodada;
            InicioRodada = DateTime.Now;
            Movimentos = new List<Movimento>();
            PontosRodada = 0;
        }

        /// Adiciona um movimento à rodada.
        public void AdicionarMovimento(Movimento movimento)
        {
            Movimentos.Add(movimento);
        }

        /// Finaliza a rodada com um vencedor.
        public void FinalizarRodada(Jogador? vencedor, int pontos)
        {
            FimRodada = DateTime.Now;
            Vencedor = vencedor;
            PontosRodada = pontos;
            if (vencedor != null)
            {
                vencedor.AdicionarPontos(pontos);
            }
        }

        /// Exibe o resumo da rodada.
        public void ExibirResumo()
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Rodada #{NumeroRodada}");
            Console.WriteLine($"Início: {InicioRodada:dd/MM/yyyy HH:mm:ss}");

            if (FimRodada.HasValue)
            {
                TimeSpan duracao = FimRodada.Value - InicioRodada;
                Console.WriteLine($"Duração: {duracao.Seconds} segundos");
                if (Vencedor != null)
                {
                    Console.WriteLine($"Vencedor: {Vencedor.Nome}");
                    Console.WriteLine($"Pontos: {PontosRodada}");
                }
                else
                {
                    Console.WriteLine("Resultado: Empate");
                }
            }

            Console.WriteLine($"Total de movimentos: {Movimentos.Count}");
            Console.WriteLine("========================================");
        }
    }
}