using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Billogram.Tools
{
    public static class Encoding
    {
        public static byte[] DecryptBase64(string encoding) => Convert.FromBase64String(encoding);
        public static string EncryptBase64(byte[] content) => Convert.ToBase64String(content);
    }
}
