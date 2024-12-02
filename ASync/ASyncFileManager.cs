using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASync
{
    internal class ASyncFileManager
    {
        async public static Task<string> ReadFile(string path)
        {
            string result = await File.ReadAllTextAsync(path);
            await Task.Delay(5000);
            return result;
        }

        async public static void WriteFile(string path, string input)
        {
            await File.WriteAllTextAsync(path, input);
        }
    }
}
