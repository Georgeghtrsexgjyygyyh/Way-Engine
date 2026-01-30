using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Type
{

    public struct Triangle
    {
        public float[] vertices =
        {
                -0.5f,-0.5f,
                0.0f,0.5f,
                0.5f,-0.5f,

        };

        public uint[] indices =
        {
                0,1,2,
        };

        public Triangle()
        {

        }
    }



    public struct Square
    {
        public float[] vertices =
        {
                -0.5f,-0.5f,
                 0.5f,-0.5f,
                 0.5f,0.5f,
                -0.5f,0.5f,
        };

        public uint[] indices =
        {
             0,1,3,
             3,1,2,
        };

        public Square()
        {

        }
    }







}
