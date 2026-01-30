using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ComponentSystem
{



    public static void SetProperty(Entity entity,string name, object value) 
    {
       entity.components[name] = value;
      
    }

    public static T GetProperty<T>(Entity entity,string name) 
    {
        if (entity.components.TryGetValue(name, out var value))
        {
            return (T)value;
        }

        return default;

    }
}

