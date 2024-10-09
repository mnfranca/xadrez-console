using tabuleiro;
using xadrez_console.xadrez;

namespace xadrez;

public class Rei : Peca
{
  private PartidaXadrez Partida;

  public Rei(Tabuleiro tabuleiro, Cor cor, PartidaXadrez partida) : base(tabuleiro, cor)
  {
    Partida = partida;
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

      // #jogada-especial Roque
      if (QtdMovimentos == 0 && !Partida.Xeque)
      {

        // #jogada-especial Roque pequeno
        Posicao posicaoTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
        if (TesteTorreParaRoque(posicaoTorre1))
        {
          Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
          Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
          if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null)
          {
            matriz[Posicao.Linha, Posicao.Coluna + 2] = true;
          }
        }

        // #jogada-especial Roque grande
        Posicao posicaoTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
        if (TesteTorreParaRoque(posicaoTorre2))
        {
          Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
          Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
          Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
          if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null)
          {
            matriz[Posicao.Linha, Posicao.Coluna - 2] = true;
          }
        }
      }

    }

    return matriz;
  }

  public override string ToString()
  {
    return "R";
  }

  private bool TesteTorreParaRoque(Posicao posicao)
  {
    Peca peca = Tabuleiro.Peca(posicao);
    return peca != null && peca is Torre && peca.Cor == Cor && peca.QtdMovimentos == 0;
  }
}
