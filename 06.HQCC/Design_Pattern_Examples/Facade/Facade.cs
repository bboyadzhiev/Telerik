using System;

internal class MainApp
{
    public static void Main()
    {
        Facade facade = new Facade();

        facade.MethodA();
        facade.MethodB();

        // Wait for user
        Console.Read();
    }
}

// "Subsystem ClassA"
internal class SubSystemOne
{
    public void MethodOne()
    {
        Console.WriteLine(" SubSystemOne Method");
    }
}

// Subsystem ClassB"
internal class SubSystemTwo
{
    public void MethodTwo()
    {
        Console.WriteLine(" SubSystemTwo Method");
    }
}

// Subsystem ClassC"
internal class SubSystemThree
{
    public void MethodThree()
    {
        Console.WriteLine(" SubSystemThree Method");
    }
}

// Subsystem ClassD"
internal class SubSystemFour
{
    public void MethodFour()
    {
        Console.WriteLine(" SubSystemFour Method");
    }
}

// "Facade"
internal class Facade
{
    private SubSystemOne one;
    private SubSystemTwo two;
    private SubSystemThree three;
    private SubSystemFour four;

    public Facade()
    {
        one = new SubSystemOne();
        two = new SubSystemTwo();
        three = new SubSystemThree();
        four = new SubSystemFour();
    }

    public void MethodA()
    {
        Console.WriteLine("\nMethodA() ---- ");
        one.MethodOne();
        two.MethodTwo();
        four.MethodFour();
    }

    public void MethodB()
    {
        Console.WriteLine("\nMethodB() ---- ");
        two.MethodTwo();
        three.MethodThree();
    }
}