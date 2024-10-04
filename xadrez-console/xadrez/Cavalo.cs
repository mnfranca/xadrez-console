using tabuleiro;

namespace xadrez;

public class Cavalo : Peca
{
  public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
  {
  }

  public override bool[,] MovimentosPossiveis()
  {
    throw new NotImplementedException();
  }

  public override string ToString()
  {
    return "C";
  }

  protected override bool PodeMover(Posicao posicao)
  {
    throw new NotImplementedException();
  }
}
