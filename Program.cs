using System;
using System.Drawing;
using app.interfaces.Car;

namespace app;

class Car : ICar
{
    public string Name { get; set; }
    public string Color { get; set; }
    public int Year { get; set; }

    //Constructor in C#, class name with parameters to initialize the value of variables
    public Car(string name, string color, int year)
    {
        Name = name;
        Color = color;
        Year = year;
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

class Menu
{
    public static void ShowMenuCar()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== Menu ===");
        Console.WriteLine("1. Ligar o Carro");
        Console.WriteLine("2. Desligar o Carro");
        Console.WriteLine("3. Sair");
        Console.WriteLine("=============");
        Console.WriteLine();
        Console.ResetColor();
        Console.Write("Escolha uma opção: ");
    }
}

class Program
{
    static void Main()
    {
        PrintInitMsg();
        Menu.ShowMenuCar();
    }

    static void PrintInitMsg()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Bem Vindo!");
        Console.WriteLine("Escolha uma opção!");
        Console.ResetColor(); 
        Console.WriteLine();
    }
}