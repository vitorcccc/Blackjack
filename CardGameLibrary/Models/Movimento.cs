using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Models
{
    /// Representa um movimento realizado durante o jogo.
    public class Movimento
    {
        /// Jogador que realizou o movimento.
        public Jogador Jogador { get; set; }

        /// Tipo do movimento (Comprar, Jogar, Passar, Desistir).
        public string TipoMovimento { get; set; }

        /// Data e hora em que o movimento foi realizado.
        public DateTime DataHora { get; set; }

        /// Carta utilizada no movimento (se houver).
        public Carta CartaUtilizada { get; set; }

        /// Descrição do movimento.
        public string Descricao { get; set; }

        /// Construtor da classe Movimento.
        /// <param name="jogador">Jogador que realizou o movimento.</param>
        /// <param name="tipoMovimento">Tipo do movimento.</param>
        /// <param name="carta">Carta utilizada (opcional).</param>
        public Movimento(Jogador jogador, string tipoMovimento, Carta carta = null)
        {
            Jogador = jogador;
            TipoMovimento = tipoMovimento;
            DataHora = DateTime.Now;
            CartaUtilizada = carta;

            // Cria a descrição baseada no tipo de movimento
            if (carta != null)
                Descricao = $"{jogador.Nome} {tipoMovimento} a carta {carta.ObterNome()}";
            else
                Descricao = $"{jogador.Nome} {tipoMovimento}";
        }

        /// Exibe o movimento no console.
        public void Exibir()
        {
            Console.WriteLine($"[{DataHora:HH:mm:ss}] {Descricao}");
        }
    }
}