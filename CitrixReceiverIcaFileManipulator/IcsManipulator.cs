using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrixReceiverIcaFileManipulator
{
    class IcsManipulator
    {
        public static void manipulateFile(string icsFile, bool doResolutionManipulation, bool doTransparentKeyPassthrough, string hres, string vres)
        {
            string content = FileUtil.readFile(icsFile);
            content = manipulateResolution(content, doResolutionManipulation, hres, vres);
            content = manipulateTransparentKeyPassthrough(content, doTransparentKeyPassthrough);
            FileUtil.writeFile(icsFile, content);
        }

        private static string manipulateResolution(string input, bool doResolutionManipulation, string hres, string vres)
        {
            if (doResolutionManipulation)
            {
                string[] elements = input.Split(new[] { '\r', '\n' });
                string output = "";
                foreach (string line in elements)
                {
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        if (line.StartsWith("DesiredHRES="))
                        {
                            output += "DesiredHRES=" + hres + "\n";
                        }
                        else if (line.StartsWith("DesiredVRES="))
                        {
                            output += "DesiredVRES=" + vres + "\n";
                        }
                        else
                        {
                            output += line + "\n";
                        }
                    }
                }
                return output;
            }
            else
            {
                return input;
            }
        }

        private static string manipulateTransparentKeyPassthrough(string input, bool doTransparentKeyPassthrough)
        {
            if (doTransparentKeyPassthrough)
            {
                string[] elements = input.Split(new[] { '\r', '\n' });
                string output = "";
                foreach (string line in elements)
                {
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        if (line.StartsWith("TransparentKeyPassthrough="))
                        {
                            output += "TransparentKeyPassthrough=Remote\n";
                        }
                        else
                        {
                            output += line + "\n";
                        }
                    }
                }
                return output;
            }
            else
            {
                return input;
            }
        }
    }
}
