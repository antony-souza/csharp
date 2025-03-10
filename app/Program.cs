using System;
using System.Drawing;
using app.interfaces.Car;

namespace app;

class Car : ICar
{
    public string Name { get; set; }
    public string Color { get; set; }

    public Car(string name, string color)
    {
        Name = name;
        Color = color;
    }
    
    public void PowerOn(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{msg}");
        Console.ResetColor();
    }

    public void PowerOff(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{msg}");
        Console.ResetColor();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to C# app");
        Console.WriteLine("Qual o nome do carro?");
        string NameCar = Console.ReadLine();
        Console.WriteLine("Qual a cor do carro?");
        string ColorCar = Console.ReadLine();
        Car car = new Car(NameCar, ColorCar);
        
        string msg = "Car Powered On";
        car.PowerOn(msg);
    }
}