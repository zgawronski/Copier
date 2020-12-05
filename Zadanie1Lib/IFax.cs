namespace ZadaniaLib
{
    public interface IFax : IDevice
    {
        void Send(IDocument document, string faxNumber);
    }
}
