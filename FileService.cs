using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceForBackupProtocolFiles
{
    class FileService : IFileService
    {
        public byte[] GetFile(Guid id)
        {
            using (var db = new WebPortalEntities())
            {
                try
                {
                    var fileName = db.ProtocolAttachment.Where(r => r.Id == id).Select(r => r.FileName).First();
                    var url = @"C:\ProtocolAttachmentFiles\" + id.ToString() + @"\" + fileName;
                    return File.ReadAllBytes(url);
                }
                catch
                {
                    return null;
                }
            }
        }

        public string GetProtocolAttachmentFileName(Guid id)
        {
            using (var db = new WebPortalEntities())
            {
                return db.ProtocolAttachment.Where(r => r.Id == id).Select(r => r.FileName).FirstOrDefault();
            }
        }
    }
}
