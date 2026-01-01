using GameRender;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using Entities;

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


            Entity newEntity1 = new Entity("Object0", "Triangle");

            EntitySystem.ReloadTranslate(newEntity1 , 2 , 2);




            EntitySystem.LoadEntities();
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

        }
    }



public class RenderGameProcess
{
       public static void Main(string[] args)
       {
            var gameWindowSettings = GameWindowSettings.Default;
            var nativeWindowSettings = NativeWindowSettings.Default;
            nativeWindowSettings.Size = new OpenTK.Mathematics.Vector2i(520, 420);
            nativeWindowSettings.Title = "Game";


            using (Game game_ = new Game(gameWindowSettings, nativeWindowSettings))
            {
                game_.Run();
            }
       }

       public static void CreateMesh(Entity entity)
       {


            ////////
            float[] vertices = {0};
            uint[] indices = {0};
            
            switch (entity.type) 
            {
                case "Triangle":

                    vertices = new Type.Triangle(entity.transform.xyScale.M11).vertices;
                    indices = new Type.Triangle(entity.transform.xyScale.M11).indices;

                    break;

                case "Square":

                    vertices = new Type.Square(entity.transform.xyScale.M11).vertices;
                    indices = new Type.Square(entity.transform.xyScale.M11).indices;

                    break;

                default:

                    Console.WriteLine("Bruh");

                    break;
            }
                

                int VAO = GL.GenVertexArray();
                GL.BindVertexArray(VAO);

                int VBO = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
                GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

                int EBO = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
                GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

                Component.Mesh newMesh;
                ////////


                //...........
                GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);
                GL.EnableVertexAttribArray(0);
                //...........


                string VS = new Shader.ShaderComponents().VertexShaderDefault;

                string FS = new Shader.ShaderComponents().FragmentShaderDefault;


                int vertexShader = GL.CreateShader(ShaderType.VertexShader);
                GL.ShaderSource(vertexShader, VS);
                GL.CompileShader(vertexShader);

                int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
                GL.ShaderSource(fragmentShader, FS);
                GL.CompileShader(fragmentShader);

                int SHADER = GL.CreateProgram();
                GL.AttachShader(SHADER, vertexShader);
                GL.AttachShader(SHADER, fragmentShader);
                GL.LinkProgram(SHADER);

                GL.DeleteShader(vertexShader);
                GL.DeleteShader(fragmentShader);


                newMesh = new Component.Mesh(VAO, VBO, EBO, SHADER);

                entity.mesh = newMesh;

            }

       public static void RenderEntities() 
       {
                foreach (var entity in EntitySystem.EntitiesScene.Values)
                {
                   
                    switch (entity.type)
                    {
                        case "Triangle":


                           int loc = GL.GetUniformLocation(entity.mesh.Shader, "Translate");
                        
                            GL.UseProgram(entity.mesh.Shader);

                            GL.UniformMatrix4(loc, false, ref entity.transform.xyPos);

                            GL.BindVertexArray(entity.mesh.VertexArrayObject);

                            

                            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

                            break;

                        case "Square":

                            int loc1 = GL.GetUniformLocation(entity.mesh.Shader, "Translate");

                            GL.UseProgram(entity.mesh.Shader);

                            GL.UniformMatrix4(loc1, false, ref entity.transform.xyPos);

                            GL.UseProgram(entity.mesh.Shader);
                            GL.BindVertexArray(entity.mesh.VertexArrayObject);
                            

                            GL.DrawElements(PrimitiveType.Triangles, 6 , DrawElementsType.UnsignedInt,0);

                            break;

                    default:

                            Console.WriteLine("Nothing yet");

                            break;
                    }

                }
       }


        }
}
