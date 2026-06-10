using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Mathematics;
using System.Text;
using System.Threading.Tasks;
using Xunit;


public class Test
{
    [Theory]
    [InlineData(-3.0f, 0.0f, 20.0f, -8.0f, 17.0f, -8.0f)]
    [InlineData(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f)]
    [InlineData(10.458f, 10.450f, -10.600f, -10.40f, -0.142f, 0.05f)] 
    public void UpdateMatrix_MultipleTranslations_ShouldWork(float x1, float y1, float x2, float y2, float expX, float expY)
    {
        
        Matrix4 a = MatrixSystem.CreateMatrix("Translate", x1, y1);
        Matrix4 b = MatrixSystem.CreateMatrix("Translate", x2, y2);
        Matrix4 expected = MatrixSystem.CreateMatrix("Translate", expX, expY);

        
        var result = MatrixSystem.UpdateMatrix(a, b);

        
        Assert.Equal(expected, result);
    }
}
