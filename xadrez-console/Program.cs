﻿using tabuleiro;

namespace xadrez_console
{
  class Program
  {
    static void Main(string[] args)
    {
      Tabuleiro tabuleiro = new Tabuleiro(8, 8);

      Console.WriteLine(tabuleiro);

      Console.ReadLine();
    }
  }
}
