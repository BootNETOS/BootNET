using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNET.GUI;

public class TestApp : App
{
    public TestApp(ushort width, ushort height, int x, int y) : base(width,height, x, y) { }
    public override void AppUpdate()
    {
        base.AppUpdate();
    }
}
