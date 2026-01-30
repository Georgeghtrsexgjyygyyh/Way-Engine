using Entities;
using GameRender;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CameraSystem
{
    public static List<Entity> CamerasScene = new List<Entity>();

    public static void CreateCamera(Entity entity) 
    {

        Component.Transform transform = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");


        Matrix4 projection = MatrixSystem.CreateMatrix("Projection", RenderGameProcess.ScreenSize.X / 150.0f, RenderGameProcess.ScreenSize.Y / 150.0f);

        Matrix4 modelMatrix = transform.xyPos * transform.zRotate;
        Matrix4 view = modelMatrix.Inverted();


        Component.Camera camera = new Component.Camera(view,projection);

        ComponentSystem.SetProperty(entity, "Camera", camera);

        CamerasScene.Add(entity);

    }

    public static void UpdateCamera(Entity entity) 
    {
        Component.Transform transform = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");


        Matrix4 projection = MatrixSystem.CreateMatrix("Projection", 520.0f / 150.0f, 480.0f / 150.0f);

       
        float x = transform.xyPos.ExtractTranslation().X;
        float y = transform.xyPos.ExtractTranslation().Y;

        
        Matrix4 view = Matrix4.CreateTranslation(-x, -y, 0);


        Component.Camera camera = new Component.Camera(view, projection);

        ComponentSystem.SetProperty(entity, "Camera", camera);

        CamerasScene[0] = entity;
            
        
    }
}

