using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

public class MatrixSystem
{

      public static Matrix4 CreateMatrix(string type,float x,float y) 
      {
        switch (type)
        {

            case "Scale":

                return Matrix4.CreateScale(x);

            case "Translate":

                return Matrix4.CreateTranslation(x,y,0);

            case "Rotate":

                return Matrix4.CreateRotationZ(x);

            case "Projection":

                return Matrix4.CreateOrthographic(x,y,-100.0f,100.0f);

            default:

                return Matrix4.CreateScale(1);
        }
             
      }


      public static Matrix4 UpdateMatrix(Matrix4 oldMatrix,Matrix4 newMatrix) 
      {
           return oldMatrix * newMatrix;
      }
}
