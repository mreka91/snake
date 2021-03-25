using System;

namespace Snake_game
{
    //
    // This is the game event logic that you can customize and cannibalize
    // as needed. You should try to write your game in a modular way, avoid
    // making one huge Game class.
    //

    class Game
    {
        ScheduleTimer _timer;
        static Snake snake = new Snake();
        Rat rat = new Rat(snake);
        const int width = 20;
        const int height = 20;
        private bool isHungry = false;
        private int score = 0;
        public bool gameOver { get; set; } = false;
            
        enum CollisionState{
            None, Death, Eat
        };
        
        public bool Paused { get; private set; }

        public void Start()
        {
            Console.WriteLine("Start");
            rat.SetNewLocation();
            ScheduleNextTick();
        }

        public void Pause()
        {
            Console.WriteLine("Pause");
            Paused = true;
            _timer.Pause();
        }

        public void Resume()
        {
            Console.WriteLine("Resume");
            Paused = false;
            _timer.Resume();
        }

        public void Stop()
        {
            Console.WriteLine("Stop");
        }
        

        public void Input(ConsoleKey key)
        {
            Console.WriteLine($"Pressed key: {key}");
            snake.ChangeDirection(key);
        }

        void Tick()
        {
            Draw();
            if (isHungry)
            {
                snake.Eat();
                isHungry = false;
            }
            snake.UpdateLocation();
            switch (collision())
            {
                case CollisionState.Eat:
                    isHungry = true;
                    score++;
                    rat.SetNewLocation();
                    break;
                case CollisionState.Death: 
                    gameOver= true;
                    break;
            }
            ScheduleNextTick();
        }

        void ScheduleNextTick()
        {
            _timer = new ScheduleTimer(500, Tick);
        }


        void DrawLine()
        {
            for (int i = 0; i < width+1; i++)
            {
                Console.Write("x");
            }

            Console.WriteLine();
        }

        void DrawField()
        {
            
            for (int i = 0; i < height; i++) {
                string line= "";
                
                for (int j = 0; j < width; j++) {
                    if (j == 0) {
                        line += "x";
                    }else if (j == rat.x && i == rat.y) { 
                        line += rat.charToWrite;
                    }else {
                        bool printSnake = false;
                        for (int k = 0; k < snake.GetLength(); k++) {
                         
                            if (snake.GetBodyPartByIndex(k).x == j && snake.GetBodyPartByIndex(k).y == i) {
                                line += snake.GetBodyPartByIndex(k).charToWrite;
                                printSnake = true;
                            }
                        }
                        if (!printSnake) {
                            line += " ";
                        }
                    }
                    if (j == width - 1) {
                        line += "x";
                    }
                }

                Console.WriteLine(line);
            }
        }
        
        
        void Draw()
        {
            Console.Clear();
            DrawLine();
            DrawField();
            DrawLine();
            Console.WriteLine(score.ToString());
        }



        CollisionState collision()
        {
            if (snake.GetBodyPartByIndex(0).x == rat.x && snake.GetBodyPartByIndex(0).y == rat.y)
            {
                return CollisionState.Eat;
            }

            if (snake.GetBodyPartByIndex(0).x > width || snake.GetBodyPartByIndex(0).y > height || snake.GetBodyPartByIndex(0).x < 0 || snake.GetBodyPartByIndex(0).y < 0)
            {
                return CollisionState.Death;
            }

            for (int i = 1; i < snake.GetLength()-1; i++)
            {
                 if (snake.GetBodyPartByIndex(0).x == snake.GetBodyPartByIndex(i).x && snake.GetBodyPartByIndex(0).y == snake.GetBodyPartByIndex(i).y)
                 {
                    return CollisionState.Death;
                 }
            }
            return CollisionState.None;
        }
        
        public  void GameOver()
        {
            Console.WriteLine("Game over :-(");
            Console.WriteLine($"Your total score is {score}");
        }
    }
}