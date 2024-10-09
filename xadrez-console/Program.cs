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
          try
          {
            Console.Clear();
            Tela.ImprimirPartida(partida);

            Console.WriteLine();
            Console.Write("Origem ('q' para sair): ");
            Posicao origem = Tela.LerPosicaoXadrez(partida);
            partida.ValidePosicaoOrigem(origem);

            bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();

            Console.Clear();
            Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

            Console.WriteLine();
            Console.Write("Destino ('q' para sair): ");
            Posicao destino = Tela.LerPosicaoXadrez(partida);
            partida.ValidePosicaoDestino(origem, destino);

            partida.RealizeJogada(origem, destino);
          }
          catch (TabuleiroException e)
          {
            Console.WriteLine(e.Message);
            Console.ReadLine();
          }
        }

        Console.Clear();
        Tela.ImprimirPartida(partida);

      }
      catch (TabuleiroException e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}
