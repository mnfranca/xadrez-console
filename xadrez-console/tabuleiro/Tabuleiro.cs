namespace tabuleiro;

public class Tabuleiro
{
  public int Linhas { get; set; }
  public int Colunas { get; set; }
  private readonly Peca[,] Pecas;

  public Tabuleiro(int linhas, int colunas)
  {
    Linhas = linhas;
    Colunas = colunas;
    Pecas = new Peca[linhas, colunas];
  }

  public Peca Peca(int linha, int coluna)
  {
    return Pecas[linha, coluna];
  }

  public Peca Peca(Posicao posicao)
  {
    return Pecas[posicao.Linha, posicao.Coluna];
  }

  public void ColocarPeca(Peca peca, Posicao posicao)
  {
    ValidarPosicaoOcupada(posicao);
    Pecas[posicao.Linha, posicao.Coluna] = peca;
    peca.Posicao = posicao;
  }

  public Peca? RetirarPeca(Posicao posicao)
  {
    if (Peca(posicao) == null)
    {
      return null;
    }
    Peca aux = Peca(posicao);
    aux.Posicao = null;
    Pecas[posicao.Linha, posicao.Coluna] = null!;
    return aux;
  }

  public bool PosicaoValida(Posicao posicao)
  {
    if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
    {
      return false;
    }
    return true;
  }

  public bool ExistePeca(Posicao posicao)
  {
    ValidarPosicao(posicao);
    return Peca(posicao) != null;
  }

  public void ValidarPosicao(Posicao posicao)
  {
    if (!PosicaoValida(posicao))
    {
      throw new TabuleiroException("Posição inválida!");
    }
  }

  public void ValidarPosicaoOcupada(Posicao posicao)
  {
    if (ExistePeca(posicao))
    {
      throw new TabuleiroException("Já existe uma peça nessa posição!");
    }
  }
}
