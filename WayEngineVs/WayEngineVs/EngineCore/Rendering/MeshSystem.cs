using Entities;
using GameRender;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MeshSystem
{

    public static void CreateMesh(Entity entity)
    {


        ////////
        float[] vertices = { 0 };
        uint[] indices = { 0 };

        switch (entity.type)
        {
            case "Triangle":

                
                vertices = new Type.Triangle().vertices;
                indices = new Type.Triangle().indices;

                break;

            case "Square":

                vertices = new Type.Square().vertices;
                indices = new Type.Square().indices;

                break;

            default:

                Console.WriteLine($"!Type not exists! [{entity.type}] ");

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


        Component.Mesh newMesh = new Component.Mesh(VAO, VBO, EBO, SHADER);

        ComponentSystem.SetProperty(entity, "Mesh" , newMesh);

    }

}

