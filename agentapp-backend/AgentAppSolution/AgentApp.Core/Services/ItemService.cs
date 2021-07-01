using AgentApp.Core.DTOs;
using AgentApp.Core.Model.File;
using System;
using System.IO;

namespace AgentApp.Core.Services
{
    public class ItemService
    {
        public string ImageToSave(string path, FileModel file)
        {
            try
            {
                using (Stream stream = new FileStream(path + "\\images\\" + file.FileName, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
                return file.FileName;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Content GetImage(string path, string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName)) fileName = "trolley.png";
            var type = Path.GetExtension(fileName);
            path = path + "\\images\\" + fileName;
            return new Content() { Bytes = System.IO.File.ReadAllBytes(path), Type = type };
        }
    }
}