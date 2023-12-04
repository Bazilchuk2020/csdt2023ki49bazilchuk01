using System; 
using System.IO.Ports;

using System.Xml.Linq;

public  class  WorkService 
{
    public SerialPort Create_SerialPort() {
        return new SerialPort("COM3", 9600);
    }

    public string ParseDistance(string xmlBuffer)
    {
        if (xmlBuffer.Contains("</distance>"))
        {
            try
            {
                
                XDocument xdoc = XDocument.Parse(xmlBuffer);
               

                string distanceStr = xdoc.Root.Value;
                return distanceStr;
            }
            catch (Exception ex)
            {
                
            }
        }
        return "";
        
    }
}
class Program
{
    static void Main(string[] args)
    {
        /// <summary>
        /// Create a new SerialPort instance for COM3 at a baud rate of 9600.
        /// </summary>
        WorkService workService = new WorkService();
        
        SerialPort serialPort= workService.Create_SerialPort() ;
       
        /// <summary>
        /// String to store XML data received from the serial port.
        /// </summary>
         
        string xmlBuffer = "";
        /// <summary>
        /// Event handler for the DataReceived event of the SerialPort.
        /// </summary>

        serialPort.DataReceived += (sender, e) =>
        {
            /// <summary>
            /// Append the received data to the xmlBuffer.
            /// </summary>
             
            xmlBuffer += serialPort.ReadLine();
            /// <summary>
            /// Check if the xmlBuffer contains the end tag "</distance>".
            /// </summary>
           var distance = workService.ParseDistance(xmlBuffer);
            if (!string.IsNullOrEmpty(distance))
            {

               
                    
                    /// <summary>
                    /// Clear the console.
                    /// </summary>
                     
                    Console.Clear();
                    /// <summary>
                    /// Display "Distance:" in green.
                    /// </summary>
                     
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Distance:");
                    /// <summary>
                    /// Display the distance value in dark magenta.
                    /// </summary>
                     
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(distance + " CM");
                    /// <summary>
                    /// Reset console colors.
                    /// </summary>
                    
                    Console.ResetColor();
                
                
            }
            xmlBuffer = "";
        };
       
        try
        {
            /// <summary>
            /// Attempt to open the serial port.
            /// </summary>
             
            serialPort.Open();
        }
        catch (UnauthorizedAccessException)
        {
            /// <summary>
            /// Handle the case where access to the COM port is denied.
            /// </summary>
             
            Console.WriteLine("Error: Access to the COM port is denied. Please run the program as an administrator.");
        }
        /// <summary>
        /// Display a message and wait for a key press before exiting.
        /// </summary>
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        /// <summary>
        /// Close the serial port.
        /// </summary>
        
        serialPort.Close();
    }
}
