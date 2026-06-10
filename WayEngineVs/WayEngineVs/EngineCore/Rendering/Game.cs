using Entities;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using WayEngine.UI;
using WayEngineVs.Editor;


namespace GameRender
{
    public class Game : GameWindow
    {

        private double _accumulator;

        private ImGuiController _controller;


        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        protected override void OnLoad()
        {
            base.OnLoad();

            EntitySystem.LoadEntities();

            GL.Enable(EnableCap.Blend);

            
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

           

            _controller = new ImGuiController(ClientSize.X, ClientSize.Y);

            Entity cam = new Entity("Camera", "Square");



            CameraSystem.CreateCamera(cam, 150.0f);


        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);



            GL.ClearColor(0.1f, 0.1f, 0.6f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            


            EntitySystem.RenderEntities();

            TransformSystem.ReloadScale(CameraSystem.CamerasScene[0], 0.0f, 0.0f);
           


            WindowM.RenderWindow(_controller, args, this);




            SwapBuffers();

            


        }


        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            _accumulator += args.Time;
            float time = (float)_accumulator;

            CameraSystem.UpdateCamera(CameraSystem.CamerasScene[0], 150.0f);
        }
    }



public class RenderGameProcess
{
       public static Vector2i ScreenSize = new Vector2i(1080, 920);

       public static void Main(string[] args)                     
       {
            var gameWindowSettings = GameWindowSettings.Default;
            var nativeWindowSettings = NativeWindowSettings.Default;
            nativeWindowSettings.ClientSize = ScreenSize;
            nativeWindowSettings.Title = "Game";


            using (Game game_ = new Game(gameWindowSettings, nativeWindowSettings))
            {
                game_.Run();
            }

       }

        



        public static void PreRenderEntities() 
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
