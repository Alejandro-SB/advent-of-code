using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Helper
{
    public static class FileHelper
    {
        public static async Task<IEnumerable<string>> GetInputLinesAsync(string fileName)
        {
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(path, "Inputs", fileName);

            var lines = await File.ReadAllLinesAsync(filePath);

            return lines;
        }
    }
}