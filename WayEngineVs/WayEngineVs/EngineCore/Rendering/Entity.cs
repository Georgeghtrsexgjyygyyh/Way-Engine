using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRender;
using OpenTK.Graphics.ES11;

namespace Entities
{
    public class Entity
    {
        public int ID;


        public string name;

        public string type;





        public Dictionary<string, object> components = new Dictionary<string, object>();


        public Entity(string name,string type) 
        {
            this.name = name;

            this.type = type;


            ID = this.GetHashCode();


            EntitySystem.EntitiesScene.Add(this.ID, this);

        }

    }


}
