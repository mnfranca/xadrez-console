using tabuleiro;

namespace xadrez;

public class Peao : Peca
{
  public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
  {
  }

  public override bool[,] MovimentosPossiveis()
  {
    throw new NotImplementedException();
  }

  public override string ToString()
  {
    return "P";
  }

  protected override bool PodeMover(Posicao posicao)
  {
    throw new NotImplementedException();
  }
}
