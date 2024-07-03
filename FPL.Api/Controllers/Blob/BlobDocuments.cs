using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FPL.Api.Controllers.Blob
{
    public class BlobDocuments
    {

        public static string GetDocumentorfileUri(HttpPostedFile fileorimage)
        {
            if (fileorimage.ContentLength > 0)
            {
                BlobStorage.UploadFile(fileorimage);
                string doiuri = BlobStorage.DocumentsorImagesUri.ToString();
                return doiuri;
            }
            return "Nill";
        }

        public static string GetDocumentorfileUri1(byte[] fileorimage, string filename)
        {
            if (fileorimage.Length > 0)
            {
                BlobStorage.UploadFile1(fileorimage, filename);
                string doiuri = BlobStorage.DocumentsorImagesUri.ToString();
                return doiuri;
            }
            return "Nill";
        }



     
    }
}