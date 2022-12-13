using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace pls
{
    public class FileLuuTudien
    {
        public static bool FileLuu(List<Themtu> Tudien, string path)
        {
            try
            {
                FileStream fs = new System.IO.FileStream("dictionary.txt",FileMode.Append, FileAccess.Write, FileShare.None);
                StreamWriter sw = new StreamWriter(fs);
                foreach (Themtu Dic in Tudien)
                {
                    string line = Dic.Anh + ":" + Dic.Viet;
                    sw.WriteLine(line);

                }   
                sw.Close();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
