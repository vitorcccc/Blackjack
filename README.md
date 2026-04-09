

# 🃏 BLACKJACK 21 - Jogo de Cartas

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Console](https://img.shields.io/badge/Console-4EAA25?style=for-the-badge&logo=windows-terminal&logoColor=white)

## 👥 INTEGRANTES DO GRUPO

| Nome | RM |
|------|-----|
| **Isadora Meneghetti** | RM556326 |
| **Gustavo Ikeda** | RM554718 |
| **Henrique Azevedo** | RM556707 |
| **Renato Alvarenga** | RM556403 |
| **Victoria Moura** | RM555474 |

---

## 📚 DISCIPLINA

**Estruturas de Controle de Fluxo e Métodos em C#**

**Professor:** Vinícius Costa Santos

**Instituição:** FACULDADE FIAP

**Ano:** 2026

---

## 📋 SOBRE O PROJETO

Este é um jogo de **Blackjack (21)** desenvolvido em C#. 

O jogo permite que o usuário jogue contra o computador, acumule pontos e visualize o histórico das partidas.

---

## 🎮 REGRAS DO JOGO

- O objetivo é chegar o mais próximo possível de 21 pontos sem ultrapassar
- Cartas numéricas (2-10): valem seu número
- Valete, Dama, Rei: valem 10 pontos
- Ás: vale 11 ou 1 (ajustado automaticamente)
- Cada jogador começa com 2 cartas
- Você pode **comprar** (Hit) ou **parar** (Stand)
- O computador compra até atingir 17 pontos ou mais
- Quem tiver a pontuação mais alta (sem estourar 21) vence

---

## 🎮 COMO JOGAR

1. Execute o programa
2. Digite seu nome para começar
3. Durante sua vez, escolha:
   - **[1] Comprar carta (Hit)** - Recebe uma nova carta
   - **[2] Parar (Stand)** - Encerra sua jogada
4. Após cada rodada, escolha se quer jogar novamente (S/N)

---

## 📊 SISTEMA DE PONTUAÇÃO

- **Vitória:** +100 pontos
- **Derrota:** 0 pontos
- **Empate:** 0 pontos
- O placar acumula pontos durante toda a partida
- Ao final, é exibido o histórico completo de todas as rodadas

---

## 🧠 CONCEITOS APLICADOS

| Conceito | Aplicação no Projeto |
|----------|----------------------|
| **Classes e Objetos** | `BlackjackGame`, `Baralho`, `Jogador`, `Partida`, `Rodada` |
| **Métodos** | `IniciarJogo()`, `VezDoJogador()`, `DeterminarVencedor()` |
| **Estruturas de decisão** | `if/else` para regras do Blackjack |
| **Estruturas de repetição** | `while` para rodadas e compra de cartas |
| **Listas** | `List<Jogador>`, `List<Carta>`, `List<Movimento>` |
| **Encapsulamento** | Campos privados, métodos públicos/privados |
| **Enumerações** | `ValorCarta`, `Naipe` |

---

<p align="center">
  Desenvolvido com ❤️ pelos alunos da FIAP
</p>