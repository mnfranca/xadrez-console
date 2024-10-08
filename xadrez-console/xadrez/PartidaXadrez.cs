using tabuleiro;
using xadrez;

namespace xadrez_console.xadrez;

public class PartidaXadrez
{
  public Tabuleiro Tabuleiro { get; private set; }
  public int Turno { get; private set; }
  public Cor JogadorAtual { get; private set; }
  public bool Terminada { get; private set; }
  private readonly HashSet<Peca> TodasPecas;
  private readonly HashSet<Peca> PecasCapturadas;

  public PartidaXadrez()
  {
    Tabuleiro = new Tabuleiro(8, 8);
    Turno = 1;
    JogadorAtual = Cor.Branca;
    Terminada = false;

    TodasPecas = [];
    PecasCapturadas = [];

    ColocarPecas();
  }

  public void Movimente(Posicao origem, Posicao destino)
  {
    Peca? pecaOrigem = Tabuleiro.RetirarPeca(origem);
    if (pecaOrigem != null)
    {
      pecaOrigem.IncrementarQtdMovimentos();
      Peca? pecaCapturada = Tabuleiro.RetirarPeca(destino);
      Tabuleiro.ColocarPeca(pecaOrigem, destino);
      if (pecaCapturada != null)
      {
        PecasCapturadas.Add(pecaCapturada);
      }
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

  public HashSet<Peca> PecasCapturadasPorCor(Cor cor)
  {
    HashSet<Peca> pecas = [];
    foreach (var peca in PecasCapturadas)
    {
      if (peca.Cor == cor)
      {
        pecas.Add(peca);
      }
    }
    return pecas;
  }

  public HashSet<Peca> PecasEmJogoPorCor(Cor cor)
  {
    HashSet<Peca> pecas = [];
    foreach (var peca in TodasPecas)
    {
      if (peca.Cor == cor)
      {
        pecas.Add(peca);
      }
    }
    pecas.ExceptWith(PecasCapturadasPorCor(cor));
    return pecas;
  }

  private void ColocarNovaPeca(string referencia, Peca peca)
  {
    Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(referencia));
    TodasPecas.Add(peca);
  }

  private void ColocarPecas()
  {
    ColocarNovaPeca("c1", new Torre(Tabuleiro, Cor.Branca));
    ColocarNovaPeca("c2", new Torre(Tabuleiro, Cor.Branca));
    ColocarNovaPeca("d2", new Torre(Tabuleiro, Cor.Branca));
    ColocarNovaPeca("e2", new Torre(Tabuleiro, Cor.Branca));
    ColocarNovaPeca("e1", new Torre(Tabuleiro, Cor.Branca));
    ColocarNovaPeca("d1", new Rei(Tabuleiro, Cor.Branca));

    ColocarNovaPeca("c7", new Torre(Tabuleiro, Cor.Preta));
    ColocarNovaPeca("c8", new Torre(Tabuleiro, Cor.Preta));
    ColocarNovaPeca("d7", new Torre(Tabuleiro, Cor.Preta));
    ColocarNovaPeca("e7", new Torre(Tabuleiro, Cor.Preta));
    ColocarNovaPeca("e8", new Torre(Tabuleiro, Cor.Preta));
    ColocarNovaPeca("d8", new Rei(Tabuleiro, Cor.Preta));
  }
}
