using System;
using System.Collections.Generic;

namespace Bowling
{
    public class Frame
    {
        public const int MAX_NUMBER_PINS = 10;

        private int extraPointsAmount;
        private int extraPoints;
        private int? numberOfPinsChance1;
        private int? numberOfPinsChance2;
        
        public int BonusAmount => extraPointsAmount;

        public int GetPoints()
        {
            return numberOfPinsChance1.GetValueOrDefault() + numberOfPinsChance2.GetValueOrDefault() + extraPoints;
        }

        public bool IsComplete()
        {
            if (IsStrike())
                return true;
            return numberOfPinsChance1.HasValue && numberOfPinsChance2.HasValue;
        }

        public bool IsSpare()
        {
            if (numberOfPinsChance1.HasValue && numberOfPinsChance2.HasValue)
                return (numberOfPinsChance1 + numberOfPinsChance2) == MAX_NUMBER_PINS;
            return false;
        }

        public bool IsStrike()
        {
            if (numberOfPinsChance1.HasValue)
                return numberOfPinsChance1 == MAX_NUMBER_PINS;
            return false;
        }

        public void Play(int pins)
        {
            validatePlay(pins);

            if (!numberOfPinsChance1.HasValue)
                numberOfPinsChance1 = pins;
            else
                numberOfPinsChance2 = pins;
        }

        private void validatePlay(int pins)
        {
            if (IsComplete()) throw new Exception("Frame is complete");
            var frameTotalPins = numberOfPinsChance1.GetValueOrDefault() + pins;
            if (pins < 0 || frameTotalPins > MAX_NUMBER_PINS) throw new ArgumentOutOfRangeException("pins");
        }

        public void AddBonus(int points)
        {
            if (!IsStrike() && !IsSpare())
                throw new Exception("Frame can not have bonus");

            extraPointsAmount++;
            extraPoints += points;
        }

    }
}