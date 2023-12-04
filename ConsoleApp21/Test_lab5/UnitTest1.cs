using System.Diagnostics.Metrics;
using System.IO.Ports;
using System.Xml.Linq;

namespace Test_lab5
{
    public class UnitTest1
    {

        private WorkService workService = new ();



        [Fact]
        public void SucsesffulSerialPortCreate()
        {
            //act
            SerialPort serialPort = workService.Create_SerialPort();
            //assert
            Assert.True (serialPort != null);


        }

        [Fact]

        public void SucsesffulPaseDictabce()
        {
            //arrange 
            XElement xml = new XElement("distance",25);
            //act
            string result = workService.ParseDistance(xml.ToString());
            //assert
            Assert.Equal("25", result);
               
        }

        [Fact]
        public void FailureParseDistance()
        {
            //arrange 
            string xml ="";
            //act
            string result = workService.ParseDistance(xml);
            //assert
            Assert.Empty(result);

        }



    }
}