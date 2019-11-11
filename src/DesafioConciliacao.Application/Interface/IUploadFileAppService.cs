using System.Collections.Generic;
using System.Web;
using DesafioConciliacao.Domain.Entity;

namespace DesafioConciliacao.Application.Interface
{
    public interface IUploadFileAppService
    {
        List<string> Upload(HttpPostedFileBase[] files, string destino);
    }
}
