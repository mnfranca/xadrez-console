using tabuleiro;

namespace xadrez;

public class Rainha : Peca
{
  public Rainha(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
  {
  }

  public override bool[,] MovimentosPossiveis()
  {
    throw new NotImplementedException();
  }

  public override string ToString()
  {
    return "R";
  }

  protected override bool PodeMover(Posicao posicao)
  {
    throw new NotImplementedException();
  }
}
