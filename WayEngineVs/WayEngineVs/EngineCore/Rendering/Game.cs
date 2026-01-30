using Entities;
using GameRender;
using ImGuiNET;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Xml.Linq;

namespace GameRender
{
    public class Game : GameWindow
    {


        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        protected override void OnLoad()
        {
            base.OnLoad();



            Entity newEntity2 = new Entity("Object1", "Square");

            Entity newEntity3 = new Entity("Object2", "Triangle");



            EntitySystem.LoadEntities();

            
            CameraSystem.CreateCamera(newEntity2);

            TransformSystem.ReloadTranslate(newEntity2, 1.2f, -0.7f);

            

            ColorSystem.SetColor(newEntity2, Color4.Blue);

            ColorSystem.SetColor(newEntity3 , Color4.Green);

        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);



            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.ClearColor(0.1f, 0.1f, 0.6f, 1f);

            

            RenderGameProcess.RenderEntities();






            SwapBuffers();

        }


        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            CameraSystem.UpdateCamera(CameraSystem.CamerasScene[0]);

        }
    }



public class RenderGameProcess
{
       public static Vector2i ScreenSize = new Vector2i(520, 480);

       public static void Main(string[] args)
       {
            var gameWindowSettings = GameWindowSettings.Default;
            var nativeWindowSettings = NativeWindowSettings.Default;
            nativeWindowSettings.Size = ScreenSize;
            nativeWindowSettings.Title = "Game";


            using (Game game_ = new Game(gameWindowSettings, nativeWindowSettings))
            {
                game_.Run();
            }

        }

        



        public static void RenderEntities() 
        {

            Entity cameraOwner = CameraSystem.CamerasScene[0];

            Component.Camera camera = ComponentSystem.GetProperty<Component.Camera>(cameraOwner, "Camera");

            

            foreach (Entity entity in EntitySystem.EntitiesScene.Values)
            {
               
                RenderEntity(entity, camera);

            }
     
        }


        public static void RenderEntity(Entity entity,Component.Camera camera) 
        {

            Component.Transform transformTR = ComponentSystem.GetProperty<Component.Transform>(entity, "Transform");

            Component.Mesh meshTR = ComponentSystem.GetProperty<Component.Mesh>(entity, "Mesh");

            Component.Color colorTR = ComponentSystem.GetProperty<Component.Color>(entity, "Color");

            int locModelTR = GL.GetUniformLocation(meshTR.Shader, "Model");

            int locViewTR = GL.GetUniformLocation(meshTR.Shader, "View");

            int locProjTR = GL.GetUniformLocation(meshTR.Shader, "Projection");

            int locColorTR = GL.GetUniformLocation(meshTR.Shader, "Color");


            GL.UseProgram(meshTR.Shader);

            Matrix4 ModelTR = transformTR.xyPos * transformTR.zRotate * transformTR.xyScale;

            GL.UniformMatrix4(locModelTR, false, ref ModelTR);

            GL.UniformMatrix4(locViewTR, false, ref camera.view);

            GL.UniformMatrix4(locProjTR, false, ref camera.projection);

            GL.Uniform4(locColorTR,colorTR.color);


            GL.BindVertexArray(meshTR.VertexArrayObject);


            switch(entity.type) 
            {
                case "Triangle":

                  GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

                break;

                case "Square":

                  GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);

                break;
            }
 
        }
   }
}
