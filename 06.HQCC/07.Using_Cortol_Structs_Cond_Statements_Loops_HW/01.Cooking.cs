// 1. Refactor the following class using best practices for organizing straight-line code:
class Program
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = GetPotato();
            Peel(potato);
            Cut(potato);

            Carrot carrot = GetCarrot();
            Peel(carrot);
            Cut(carrot);

            Bowl bowl;
            bowl = GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);
        }
        private Potato GetPotato()
        {
            //...
        }
        private Carrot GetCarrot()
        {
            //...
        }
        private void Cut(Vegetable potato)
        {
            //...
        }  
        private Bowl GetBowl()
        {
            //... 
        }
    }
 }

