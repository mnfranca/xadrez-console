using tabuleiro;

namespace xadrez;

public class Peao : Peca
{
  public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
  {
  }

  public override bool[,] MovimentosPossiveis()
  {
    bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

    if (Posicao != null)
    {
      Posicao outraPosicao = new(0, 0);

      if (Cor == Cor.Branca)
      {
        outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
        if (Tabuleiro.PosicaoValida(outraPosicao) && Livre(outraPosicao))
        {
          matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        }
        outraPosicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
        if (Tabuleiro.PosicaoValida(outraPosicao) && Livre(outraPosicao) && QtdMovimentos == 0)
        {
          matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        }
        outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        if (Tabuleiro.PosicaoValida(outraPosicao) && ExisteInimigo(outraPosicao))
        {
          matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        }
        outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        if (Tabuleiro.PosicaoValida(outraPosicao) && ExisteInimigo(outraPosicao))
        {
          matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        }
      }
      else
      {
        outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        if (Tabuleiro.PosicaoValida(outraPosicao) && Livre(outraPosicao))
        {
          matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        }
        outraPosicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
        if (Tabuleiro.PosicaoValida(outraPosicao) && Livre(outraPosicao) && QtdMovimentos == 0)
        {
          matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        }
        outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        if (Tabuleiro.PosicaoValida(outraPosicao) && ExisteInimigo(outraPosicao))
        {
          matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        }
        outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        if (Tabuleiro.PosicaoValida(outraPosicao) && ExisteInimigo(outraPosicao))
        {
          matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        }
      }
    }

    return matriz;
  }

  private bool ExisteInimigo(Posicao posicao)
  {
    Peca outraPeca = Tabuleiro.Peca(posicao);
    return outraPeca != null && outraPeca.Cor != Cor;
  }

  private bool Livre(Posicao posicao)
  {
    return Tabuleiro.Peca(posicao) == null;
  }

  public override string ToString()
  {
    return "P";
  }
}
