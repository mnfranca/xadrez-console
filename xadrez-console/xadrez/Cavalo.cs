using tabuleiro;

namespace xadrez;

public class Cavalo : Peca
{
  public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
  {
  }

  public override bool[,] MovimentosPossiveis()
  {
    bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

    if (Posicao != null)
    {
      Posicao outraPosicao = new(0, 0);

      // Norte (1)
      outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Norte (2)
      outraPosicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Norte (3)
      outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Norte (4)
      outraPosicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Leste (1)
      outraPosicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Leste (2)
      outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Leste (3)
      outraPosicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Leste (4)
      outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Sul (1)
      outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Sul (2)
      outraPosicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Sul (3)
      outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Sul (4)
      outraPosicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Oeste (1)
      outraPosicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Oeste (2)
      outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Oeste (3)
      outraPosicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Oeste (4)
      outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }
    }

    return matriz;
  }

  public override string ToString()
  {
    return "C";
  }
}