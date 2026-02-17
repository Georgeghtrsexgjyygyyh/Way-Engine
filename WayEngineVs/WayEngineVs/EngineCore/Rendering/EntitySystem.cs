using Entities;
using GameRender;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Mathematics;
using System.Text;
using System.Threading.Tasks;


public class EntitySystem
{
    public static int OrderInScene = 0;


    public static Dictionary<int, Entity> EntitiesScene = new Dictionary<int, Entity>();

    public static void LoadEntities()
    {
        MeshSystem.LoadMesh();

        foreach (var entity in EntitiesScene.Values)
        {
            OrderInScene++;

            Console.WriteLine($"Entity {OrderInScene}, ID: {entity.ID}");

            
            MeshSystem.CreateMesh(entity);

            TransformSystem.CreateTransform(entity);

            ColorSystem.CreateColor(entity);
        }
    }

}
