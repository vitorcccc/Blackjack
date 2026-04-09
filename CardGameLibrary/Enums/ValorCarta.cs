using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Enums
{
    /// Representa os valores das cartas de baralho.
    public enum ValorCarta
    {
        As = 1,     // Ás - pode valer 1/11
        Dois = 2,   // Carta de valor 2
        Tres = 3,   // Carta de valor 3
        Quatro = 4, // Carta de valor 4
        Cinco = 5,  // Carta de valor 5
        Seis = 6,   // Carta de valor 6
        Sete = 7,   // Carta de valor 7
        Oito = 8,   // Carta de valor 8
        Nove = 9,   // Carta de valor 9
        Dez = 10,   // Carta de valor 10
        Valete = 11,// Valete (J) 
        Dama = 12,  // Dama (Q) 
        Rei = 13    // Rei (K)
    }
}