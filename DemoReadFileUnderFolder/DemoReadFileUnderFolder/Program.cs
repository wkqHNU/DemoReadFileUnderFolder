using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReadFileUnderFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            ScanPatternFiles();
        }

        public static List<string[]> ScanPatternFiles()
        {
            try
            {
                string antPatDir = @"..\..\..\GainAntennaPattern\";
                string paPath;
                string saPath;
                List<string[]> antPatLst = new List<string[]>();
                DirectoryInfo di = new DirectoryInfo(antPatDir);
                DirectoryInfo[] subs = di.GetDirectories();
                foreach (var dir in subs)
                {
                    try
                    {
                        paPath = dir.GetFiles("*AIR0.txt")[0].FullName;
                        saPath = dir.GetFiles("*AIR1.txt")[0].FullName;
                        antPatLst.Add(new string[] { paPath, saPath });
                    }
                    catch { continue; }  //有问题的方向图组直接跳过
                }
                return antPatLst;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to scan patterns.", ex);
                return null;
            }
        }
    }
}
