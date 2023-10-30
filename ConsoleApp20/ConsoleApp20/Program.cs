using System;
using System.IO.Ports;

class Program
{
    static void Main(string[] args)
    {
        SerialPort serialPort = new SerialPort("COM3", 9600); // Замініть "COM4" на відповідний номер COM-порту.

        serialPort.DataReceived += (sender, e) =>
        {
            string data = serialPort.ReadLine();

            // Очистимо консоль перед виведенням нових даних
            Console.Clear();

            // Встановимо колір тексту
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Distance:");

            // Відображення даних в форматі "Distance: XX CM"
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(data);

            // Повернення до стандартного кольору тексту
            Console.ResetColor();
        };

        try
        {
            serialPort.Open();
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access to the COM port is denied. Please run the program as an administrator.");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

        serialPort.Close();
    }
}