using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNET.Core
{
    public static class Resources
    {
        [ManifestResourceStream(ResourceName = "BootNET.Resources.ArialCustomCharset16.btf")] 
        public static byte[] fontData;
    }
}
