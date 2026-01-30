using GameRender;
using OpenTK.Graphics.ES20;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


public class Component
{
        public struct Transform
        {

            public Matrix4 xyPos;

            public Matrix4 xyScale;

            public Matrix4 zRotate;


            public Transform() 
            {
                xyPos = MatrixSystem.CreateMatrix("Translate",0.0f,0.0f);

                xyScale = MatrixSystem.CreateMatrix("Scale", 1.0f, 1.0f);

                zRotate = MatrixSystem.CreateMatrix("Rotate", 0.0f, 0.0f);
        }

            
        }

        public struct Color 
        {

            public Color4 color;


            public float transparent;

            public Color(Color4 c_4,float t) 
            {
                color = c_4; //Color

                transparent = (t) % 1; //Transparent t % 1 = 0-1 , t = 0-100

            }

        }

        public struct Mesh 
        {
            public int VertexArrayObject;

            public int VertexBufferObject;

            public int ElementBufferObject;

            public int Shader;

            public Mesh(int VAO,int VBO,int EB0,int SHADER) 
            {
                this.VertexArrayObject = VAO;

                this.VertexBufferObject = VBO;

                this.ElementBufferObject = EB0;

                this.Shader = SHADER;

            }
        }


        public struct Camera 
        {
           public Matrix4 projection;
           
           public Matrix4 view;

           public Camera(Matrix4 view,Matrix4 projection) 
           {
              this.view = view;
              
              this.projection = projection;
              
           }


        }

}