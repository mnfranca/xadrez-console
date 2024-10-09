using tabuleiro;

namespace xadrez;

public class Rei : Peca
{
  public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
  {
  }

  public override bool[,] MovimentosPossiveis()
  {
    bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

    if (Posicao != null)
    {
      Posicao outraPosicao = new(0, 0);

      // Norte
      outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Nordeste
      outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Leste
      outraPosicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Suldeste
      outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Sul
      outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Sudoeste
      outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Oeste
      outraPosicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }

      // Noroeste
      outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
      if (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
      }
    }

    return matriz;
  }

  public override string ToString()
  {
    return "R";
  }
}
