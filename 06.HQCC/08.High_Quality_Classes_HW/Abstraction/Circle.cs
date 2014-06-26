using System;

namespace Abstraction
{
    class Circle : Figure
    {
        private double Radius;

        public double MyProperty
        {
            get { return Radius; }
            set 
            {
                if (value <= 0 )
                {
                    throw new ArgumentOutOfRangeException("Radius must be greater than zero!");
                }

                Radius = value; 
            }
        }
        

        public Circle(double radius)
        {
            this.Radius = radius;
        }


        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
