using Entities;
using GameRender;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Mathematics;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Metrics;


public class EntitySystem
{
    public static int OrderInScene = 0;


    public static Dictionary<int, Entity> EntitiesScene = new Dictionary<int, Entity>();

    public static Dictionary<int, Entity> EntitiesDuplicate = new Dictionary<int, Entity>();
    
    public static void LoadEntities() 
    {
        MeshSystem.LoadMesh();
    }
    public static void RenderEntities()
    {      
       
        foreach (Entity entity in EntitiesDuplicate.Values.ToArray())
        {
            if (EntitiesDuplicate.Count > 0 & entity != null)
            {

                OrderInScene++;

                Console.WriteLine($"Entity {OrderInScene}, ID: {entity.ID}");


                MeshSystem.CreateMesh(entity);

                TransformSystem.CreateTransform(entity);

                ColorSystem.CreateColor(entity);

                EntitiesDuplicate.Remove(entity.ID);

            }

        }

        RenderGameProcess.PreRenderEntities();


    }

}
