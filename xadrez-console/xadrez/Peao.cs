using tabuleiro;

namespace xadrez;

public class Peao : Peca
{
  public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
  {
  }

  public override string ToString()
  {
    return "P";
  }
}
