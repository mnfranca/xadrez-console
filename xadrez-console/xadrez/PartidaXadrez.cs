using tabuleiro;
using xadrez;

namespace xadrez_console.xadrez;

public class PartidaXadrez
{
  public Tabuleiro Tabuleiro { get; private set; }
  public int Turno { get; private set; }
  public Cor JogadorAtual { get; private set; }
  public bool Terminada { get; private set; }

  public PartidaXadrez()
  {
    Tabuleiro = new Tabuleiro(8, 8);
    Turno = 1;
    JogadorAtual = Cor.Branca;
    Terminada = false;

    ColocarPecas();
  }

  public void Movimente(Posicao origem, Posicao destino)
  {
    Peca? pecaOrigem = Tabuleiro.RetirarPeca(origem);
    if (pecaOrigem != null)
    {
      pecaOrigem.IncrementarQtdMovimentos();
      Peca? pecaDestino = Tabuleiro.RetirarPeca(destino);
      Tabuleiro.ColocarPeca(pecaOrigem, destino);
    }
  }

  public void RealizeJogada(Posicao origem, Posicao destino)
  {
    Movimente(origem, destino);
    Turno++;
    MudeJogador();
  }

  public void ValidePosicaoOrigem(Posicao posicao)
  {
    if (Tabuleiro.Peca(posicao) == null)
    {
      throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
    }
    if (JogadorAtual != Tabuleiro.Peca(posicao).Cor)
    {
      throw new TabuleiroException("A peça de origem escolhida não é sua!");
    }
    if (!Tabuleiro.Peca(posicao).ExisteMovimentosPossiveis())
    {
      throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
    }
  }

  public void ValidePosicaoDestino(Posicao origem, Posicao destino)
  {
    if (!Tabuleiro.Peca(origem).PodeMoverPara(destino))
    {
      throw new TabuleiroException("Posição de destino inválida!");
    }
  }

  public void MudeJogador()
  {
    if (JogadorAtual == Cor.Branca)
    {
      JogadorAtual = Cor.Preta;
    }
    else
    {
      JogadorAtual = Cor.Preta;
    }
  }

  private void ColocarPecas()
  {
    Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez("c1"));
    Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez("c2"));
    Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez("d2"));
    Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez("e2"));
    Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez("e1"));
    Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrez("d1"));

    Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez("c7"));
    Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez("c8"));
    Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez("d7"));
    Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez("e7"));
    Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez("e8"));
    Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preta), new PosicaoXadrez("d8"));
  }
}
