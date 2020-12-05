using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ZadaniaLib;
using Zadanie2;

namespace Zadanie2UnitTests
{
    public class ConsoleRedirectionToStringWriter : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleRedirectionToStringWriter()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOutput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }

    [TestClass]
    public class UnitTestMultiFunctionalDevice
    {
        [TestMethod]
        public void Device_Scan_DeviceisOn()
        {
            var device = new MultiFunctionalDevice("60660660");
            device.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();

            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                device.Send(doc1, "555555555");

                Assert.IsTrue(consoleOutput.GetOutput().Contains("Sent"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void Device_Send_DeviceIsOff()
        {
            var device = new MultiFunctionalDevice("666666666");
            device.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                device.Send(doc1, "321654987");
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void Device_ScanAndSend_DeviceIsOn()
        {
            var device = new MultiFunctionalDevice("888888888");
            device.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                device.ScanAndSend("777777777");
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Sent"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        public void Device_ScanAndSend_DeviceIsOff()
        {
            var device = new MultiFunctionalDevice("888888888");
            device.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                device.ScanAndSend("777777777");
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
    }
}