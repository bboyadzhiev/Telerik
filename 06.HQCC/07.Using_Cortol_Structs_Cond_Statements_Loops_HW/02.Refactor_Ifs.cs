// 2. Refactor the following if statements
class Program
{
    private void Main()
    {
        //part 1
        Potato potato;
        //... 
        if (potato != null)
        {
            bool potatoIsReady = potato.HasBeenPeeled && potato.IsNotRotten;

            if (potatoIsReady)
	        {
		        Cook(potato);
	        }
        }

        //part 2
        bool xIsInRange = (MIN_X <= x) && (x =< MAX_X);
        bool yIsInRange = (MIN_Y <= y) && (y <= MAX_Y);

        if (xIsInRange && yIsInRange && shouldVisitCell)
        {
           VisitCell();
        }

    }
}

