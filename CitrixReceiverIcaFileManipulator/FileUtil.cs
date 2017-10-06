using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrixReceiverIcaFileManipulator
{
    class FileUtil
    {
        public static string readFile(String sFilename)
        {
            string sContent = "";

            if (File.Exists(sFilename))
            {
                StreamReader myFile = new StreamReader(sFilename, System.Text.Encoding.Default);
                sContent = myFile.ReadToEnd();
                myFile.Close();
            }
            return sContent;
        }

        public static void writeFile(String sFilename, String sLines)
        {
            StreamWriter myFile = new StreamWriter(sFilename);
            myFile.Write(sLines);
            myFile.Close();
        }

    }
}
