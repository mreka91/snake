using System;
using System.Collections.Generic;


namespace Snake_game
{
    public class Snake
    {
        private List<BodyPart> _bodyParts = new List<BodyPart>();
        private const char Head = '@';
        private const char Body = 'o';

        private int directionX;
        private int directionY;
        
        
        public Snake() 
        {
            _bodyParts.Add(new BodyPart(10, 10, Head));
            _bodyParts.Add(new BodyPart(9, 10, Body));
            _bodyParts.Add(new BodyPart(8, 10, Body));
            directionX = 1;
            directionY = 0;
        }

        public void ChangeDirection(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    if (directionY == 0)
                    {
                        directionX = 0;
                        directionY = -1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (directionY == 0)
                    {
                        directionX = 0;
                        directionY = 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (directionX == 0)
                    {
                        directionX = -1;
                        directionY = 0;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (directionX == 0)
                    {
                        directionX = 1;
                        directionY = 0;
                    }
                    break;
            }
        }

        public void UpdateLocation()
        {
            for (int i = _bodyParts.Count-1; i > 0; i--)
            {
                _bodyParts[i].x = _bodyParts[i - 1].x;
                _bodyParts[i].y = _bodyParts[i - 1].y;
            }
            
            _bodyParts[0].x += directionX;
            _bodyParts[0].y += directionY;
        }

        public void Eat()
        {
            _bodyParts.Add(new BodyPart(_bodyParts[_bodyParts.Count - 1].x, _bodyParts[_bodyParts.Count - 1].y, Body));
           
        }

        public BodyPart GetBodyPartByIndex(int index)
        {
            return _bodyParts[index];
        }

        public int GetLength()
        {
            return _bodyParts.Count;
        }
    }
}