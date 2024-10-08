using tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console;

public class Tela
{
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

  public static PosicaoXadrez LerPosicaoXadrez()
  {
    string input = Console.ReadLine() ?? "";
    if (input.ToLower().Equals("exit"))
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
