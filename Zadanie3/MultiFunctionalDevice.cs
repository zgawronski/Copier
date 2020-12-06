using ZadaniaLib;

namespace Zadanie3
{
    public class MultifunctionalDevice : Copier
    {
        public Fax Fax { get; private set; }
        public int FaxCounter { get => Fax.Counter; }

        public MultifunctionalDevice()
        {
            Fax = new Fax();
        }

        public void Send(in IDocument document, string faxNumber)
        {
            if (state == IDevice.State.on)
            {
                Fax.PowerOn();
                Fax.Send(document, faxNumber);
                Fax.PowerOff();
            }
        }


        public void ScanAndFax(string faxNumber)
        {
            IDocument scannedDocument;
            Scan(out scannedDocument);
            Send(scannedDocument, faxNumber);
        }
    }
}