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

          Console.Write("Origem: ");
          Posicao origem = Tela.LerPosicaoXadrez();
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
