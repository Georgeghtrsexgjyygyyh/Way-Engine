using Entities;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


public class ColorSystem
{
    public static void SetColor(Entity entity,Color4 color) 
    {
        Component.Color color1 = new Component.Color(color, 0);

        ComponentSystem.SetProperty(entity, "Color", color1);
    }

    public static void CreateColor(Entity entity)
    {
        Component.Color color = new Component.Color(Color4.White,0);

        ComponentSystem.SetProperty(entity,"Color",color);
    }
}

