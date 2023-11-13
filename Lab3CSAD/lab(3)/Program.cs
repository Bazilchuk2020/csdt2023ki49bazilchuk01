using System;
using System.IO.Ports;
using System.Xml;

class Program
{
    static string previousDistance = ""; // Variable to store the previous distance value

    static void Main(string[] args)
    {
        SerialPort serialPort = new SerialPort("COM3", 9600);

        serialPort.DataReceived += (sender, e) =>
        {
            string data = serialPort.ReadLine();

            // Check if the distance has changed before displaying and saving
            if (IsDistanceChanged(data))
            {
                Console.WriteLine("<Distance>");
                Console.WriteLine(data);
                Console.WriteLine("</Distance>");

                // Write data to XML file
                WriteToXml(data, "C:\\Users\\38068\\source\\repos\\lab(3)\\lab(3)\\distance.xml");

                // Update the previous distance value
                previousDistance = data;
            }
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

    static void WriteToXml(string data, string filePath)
    {
        try
        {
            XmlDocument xmlDoc = new XmlDocument();

            if (File.Exists(filePath))
            {
                xmlDoc.Load(filePath);
            }
            else
            {
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = xmlDoc.DocumentElement;
                xmlDoc.InsertBefore(xmlDeclaration, root);

                xmlDoc.AppendChild(xmlDoc.CreateElement("Distances"));
            }

            XmlElement distanceElement = xmlDoc.CreateElement("Distance");
            distanceElement.InnerText = data;

            xmlDoc.DocumentElement.AppendChild(distanceElement);
            xmlDoc.Save(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to XML file: {ex.Message}");
        }
    }

    static bool IsDistanceChanged(string newDistance)
    {
        // Compare the new distance with the previous one
        return !string.Equals(newDistance, previousDistance);
    }
}
