using System.IO.Ports;

SerialPort serialPort = new SerialPort("COM3", 9600);
serialPort.Open();
var message1 = Console.ReadLine();
var message2 = Console.ReadLine();

await Task.Delay(1000);


serialPort.DataReceived += (sender, e) =>
{
    if (sender is SerialPort sender1)
    {
        Console.WriteLine($"sender: {sender1.ReadExisting()}");
    }
};

serialPort.Write(message1);
serialPort.Write(message2);

await Task.Delay(25000);
