using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLogger.Lib.Services
{
    public class ReadService
    {
        private const string Location = @"../../assets/students.txt";
        public List<string> ReadLines(Encoding encoding = null)
        {
            try
            {
                if (encoding == null) encoding = Encoding.UTF8;

                string currentLine;
                List<string> lines = new List<string>();

                using (StreamReader file = new StreamReader(Location, encoding))
                {
                    while((currentLine = file.ReadLine()) != null)
                    {
                        lines.Add(currentLine);
                    }
                }

                return lines;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException($"Het in te lezen {Location} bestand kan niet worden gevonden.");
            }

            catch (IOException)
            {
                throw new IOException("Het bestand kan niet geopend worden.\nProbeer het te sluiten.");
            }

            catch (Exception e)
            {
                throw new Exception($"Er is een fout opgetreden. {e.Message}");
            }
        }
    }
}
