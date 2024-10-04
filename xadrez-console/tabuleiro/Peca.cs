namespace tabuleiro;

public abstract class Peca
{
  public Posicao? Posicao { get; set; }
  public Cor Cor { get; protected set; }
  public int QtdMovimentos { get; protected set; }
  public Tabuleiro Tabuleiro { get; protected set; }

  public Peca(Tabuleiro tabuleiro, Cor cor)
  {
    Tabuleiro = tabuleiro;
    Cor = cor;
    QtdMovimentos = 0;
  }

  public void IncrementarQtdMovimentos()
  {
    QtdMovimentos++;
  }

  protected abstract bool PodeMover(Posicao posicao);

  public abstract bool[,] MovimentosPossiveis();
}
