using System;

namespace ZadaniaLib
{
    public interface IFax : IDevice
    {
        void Send(in IDocument document, String faxNumber);
    }
}
