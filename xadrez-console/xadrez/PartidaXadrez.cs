using tabuleiro;
using xadrez;

namespace xadrez_console.xadrez;

public class PartidaXadrez
{
  public Tabuleiro Tabuleiro { get; private set; }
  public int Turno { get; private set; }
  public Cor JogadorAtual { get; private set; }
  public bool Terminada { get; private set; }
  public bool Xeque { get; private set; }
  public HashSet<Peca> TodasPecas { get; private set; }
  public HashSet<Peca> PecasCapturadas { get; private set; }

  public PartidaXadrez()
  {
    Tabuleiro = new Tabuleiro(8, 8);
    TodasPecas = [];
    PecasCapturadas = [];

    Iniciar();
  }

  public void Iniciar()
  {
    Turno = 1;
    JogadorAtual = Cor.Branca;
    Terminada = false;
    Xeque = false;

    TodasPecas = [];
    PecasCapturadas = [];

    ColocarPecas();
  }

  public Peca? Movimente(Posicao origem, Posicao destino)
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
      return pecaCapturada;
    }

    return null;
  }

  public void RealizeJogada(Posicao origem, Posicao destino)
  {
    Peca? pecaCapturada = Movimente(origem, destino);

    if (EstaEmCheque(JogadorAtual))
    {
      DesfazMovimento(origem, destino, pecaCapturada);
      throw new TabuleiroException("Você não pode se colocar em xeque!");
    }

    if (EstaEmCheque(CorAdversaria(JogadorAtual)))
    {
      Xeque = true;
    }
    else
    {
      Xeque = false;
    }

    if (TesteXequeMate(CorAdversaria(JogadorAtual)))
    {
      Terminada = true;
    }
    else
    {
      Turno++;
      MudeJogador();
    }
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
      JogadorAtual = Cor.Branca;
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

  private Cor CorAdversaria(Cor cor)
  {
    if (cor == Cor.Branca)
    {
      return Cor.Preta;
    }
    return Cor.Branca;
  }

  private Peca? Rei(Cor cor)
  {
    foreach (Peca peca in PecasEmJogoPorCor(cor))
    {
      if (peca is Rei)
      {
        return peca;
      }
    }
    return null;
  }

  public bool EstaEmCheque(Cor cor)
  {
    Peca? rei = Rei(cor);
    if (rei == null)
    {
      throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro.");
    }

    foreach (Peca pecaAdversaria in PecasEmJogoPorCor(CorAdversaria(cor)))
    {
      bool[,] matriz = pecaAdversaria.MovimentosPossiveis();
      if (rei.Posicao != null && matriz[rei.Posicao.Linha, rei.Posicao.Coluna])
      {
        return true;
      }
    }
    return false;
  }

  public bool TesteXequeMate(Cor cor)
  {
    if (!EstaEmCheque(cor))
    {
      return false;
    }

    foreach (Peca peca in PecasEmJogoPorCor(cor))
    {
      bool[,] matriz = peca.MovimentosPossiveis();
      for (int i = 0; i < Tabuleiro.Linhas; i++)
      {
        for (int j = 0; j < Tabuleiro.Colunas; j++)
        {
          if (matriz[i, j])
          {
            Posicao origem = peca.Posicao!;
            Posicao destino = new(i, j);
            Peca? pecaCapturada = Movimente(origem, destino);
            bool testeXeque = EstaEmCheque(cor);
            DesfazMovimento(origem, destino, pecaCapturada);
            if (!testeXeque)
            {
              return false;
            }
          }
        }
      }
    }
    return true;
  }

  private void DesfazMovimento(Posicao origem, Posicao destino, Peca? pecaCapturada)
  {
    Peca? pecaMovida = Tabuleiro.RetirarPeca(destino);
    if (pecaMovida != null)
    {
      pecaMovida.DecrementarQtdMovimentos();

      if (pecaCapturada != null)
      {
        Tabuleiro.ColocarPeca(pecaCapturada, destino);
        PecasCapturadas.Remove(pecaCapturada);
      }

      Tabuleiro.ColocarPeca(pecaMovida, origem);
    }
  }

  private void ColocarNovaPeca(string referencia, Peca peca)
  {
    Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(referencia));
    TodasPecas.Add(peca);
  }

  private void ColocarPecas()
  {
    // ColocarNovaPeca("c1", new Torre(Tabuleiro, Cor.Branca));
    // ColocarNovaPeca("c2", new Torre(Tabuleiro, Cor.Branca));
    // ColocarNovaPeca("d2", new Torre(Tabuleiro, Cor.Branca));
    // ColocarNovaPeca("e2", new Torre(Tabuleiro, Cor.Branca));
    // ColocarNovaPeca("e1", new Torre(Tabuleiro, Cor.Branca));
    // ColocarNovaPeca("d1", new Rei(Tabuleiro, Cor.Branca));

    // ColocarNovaPeca("c7", new Torre(Tabuleiro, Cor.Preta));
    // ColocarNovaPeca("c8", new Torre(Tabuleiro, Cor.Preta));
    // ColocarNovaPeca("d7", new Torre(Tabuleiro, Cor.Preta));
    // ColocarNovaPeca("e7", new Torre(Tabuleiro, Cor.Preta));
    // ColocarNovaPeca("e8", new Torre(Tabuleiro, Cor.Preta));
    // ColocarNovaPeca("d8", new Rei(Tabuleiro, Cor.Preta));

    ColocarNovaPeca("c1", new Torre(Tabuleiro, Cor.Branca));
    ColocarNovaPeca("d1", new Rei(Tabuleiro, Cor.Branca));
    ColocarNovaPeca("h7", new Torre(Tabuleiro, Cor.Branca));

    ColocarNovaPeca("a8", new Rei(Tabuleiro, Cor.Preta));
    ColocarNovaPeca("b8", new Torre(Tabuleiro, Cor.Preta));
  }
}
