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
        foreach (var entity in EntitiesScene.Values)
        {

            OrderInScene++;

            Console.WriteLine($"Entity {OrderInScene}, ID: {entity.ID}");

            RenderGameProcess.CreateMesh(entity);
        }
    }


    public static void SumScale(Entity entity,float scale) 
    {
        Matrix4 newScale = MatrixSystem.CreateMatrix("Scale", scale, scale);

        entity.transform.xyScale = MatrixSystem.UpdateMatrix(entity.transform.xyScale, newScale);

        Console.WriteLine($"{entity.name} scale = {entity.transform.xyScale.M11.ToString()}");
    }

    public static void ReloadScale(Entity entity, float scale)
    {
        Matrix4 newScale = MatrixSystem.CreateMatrix("Scale", scale, scale);

        entity.transform.xyScale = newScale;

        Console.WriteLine($"{entity.name} scale = {entity.transform.xyScale.M11.ToString()}");
    }

    public static void ReloadTranslate(Entity entity, float x, float y) 
    {
        Matrix4 newPos = MatrixSystem.CreateMatrix("Translate", x,y);

        entity.transform.xyPos = newPos;

        Console.WriteLine($"{entity.name} position = {entity.transform.xyPos.M14.ToString()},{entity.transform.xyPos.M24.ToString()}");

    }
}
