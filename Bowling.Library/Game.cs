using System;
using System.Collections.Generic;

namespace Bowling
{
    public class Game
    {
        private const int MAX_NUMBER_FRAMES = 10;
        private const int MAX_NUMBER_OF_PLAYS_ON_LAST_FRAME = 3;


        private List<Frame> frames;
        private int numberOfPlaysLastFrame;

        public Game()
        {
            frames = new List<Frame>(MAX_NUMBER_FRAMES);
        }

        public bool IsComplete()
        {
            if (frames.Count == MAX_NUMBER_FRAMES)
                return frames[MAX_NUMBER_FRAMES-1].IsComplete() && !isBonusMode();
            return false;
        }

        public bool isBonusMode()
        {
            if (frames.Count == MAX_NUMBER_FRAMES)
            {
                if (frames[MAX_NUMBER_FRAMES-1].IsSpare() || frames[MAX_NUMBER_FRAMES-1].IsStrike())
                    return numberOfPlaysLastFrame < MAX_NUMBER_OF_PLAYS_ON_LAST_FRAME;             
            }

            return false;
        }

        public void Play(int pinos)
        {
            if (IsComplete())
                throw new Exception("Game has already finished");

            if (!isBonusMode())
            {
                if (needNewFrame())
                    createNewFrame();
                frames[frames.Count-1].Play(pinos);
                addPointsFramesSpare(pinos);
                addPointsFramesStrike(pinos);
            }
            else
            {
                addPointsBonusFrame(pinos);
                addPointsFramesSpare(pinos);
                addPointsFramesStrike(pinos);
            }
            sumNumeberOfPlaysOnLastFrame();
        }

        private void sumNumeberOfPlaysOnLastFrame()
        {
            if (frames.Count == MAX_NUMBER_FRAMES)
                numberOfPlaysLastFrame++;
        }

        private void addPointsBonusFrame(int pinos)
        {
            frames[MAX_NUMBER_FRAMES-1].AddBonus(pinos);
        }

        private void addPointsFramesSpare(int pinos)
        { 
            if (frames.Count > 1 && frames[frames.Count-2].IsSpare() && frames[frames.Count-2].BonusAmount < 1)
                frames[frames.Count-2].AddBonus(pinos);
        }

        private void addPointsFramesStrike(int pinos)
        {
            if (frames.Count > 1 && frames[frames.Count-2].IsStrike() && frames[frames.Count-2].BonusAmount < 2)
                frames[frames.Count-2].AddBonus(pinos);
                
            if (frames.Count > 2 && frames[frames.Count-3].IsStrike() && frames[frames.Count-3].BonusAmount < 2)
                frames[frames.Count-3].AddBonus(pinos);
        }

        private void createNewFrame()
        {
            frames.Add(new Frame());
        }

        private bool needNewFrame()
        {
            if (frames.Count == 0)
                return true;
            return frames[frames.Count-1].IsComplete();
        }

        public int GetPoints()
        {
            int points = 0;
            frames.ForEach(f => points += f.GetPoints());
            return points;
        }

        public override string ToString()
        {
            var gameInString = string.Empty;
            var gamePoints = 0;
            for(int i = 0; i < frames.Count; i++)
            {
                var points = frames[i].GetPoints();
                gamePoints += points;
                gameInString += $"frame {i+1}: {points} points; game: {gamePoints} points{Environment.NewLine}";
            }

            return gameInString;
        } 
    }
}