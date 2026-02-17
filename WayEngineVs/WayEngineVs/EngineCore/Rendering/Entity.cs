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

        private static int _nextId = 0;

        public string name;

        public string type;


        public Dictionary<string, object> components = new Dictionary<string, object>();


        public Entity(string name,string type) 
        {
            this.name = name;

            this.type = type;



            this.ID = Interlocked.Increment(ref _nextId);


            EntitySystem.EntitiesScene.Add(this.ID, this);

        }

    }


}
