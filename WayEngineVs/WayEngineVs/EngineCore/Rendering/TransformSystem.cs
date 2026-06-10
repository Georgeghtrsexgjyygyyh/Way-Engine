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

    public static void SumScale(Entity entity, double scaleX, double scaleY)
    {
        Matrix4 newScale = MatrixSystem.CreateMatrix("Scale", scaleX, scaleY);

        Component.Transform transformEntity = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");

        transformEntity.xyScale = MatrixSystem.UpdateMatrix(transformEntity.xyScale, newScale);

        ComponentSystem.SetProperty(entity, "Transform", transformEntity);
    }

    public static void ReloadScale(Entity entity, double scaleX,double scaleY)
    {
        Matrix4 newScale = MatrixSystem.CreateMatrix("Scale", scaleX, scaleY);

        Component.Transform transformEntity = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");

        transformEntity.xyScale = newScale;

        ComponentSystem.SetProperty(entity, "Transform", transformEntity);

        
    }

    public static void SumTranslate(Entity entity,double x,double y) 
    {
        Matrix4 newPos = MatrixSystem.CreateMatrix("Translate",x,y);

        Component.Transform transformEntity = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");

        transformEntity.xyPos = MatrixSystem.UpdateMatrix(transformEntity.xyPos, newPos);

        ComponentSystem.SetProperty(entity, "Transform", transformEntity);

        

    }

    public static void ReloadTranslate(Entity entity, double x, double y)
    {
        Matrix4 newPos = MatrixSystem.CreateMatrix("Translate", x, y);

        Component.Transform transformEntity = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");

        transformEntity.xyPos = newPos;

        ComponentSystem.SetProperty(entity, "Transform", transformEntity);


    }

    public static void ReloadRotate(Entity entity, double angle) 
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

