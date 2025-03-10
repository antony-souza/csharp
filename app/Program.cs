using System;
using System.Drawing;
using app.interfaces.ICar;

namespace app;

class Car(string name, string color) : ICar
{
    public string Name { get; set; } = name;
    public string Color { get; set; } = color;
    
    public void PowerOn()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Car Powered On");
        Console.ResetColor();
    }

    public void PowerOff()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Car Powered Off");
        Console.ResetColor();
    }
}

class  Program
{
    static void Main()
    {
        Car car = new Car("BMW", "Black");
        car.PowerOn();
    }
}