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

        public float scale;


        public string name;

        public string type;


        Random random = new Random();



        public Component.Mesh mesh;

        public Component.Transform transform = new Component.Transform();


        public Entity(string name,string type) 
        {
            this.name = name;

            this.type = type;


            ID = 1 * (name.Length) * (name.Length * 2) * (type.Length) * (type.Length * 2) * random.Next(0,55);

            EntitySystem.EntitiesScene.Add(this.ID, this);

        }

    }


}
