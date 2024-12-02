using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASync.Resources
{
    internal class ASyncFileManager
    {
        async public static Task<string> ReadFile(string path)
        {
            string result = await File.ReadAllTextAsync(path);
            return result;
        }
    }
}
