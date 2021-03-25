using System;

namespace Snake_game
{
    public class Rat : BodyPart
    {
        private Snake _snake;
        
        public Rat(Snake snake)
        {
            _snake = snake;
            charToWrite = 'ö';
        }

        public void SetNewLocation()
        {
            bool foundFreeLocation = false;

            Random rnd = new Random();

            while (!foundFreeLocation)
            {
                x = rnd.Next(1,20);
                y = rnd.Next(1,20);
                foundFreeLocation = true;
                for (int i = 0; i < _snake.GetLength()-1; i++)
                {
                    if (_snake.GetBodyPartByIndex(i).x == x && _snake.GetBodyPartByIndex(i).y == y)
                    {
                        foundFreeLocation = false;
                    }
                    
                }
            }
        }
    }
}