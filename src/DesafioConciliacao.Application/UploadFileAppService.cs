using DesafioConciliacao.Application.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace DesafioConciliacao.Application
{
    public class UploadFileAppService  : IUploadFileAppService
    {
        public UploadFileAppService() { }

        /// <summary>
        /// Save ofx file inside a directory
        /// </summary>
        /// <param name="files"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        public List<string> Upload(HttpPostedFileBase[] files, string destino)
        {
            List<string> ofxFiles = new List<string>();

            //iterating through multiple file collection   
            foreach (HttpPostedFileBase file in files)
            {
                //Checking file is available to save.  
                if (file != null)
                {
                    var InputFileName = DateTime.UtcNow.ToFileTime() + "" + Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(destino + InputFileName);
                    //Save file to server folder  
                    file.SaveAs(ServerSavePath);

                    ofxFiles.Add(ServerSavePath);

                }

            }

            return ofxFiles;
        }
    }
}
