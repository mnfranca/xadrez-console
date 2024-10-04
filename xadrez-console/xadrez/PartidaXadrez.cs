using tabuleiro;
using xadrez;

namespace xadrez_console.xadrez;

public class PartidaXadrez
{
  public Tabuleiro Tabuleiro { get; private set; }
  private int Turno;
  private Cor JogadorAtual;
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
    pecaOrigem.IncrementarQtdMovimentos();
    Peca? pecaDestino = Tabuleiro.RetirarPeca(destino);
    Tabuleiro.ColocarPeca(pecaOrigem, destino);
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
