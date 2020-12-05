using ZadaniaLib;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            var device = new MultiFunctionalDevice("070072772");
            device.PowerOn();

            device.Send(new PDFDocument("xyz.pdf"), "888888888");
            device.ScanAndSend("777777777");

            device.PowerOff();
        }
    }
}
