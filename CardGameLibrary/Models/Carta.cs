using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameLibrary.Enums;

namespace CardGameLibrary.Models
{
    /// Representa uma carta de baralho.
    public class Carta
    {
        /// Naipe da carta (Copas, Ouros, Paus, Espadas).
        public Naipe Naipe { get; set; }

        /// Valor da carta (Ás, 2, 3, ..., Rei).
        public ValorCarta Valor { get; set; }

        /// Construtor da classe Carta.
        /// <param name="naipe">Naipe da carta.</param>
        /// <param name="valor">Valor da carta.</param>
        public Carta(Naipe naipe, ValorCarta valor)
        {
            Naipe = naipe;
            Valor = valor;
        }

        /// Retorna o nome completo da carta.
        /// Exemplo: "Ás de Copas"
        public string ObterNome()
        {
            return $"{Valor} de {Naipe}";
        }

        /// Retorna o valor numérico da carta para cálculos.
        /// Regras padrão:
        /// - Ás vale 11
        /// - Valete, Dama e Rei valem 10
        /// - Demais cartas valem seu número
        public int ObterValorNumerico()
        {
            // Verifica se é o Ás
            if (Valor == ValorCarta.As)
                return 11;
            // Verifica se é Valete, Dama ou Rei
            else if (Valor == ValorCarta.Valete || Valor == ValorCarta.Dama || Valor == ValorCarta.Rei)
                return 10;
            // Para as demais cartas, retorna o valor numérico
            else
                return (int)Valor;
        }

        /// Exibe as informações da carta no console.
        public void Exibir()
        {
            Console.WriteLine(ObterNome());
        }

        /// Sobrescreve o método ToString para retornar o nome da carta.
        public override string ToString()
        {
            return ObterNome();
        }
    }
}