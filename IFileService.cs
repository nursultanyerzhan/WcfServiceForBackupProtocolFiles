using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceForBackupProtocolFiles
{
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        byte[] GetFile(Guid id);

        [OperationContract]
        string GetProtocolAttachmentFileName(Guid id);
    }
}
