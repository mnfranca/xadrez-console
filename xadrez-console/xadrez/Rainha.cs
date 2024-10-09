using tabuleiro;

namespace xadrez;

public class Rainha : Peca
{
  public Rainha(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
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
      while (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        if (Tabuleiro.Peca(outraPosicao) != null && Tabuleiro.Peca(outraPosicao).Cor != Cor)
        {
          break;
        }
        outraPosicao.Linha--;
      }

      // Leste
      outraPosicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
      while (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        if (Tabuleiro.Peca(outraPosicao) != null && Tabuleiro.Peca(outraPosicao).Cor != Cor)
        {
          break;
        }
        outraPosicao.Coluna++;
      }

      // Sul
      outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
      while (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        if (Tabuleiro.Peca(outraPosicao) != null && Tabuleiro.Peca(outraPosicao).Cor != Cor)
        {
          break;
        }
        outraPosicao.Linha++;
      }

      // Oeste
      outraPosicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
      while (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        if (Tabuleiro.Peca(outraPosicao) != null && Tabuleiro.Peca(outraPosicao).Cor != Cor)
        {
          break;
        }
        outraPosicao.Coluna--;
      }

      // Noroeste
      outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
      while (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        if (Tabuleiro.Peca(outraPosicao) != null && Tabuleiro.Peca(outraPosicao).Cor != Cor)
        {
          break;
        }
        outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
      }

      // Nordeste
      outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
      while (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        if (Tabuleiro.Peca(outraPosicao) != null && Tabuleiro.Peca(outraPosicao).Cor != Cor)
        {
          break;
        }
        outraPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
      }

      // Sudeste
      outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
      while (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        if (Tabuleiro.Peca(outraPosicao) != null && Tabuleiro.Peca(outraPosicao).Cor != Cor)
        {
          break;
        }
        outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
      }

      // Sudoeste
      outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
      while (Tabuleiro.PosicaoValida(outraPosicao) && PodeMover(outraPosicao))
      {
        matriz[outraPosicao.Linha, outraPosicao.Coluna] = true;
        if (Tabuleiro.Peca(outraPosicao) != null && Tabuleiro.Peca(outraPosicao).Cor != Cor)
        {
          break;
        }
        outraPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
      }
    }

    return matriz;
  }

  public override string ToString()
  {
    return "D";
  }
}
