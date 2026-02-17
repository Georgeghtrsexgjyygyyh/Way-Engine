using Entities;
using GameRender;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class MeshSystem
{
    private static int GlobalVAOTR = 0;
    private static int GlobalVBOTR= 0;
    private static int GlobalEBOTR= 0;
    private static int GlobalShaderTR = 0;
    /// <summary>
    /// Variables for optimize rendering
    /// </summary>
    private static int GlobalVAOSQ = 0;
    private static int GlobalVBOSQ = 0;
    private static int GlobalEBOSQ = 0;
    private static int GlobalShaderSQ = 0;

    public static void CreateMesh(Entity entity)
    {


        ////////
        //float[] vertices = { 0 };
        //uint[] indices = { 0 };

        switch (entity.type)
        {
            case "Triangle":


                Component.Mesh newMesh = new Component.Mesh(GlobalVAOTR, GlobalVBOTR, GlobalEBOTR,GlobalShaderTR);

                ComponentSystem.SetProperty(entity, "Mesh", newMesh);

                break;

            case "Square":


                Component.Mesh newMesh1 = new Component.Mesh(GlobalVAOSQ, GlobalVBOSQ, GlobalEBOSQ, GlobalShaderSQ);

                ComponentSystem.SetProperty(entity, "Mesh", newMesh1);

                break;

            default:

                Console.WriteLine($"!Type not exists! [{entity.type}] ");

                break;

        }

    }


    public static void LoadMesh() 
    {
        ////////
        float[] vertices = { 0 };
        uint[] indices = { 0 };


        vertices = new Type.Triangle().vertices;
        indices = new Type.Triangle().indices;

        int VAOTR = GL.GenVertexArray();
        GL.BindVertexArray(VAOTR);

        int VBOTR = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, VBOTR);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        int EBOTR = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBOTR);
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

         GlobalVAOTR = VAOTR;
         GlobalVBOTR = VBOTR;
         GlobalEBOTR = EBOTR;
         GlobalShaderTR = SHADER;

        //////////////////////////////////////////////////////////////////////////////////////////////////

        vertices = new Type.Square().vertices;
        indices = new Type.Square().indices;

        int VAOSQ = GL.GenVertexArray();
        GL.BindVertexArray(VAOSQ);

        int VBOSQ = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, VBOSQ);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        int EBOSQ = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBOSQ);
        GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);


        ////////


        //...........
        GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);
        //...........

        string VSSQ = new Shader.ShaderComponents().VertexShaderDefault;

        string FSSQ = new Shader.ShaderComponents().FragmentShaderDefault;


        int vertexShaderSQ = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShaderSQ, VSSQ);
        GL.CompileShader(vertexShaderSQ);

        int fragmentShaderSQ = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShaderSQ, FSSQ);
        GL.CompileShader(fragmentShaderSQ);

        int SHADERSQ = GL.CreateProgram();
        GL.AttachShader(SHADERSQ, vertexShaderSQ);
        GL.AttachShader(SHADERSQ, fragmentShaderSQ);
        GL.LinkProgram(SHADERSQ);

        GL.DeleteShader(vertexShaderSQ);
        GL.DeleteShader(fragmentShaderSQ);

        GlobalVAOSQ = VAOSQ;
        GlobalVBOSQ = VBOSQ;
        GlobalEBOSQ = EBOSQ;
        GlobalShaderSQ = SHADERSQ;


    }

}

