using System;
using NUnit.Framework;
using Bowling;

namespace Bowling.Test
{
    public class GameTests
    {

        [Test]
        public void EndingGame()
        {
            var gameWithSpare = createGamesWith9Frames();

            //Playing frame 10: 2, 8, 6
            gameWithSpare.Play(2);
            gameWithSpare.Play(8);
            gameWithSpare.Play(6);

            var gameWithStrike = createGamesWith9Frames();

            //Playing frame 10: 10, 10, 10
            gameWithStrike.Play(10);
            gameWithStrike.Play(10);
            gameWithStrike.Play(10);

            Game gameNormal= createGamesWith9Frames();

            //Playing frame 10: 2, 2
            gameNormal.Play(2);
            gameNormal.Play(2);


            Assert.AreEqual(gameWithSpare.GetPoints(), 133);
            Assert.AreEqual(gameWithStrike.GetPoints(), 157);
            Assert.AreEqual(gameNormal.GetPoints(), 115);
        }

        [Test]
        public void ErrorDoingMorePlays()
        {
            var gameWithSpare = createGamesWith9Frames();

            //Playing frame 10: 2, 8, 6
            gameWithSpare.Play(2);
            gameWithSpare.Play(8);
            gameWithSpare.Play(6);

            var gameWithStrike = createGamesWith9Frames();

            //Playing frame 10: 10, 10, 10
            gameWithStrike.Play(10);
            gameWithStrike.Play(10);
            gameWithStrike.Play(10);

            Game gameNormal= createGamesWith9Frames();

            //Playing frame 10: 2, 2
            gameNormal.Play(2);
            gameNormal.Play(2);


            Assert.Throws<Exception>(() => gameWithSpare.Play(1));
            Assert.Throws<Exception>(() => gameWithStrike.Play(1));
            Assert.Throws<Exception>(() => gameNormal.Play(1));
        }

        [Test]
        public void ErrorDoingWrongInputs()
        {
            var game = new Game();
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Play(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Play(11));
        }

        private Game createGamesWith9Frames()
        {
            var game = new Game();

            //Playing frame 1: 1, 4
            game.Play(1);
            game.Play(4);

            //Playing frame 2: 4, 5
            game.Play(4);
            game.Play(5);

            //Playing frame 3: 6, 4
            game.Play(6);
            game.Play(4);

            //Playing frame 4: 5, 5
            game.Play(5);
            game.Play(5);

            //Playing frame 5: 10, x
            game.Play(10);

            //Playing frame 6: 0, 1
            game.Play(0);
            game.Play(1);

            //Playing frame 7: 7, 3
            game.Play(7);
            game.Play(3);

            //Playing frame 8: 6, 4
            game.Play(6);
            game.Play(4);

            //Playing frame 9: 10, x
            game.Play(10);


            return game;
        }
    }
}