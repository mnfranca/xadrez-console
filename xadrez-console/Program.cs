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
            Tela.ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

            Console.WriteLine();
            Console.Write("Origem ('exit' para sair): ");
            Posicao origem = Tela.LerPosicaoXadrez();
            partida.ValidePosicaoOrigem(origem);

            bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();

            Console.Clear();
            Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

            Console.WriteLine();
            Console.Write("Destino ('exit' para sair): ");
            Posicao destino = Tela.LerPosicaoXadrez();
            partida.ValidePosicaoDestino(origem, destino);

            partida.RealizeJogada(origem, destino);
          }
          catch (TabuleiroException e)
          {
            Console.WriteLine(e.Message);
            Console.ReadLine();
          }
        }

      }
      catch (TabuleiroException e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}
