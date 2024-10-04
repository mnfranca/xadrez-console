using System;
using tabuleiro;

namespace xadrez_console.xadrez;

public class PosicaoXadrez : Posicao
{
  public PosicaoXadrez(string referencia) : base(ToLinha(referencia), ToColuna(referencia))
  {
  }

  private static int ToLinha(string referencia)
  {
    int linha = 8 - int.Parse(referencia.Substring(1, 1));
    if (linha < 0 || linha >= 8)
    {
      throw new TabuleiroException($"A posição {referencia} não é permitida no tabuleiro de xadrez.");
    }
    return linha;
  }

  private static int ToColuna(string referencia)
  {
    int coluna = referencia[..1].ToLower()[0] - 'a';
    if (coluna < 0 || coluna >= 8)
    {
      throw new TabuleiroException($"A posição {referencia} não é permitida no tabuleiro de xadrez.");
    }
    return coluna;
  }

  public override string ToString()
  {
    int coluna = 'a' + Coluna;
    return "" + (char)coluna + (8 - Linha);
  }
}
