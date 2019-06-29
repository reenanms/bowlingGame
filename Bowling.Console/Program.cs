using System;
using System.IO;

namespace Bowling
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var game = new JogoDeBoliche();
            
            Console.WriteLine($"Jogando quadro 1: 1, 4");
            game.Jogar(1);
            game.Jogar(4);

            Console.WriteLine($"Jogando quadro 2: 4, 5");
            game.Jogar(4);
            game.Jogar(5);

            Console.WriteLine($"Jogando quadro 3: 6, 4");
            game.Jogar(6);
            game.Jogar(4);

            Console.WriteLine($"Jogando quadro 4: 5, 5");
            game.Jogar(5);
            game.Jogar(5);

            Console.WriteLine($"Jogando quadro 5: 10, x");
            game.Jogar(10);

            Console.WriteLine($"Jogando quadro 6: 0, 1");
            game.Jogar(0);
            game.Jogar(1);
            
            Console.WriteLine($"Jogando quadro 7: 7, 3");
            game.Jogar(7);
            game.Jogar(3);

            Console.WriteLine($"Jogando quadro 8: 6, 4");
            game.Jogar(6);
            game.Jogar(4);

            Console.WriteLine($"Jogando quadro 9: 10, x");
            game.Jogar(10);

            Console.WriteLine($"Jogando quadro 10: 2, 8, 6");
            game.Jogar(2);
            game.Jogar(8);
            game.Jogar(6);

            Console.WriteLine("Resumo do jogo...");
            Console.WriteLine(game.ToString());
        }
    }
}
