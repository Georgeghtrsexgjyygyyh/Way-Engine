using Entities;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


 public class TransformSystem
 {

    public static void SumScale(Entity entity, float scale)
    {
        Matrix4 newScale = MatrixSystem.CreateMatrix("Scale", scale, scale);

        Component.Transform transformEntity = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");

        transformEntity.xyScale = MatrixSystem.UpdateMatrix(transformEntity.xyScale, newScale);

        ComponentSystem.SetProperty(entity, "Transform", transformEntity);
    }

    public static void ReloadScale(Entity entity, float scale)
    {
        Matrix4 newScale = MatrixSystem.CreateMatrix("Scale", scale, scale);

        Component.Transform transformEntity = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");

        transformEntity.xyScale = newScale;

        ComponentSystem.SetProperty(entity, "Transform", transformEntity);

        
    }

    public static void SumTranslate(Entity entity,float x,float y) 
    {
        Matrix4 newPos = MatrixSystem.CreateMatrix("Translate",x,y);

        Component.Transform transformEntity = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");

        transformEntity.xyPos = MatrixSystem.UpdateMatrix(transformEntity.xyPos, newPos);

        ComponentSystem.SetProperty(entity, "Transform", transformEntity);

        

    }

    public static void ReloadTranslate(Entity entity, float x, float y)
    {
        Matrix4 newPos = MatrixSystem.CreateMatrix("Translate", x, y);

        Component.Transform transformEntity = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");

        transformEntity.xyPos = newPos;

        ComponentSystem.SetProperty(entity, "Transform", transformEntity);


    }

    public static void ReloadRotate(Entity entity, float angle) 
    {
        Matrix4 newRotate  = MatrixSystem.CreateMatrix("Rotate",angle,angle);

        Component.Transform transformEntity = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");

        transformEntity.zRotate = newRotate;

        

        ComponentSystem.SetProperty(entity, "Transform", transformEntity);

        
    }

    public static void CreateTransform(Entity entity)
    {
        Component.Transform transform = new Component.Transform();

        ComponentSystem.SetProperty(entity, "Transform", transform);


    }


}

