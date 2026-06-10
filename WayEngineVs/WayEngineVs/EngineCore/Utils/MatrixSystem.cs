using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;


    public class MatrixSystem
    {

        public static Matrix4 CreateMatrix(string type, double x, double y)
        {
            switch (type)
            {

                case "Scale":

                    return Matrix4.CreateScale((float)x);

                case "Translate":

                    return Matrix4.CreateTranslation((float)x, (float)y, 0);

                case "Rotate":

                    return Matrix4.CreateRotationZ((float)x);

                case "Projection":

                    return Matrix4.CreateOrthographic((float)x, (float)y, -100.0f, 100.0f);

                default:

                    return Matrix4.CreateScale(1);
            }

        }


        public static Matrix4 UpdateMatrix(Matrix4 oldMatrix, Matrix4 newMatrix)
        {
            return oldMatrix * newMatrix;
        }
    }

