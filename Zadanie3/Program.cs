using System;
using ZadaniaLib;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            Scanner scanner = new Scanner();


            Copier copier = new Copier();
            copier.PowerOn();

            var document = new PDFDocument("xyz.pdf");

            copier.Print(document);
            copier.ScanAndPrint();

            copier.PowerOff();
        }
    }
}