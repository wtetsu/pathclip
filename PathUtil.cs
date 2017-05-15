using System;
using System.Collections.Generic;
using System.IO;

namespace PathClip
{
    public class PathUtil
    {
        public static string CreateString(string[] args)
        {
            var lines = new List<string>();

            string latestDirpath = null;
            foreach (string s in args)
            {
                string newDirPath;
                string newFileName;
                CreateString(s, out newDirPath, out newFileName);
                if (!string.IsNullOrEmpty(newDirPath) && latestDirpath != newDirPath)
                {
                    lines.Add(newDirPath);
                    latestDirpath = newDirPath;
                }
                lines.Add(newFileName);
            }

            return string.Join(Environment.NewLine, lines);
        }

        private static void CreateString(string str, out string newDirPath, out string newFileName)
        {
            newDirPath = null;
            newFileName = null;
            if (str.StartsWith(@"\\"))
            {
                if (Directory.Exists(str))
                {
                    newFileName = str;
                }
                else
                {
                    string fileName = Path.GetFileName(str);
                    string dirPath = str.Substring(0, str.Length - fileName.Length - 1);

                    newDirPath = string.Format("<{0}>", dirPath);
                    newFileName = fileName;
                }
            }
            else if (str.Contains(" "))
            {
                newFileName = string.Format("\"{0}\"", str);
            }
            else
            {
                newFileName = str;
            }
        }
    }
}
