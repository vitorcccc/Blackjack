using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameLibrary.Enums;

namespace CardGameLibrary.Models
{
    /// Representa um baralho de cartas.
    public class Baralho
    {
        private List<Carta> _cartas;
        private Random _random;

        /// Inicializa um novo baralho com 52 cartas.
        public Baralho()
        {
            _cartas = new List<Carta>();
            _random = new Random();
            InicializarBaralho();
        }

        /// Inicializa o baralho com todas as cartas (4 naipes × 13 valores).
        private void InicializarBaralho()
        {
            Naipe[] naipes = { Naipe.Copas, Naipe.Ouros, Naipe.Paus, Naipe.Espadas };
            ValorCarta[] valores = {
                ValorCarta.As, ValorCarta.Dois, ValorCarta.Tres, ValorCarta.Quatro,
                ValorCarta.Cinco, ValorCarta.Seis, ValorCarta.Sete, ValorCarta.Oito,
                ValorCarta.Nove, ValorCarta.Dez, ValorCarta.Valete, ValorCarta.Dama, ValorCarta.Rei
            };

            foreach (var naipe in naipes)
            {
                foreach (var valor in valores)
                {
                    _cartas.Add(new Carta(naipe, valor));
                }
            }
        }

        /// Embaralha as cartas do baralho aleatoriamente.
        public void Embaralhar()
        {
            for (int i = 0; i < _cartas.Count; i++)
            {
                int posicaoAleatoria = _random.Next(_cartas.Count);
                Carta temp = _cartas[i];
                _cartas[i] = _cartas[posicaoAleatoria];
                _cartas[posicaoAleatoria] = temp;
            }
            Console.WriteLine("Baralho embaralhado!");
        }

        /// Compra uma carta do topo do baralho.
        /// <returns>A carta comprada.</returns>
        /// <remarks>Se o baralho estiver vazio, ele é reiniciado automaticamente.</remarks>
        public Carta Comprar()
        {
            if (_cartas.Count == 0)
            {
                Reiniciar();
            }

            Carta carta = _cartas[0];
            _cartas.RemoveAt(0);
            return carta;
        }

        /// Compra múltiplas cartas do baralho.
        /// <param name="quantidade">Número de cartas a serem compradas.</param>
        /// <returns>Lista com as cartas compradas.</returns>
        public List<Carta> Comprar(int quantidade)
        {
            List<Carta> cartasCompradas = new List<Carta>();
            for (int i = 0; i < quantidade; i++)
            {
                cartasCompradas.Add(Comprar());
            }
            return cartasCompradas;
        }

        /// Retorna a quantidade de cartas restantes no baralho.
        /// <returns>Número de cartas disponíveis.</returns>
        public int QuantidadeRestante()
        {
            return _cartas.Count;
        }

        /// Reinicia o baralho com todas as cartas e embaralha.
        public void Reiniciar()
        {
            _cartas.Clear();
            InicializarBaralho();
            Embaralhar();
            Console.WriteLine("Baralho reiniciado!");
        }
    }
}