using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;


public class Shader
{

    public struct ShaderComponents 
    {

        public string VertexShaderDefault = @"
    #version 330 core

    layout (location = 0) in vec2 aPosition;

     uniform mat4 Model;

     uniform mat4 View;

     uniform mat4 Projection;

    void main()
    {

       gl_Position = Projection * View * Model * vec4(aPosition.x, aPosition.y, 0.0, 1.0);

    }";

        public string FragmentShaderDefault = @"
    #version 330 core

    layout (location = 0) out vec4 FragColor;

    uniform vec4 Color;

    

    void main()
    {
        FragColor = Color;
    }";


        public ShaderComponents() 
        {
            
        }

    }


   
    





}
