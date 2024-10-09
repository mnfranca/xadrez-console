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

  public void DecrementarQtdMovimentos()
  {
    QtdMovimentos--;
  }

  public bool ExisteMovimentosPossiveis()
  {
    bool[,] matriz = MovimentosPossiveis();
    for (int i = 0; i < Tabuleiro.Linhas; i++)
    {
      for (int j = 0; j < Tabuleiro.Colunas; j++)
      {
        if (matriz[i, j])
          return true;
      }
    }
    return false;
  }

  public bool MovimentoPossivel(Posicao posicao)
  {
    return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
  }

  protected bool PodeMover(Posicao posicao)
  {
    Peca outraPeca = Tabuleiro.Peca(posicao);
    return outraPeca == null || outraPeca.Cor != Cor;
  }

  public abstract bool[,] MovimentosPossiveis();
}
