namespace app.interfaces.Car;

//Contracts required for the class
public interface ICar
{
     string Name { get; set; }
     string Color { get; set; }
     int Year { get; set; }
     void PowerOn(string msg); 
     void PowerOff(string msg);
}