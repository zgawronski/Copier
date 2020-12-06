using System;
using ZadaniaLib;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer();
            var scanner = new Scanner();

            var copier = new Copier();
            copier.PowerOn();

            var document = new PDFDocument("xyz.pdf");

            copier.Print(document);
            copier.ScanAndPrint();

            copier.PowerOff();
        }
    }
}