using tabuleiro;

namespace xadrez;

public class Bispo : Peca
{
  public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
  {
  }

  public override string ToString()
  {
    return "B";
  }
}
