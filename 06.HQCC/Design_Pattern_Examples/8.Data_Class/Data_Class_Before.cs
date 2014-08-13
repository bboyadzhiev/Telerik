using System;
public class Circle
{
    private double radius;
    private Color color;
    private Point origin;
    public Circle(double radius, Color color, Point origin)
    {
        this.radius = radius;
        this.color = color;
        this.origin = origin;
    }
    public double Circumference
    {
        get { return 2 * Math.PI * this.radius; }
    }
    public double Diameter
    {
        get { return 2 * this.radius; }
    }
    public void Draw(Graphics graphics)
    {
        //...
    }
}
