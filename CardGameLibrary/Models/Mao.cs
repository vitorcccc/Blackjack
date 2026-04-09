using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Models
{
    /// Representa a mão de cartas de um jogador.
    public class Mao
    {
        // Lista que armazena as cartas da mão
        private List<Carta> _cartas;

        /// Construtor da classe Mao.
        /// Inicializa uma mão vazia.
        public Mao()
        {
            _cartas = new List<Carta>();
        }

        /// Retorna a lista de cartas da mão.
        public List<Carta> Cartas
        {
            get { return _cartas; }
        }

        /// Retorna a quantidade de cartas na mão.
        public int Quantidade
        {
            get { return _cartas.Count; }
        }

        /// Retorna o valor total da mão (soma dos valores das cartas).
        public int ValorTotal
        {
            get
            {
                int total = 0;
                foreach (var carta in _cartas)
                {
                    total += carta.ObterValorNumerico();
                }
                return total;
            }
        }

        /// Adiciona uma carta à mão.
        public void AdicionarCarta(Carta carta)
        {
            _cartas.Add(carta);
        }

        /// Adiciona várias cartas à mão.
        public void AdicionarCartas(List<Carta> cartas)
        {
            foreach (var carta in cartas)
            {
                _cartas.Add(carta);
            }
        }

        /// Remove uma carta específica da mão.
        public bool RemoverCarta(Carta carta)
        {
            return _cartas.Remove(carta);
        }

        /// Remove uma carta pelo índice.
        public Carta RemoverCarta(int indice)
        {
            if (indice >= 0 && indice < _cartas.Count)
            {
                Carta carta = _cartas[indice];
                _cartas.RemoveAt(indice);
                return carta;
            }
            return null;
        }

        /// Limpa todas as cartas da mão.
        public void Limpar()
        {
            _cartas.Clear();
        }

        /// Exibe todas as cartas da mão no console.
        public void ExibirMao()
        {
            Console.WriteLine("Cartas na mão:");
            for (int i = 0; i < _cartas.Count; i++)
            {
                Console.WriteLine($"  {i + 1} - {_cartas[i].ObterNome()}");
            }
        }
    }
}