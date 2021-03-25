namespace Snake_game
{
    public class BodyPart
    {
        public int x {get; set;}
        public int y{get; set;}
        public char charToWrite {get; set;}


        public BodyPart(int x, int y, char charToWrite)
        {
            this.x = x;
            this.y = y;
            this.charToWrite = charToWrite;
        }

        public BodyPart()
        {
            
        }
     
    }
}