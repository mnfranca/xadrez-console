using tabuleiro;
using xadrez;
using xadrez_console.xadrez;

namespace xadrez_console
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        PartidaXadrez partida = new PartidaXadrez();

        while (!partida.Terminada)
        {
          Console.Clear();
          Tela.ImprimirTabuleiro(partida.Tabuleiro);

          Console.WriteLine();
          Console.Write("Origem: ");
          Posicao origem = Tela.LerPosicaoXadrez();

          bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();

          Console.Clear();
          Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

          Console.WriteLine();
          Console.Write("Destino: ");
          Posicao destino = Tela.LerPosicaoXadrez();

          partida.Movimente(origem, destino);
        }

      }
      catch (TabuleiroException e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}
