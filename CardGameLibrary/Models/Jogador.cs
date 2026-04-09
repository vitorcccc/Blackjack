using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Models
{
    /// Representa um jogador do jogo de cartas.
    public class Jogador
    {
        private string _nome;
        private int _pontuacao;
        private Mao _mao;

        /// Nome do jogador.
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        /// Pontuação atual do jogador.
        public int Pontuacao
        {
            get { return _pontuacao; }
            set { _pontuacao = value; }
        }

        /// Mão do jogador contendo as cartas que ele possui.
        public Mao Mao
        {
            get { return _mao; }
            set { _mao = value; }
        }

        /// Inicializa um novo jogador com o nome especificado.
        /// <param name="nome">Nome do jogador.</param>
        public Jogador(string nome)
        {
            _nome = nome;
            _pontuacao = 0;
            _mao = new Mao();
        }

        /// Adiciona pontos à pontuação do jogador.
        /// <param name="pontos">Quantidade de pontos a serem adicionados.</param>
        public void AdicionarPontos(int pontos)
        {
            _pontuacao += pontos;
            Console.WriteLine($"{_nome} ganhou {pontos} pontos! Total: {_pontuacao}");
        }

        /// Exibe as informações do jogador no console.
        public void Exibir()
        {
            Console.WriteLine("================================");
            Console.WriteLine($"Jogador: {_nome}");
            Console.WriteLine($"Pontuação: {_pontuacao}");
            Console.WriteLine($"Cartas na mão: {_mao.Quantidade}");
            Console.WriteLine("================================");
        }

        /// Retorna o nome do jogador como representação em string.
        /// <returns>Nome do jogador.</returns>
        public override string ToString()
        {
            return _nome;
        }
    }
}