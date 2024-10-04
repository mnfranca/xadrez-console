using tabuleiro;

namespace xadrez;

public class Bispo : Peca
{
  public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
  {
  }

  public override bool[,] MovimentosPossiveis()
  {
    throw new NotImplementedException();
  }

  public override string ToString()
  {
    return "B";
  }

  protected override bool PodeMover(Posicao posicao)
  {
    throw new NotImplementedException();
  }
}
