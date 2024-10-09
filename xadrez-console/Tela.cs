using tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console;

public class Tela
{
  public static void ImprimirPartida(PartidaXadrez partida)
  {
    ImprimirTabuleiro(partida.Tabuleiro);

    Console.WriteLine();
    ImprimirPecasCapturadas(partida);

    Console.WriteLine();
    Console.WriteLine("Turno: " + partida.Turno);

    if (!partida.Terminada)
    {
      Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
      if (partida.Xeque)
      {
        Console.WriteLine("XEQUE!");
      }
    }
    else
    {
      Console.WriteLine("XEQUEMATE!");
      Console.WriteLine("Vencedor: " + partida.JogadorAtual);
    }
  }

  public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
  {
    for (int i = 0; i < tabuleiro.Linhas; i++)
    {
      Console.Write(8 - i + " ");
      for (int j = 0; j < tabuleiro.Colunas; j++)
      {
        Tela.ImprimirPeca(tabuleiro.Peca(i, j));
      }
      Console.WriteLine();
    }
    Console.WriteLine("  a b c d e f g h");
  }

  public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
  {
    ConsoleColor fundoOriginal = Console.BackgroundColor;
    ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

    for (int i = 0; i < tabuleiro.Linhas; i++)
    {
      Console.Write(8 - i + " ");
      for (int j = 0; j < tabuleiro.Colunas; j++)
      {
        if (posicoesPossiveis[i, j])
        {
          Console.BackgroundColor = fundoAlterado;
        }
        else
        {
          Console.BackgroundColor = fundoOriginal;
        }
        Tela.ImprimirPeca(tabuleiro.Peca(i, j));
        Console.BackgroundColor = fundoOriginal;
      }
      Console.WriteLine();
    }
    Console.WriteLine("  a b c d e f g h");
    Console.BackgroundColor = fundoOriginal;
  }

  private static void ImprimirPecasCapturadas(PartidaXadrez partida)
  {
    Console.WriteLine("Peças capturadas:");
    Console.Write("Brancas: ");
    ImprimirConjunto(partida.PecasCapturadasPorCor(Cor.Branca));
    Console.WriteLine();
    Console.Write("Pretas: ");
    ConsoleColor corAtual = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Yellow;
    ImprimirConjunto(partida.PecasCapturadasPorCor(Cor.Preta));
    Console.ForegroundColor = corAtual;
    Console.WriteLine();
  }

  private static void ImprimirConjunto(HashSet<Peca> pecas)
  {
    Console.Write("[ ");
    foreach (Peca peca in pecas)
    {
      Console.Write(peca + " ");
    }
    Console.Write("]");
  }

  public static PosicaoXadrez LerPosicaoXadrez(PartidaXadrez partida)
  {
    string input = Console.ReadLine() ?? "";
    if (input.ToLower().Equals("q"))
    {
      Environment.Exit(0);
    }
    return new PosicaoXadrez(input);
  }

  public static void ImprimirPeca(Peca peca)
  {
    if (peca == null)
    {
      Console.Write("-");
    }
    else
    {
      if (peca.Cor == Cor.Branca)
      {
        Console.Write(peca);
      }
      else
      {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(peca);
        Console.ForegroundColor = originalColor;
      }
    }
    Console.Write(" ");
  }
}
