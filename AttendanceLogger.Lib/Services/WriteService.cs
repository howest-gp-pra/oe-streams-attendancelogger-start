using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLogger.Lib.Services
{
    public class WriteService
    {
        public bool WriteToFile(List<string> lines, string fileSubject, Encoding encoding = null)
        {
            bool successfullyWritten = false;

            if (encoding == null) encoding = Encoding.UTF8;

            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "text documents (.txt)|*.txt";
                saveDialog.Title = "Kies een locatie ...";
                saveDialog.FileName = $"{fileSubject} - {DateTime.Now.ToShortDateString().Replace("/", "-")}";
                bool? doSave = saveDialog.ShowDialog();

                if (doSave == true)
                { 
                    string path = saveDialog.FileName;

                    using (StreamWriter streamwriter =
                        new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.ReadWrite), encoding))
                    {
                        foreach (string line in lines)
                        {
                            streamwriter.WriteLine(line);
                        }

                        streamwriter.Close();
                    }

                    successfullyWritten = true;

                }

                

                return successfullyWritten;
            }

            //Lazy way of dealing with exceptions. This is not the best solution because
            //you don't inform about the actual error.
            catch (Exception)
            {

                throw new Exception("Oops. Something went wrong!");
            }
        }
    }
}
