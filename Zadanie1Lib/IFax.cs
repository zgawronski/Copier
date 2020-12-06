namespace ZadaniaLib
{
    public interface IFax : IDevice
    {
        void Send(in IDocument document, string faxNumber);
    }
}
