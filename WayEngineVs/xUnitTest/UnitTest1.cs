using OpenTK.Mathematics;

namespace WayEngine.Tests
{
    public class UnitTest1
    {
        [Theory(DisplayName = "Matrix Translation Check")]

        [InlineData(10.0f, 0.0f, 5.5f, 0.0f, 15.5f, 0.0f)]
        
        [InlineData(0.0f, -10.0f, 0.0f, 25.0f, 0.0f, 15.0f)]
        
        [InlineData(50.0f, 50.0f, -50.0f, -50.0f, 0.0f, 0.0f)]
        
        [InlineData(10.0f, 10.0f, -30.0f, -30.0f, -20.0f, -20.0f)]
        
        [InlineData(0.001f, 0.001f, 0.002f, 0.002f, 0.003f, 0.003f)]
        
        [InlineData(1.2f, 3.4f, 5.6f, 7.8f, 6.8f, 11.2f)]
        
        [InlineData(-5.0f, -5.0f, -10.0f, -15.0f, -15.0f, -20.0f)]
        
        [InlineData(0.5f, 0.5f, 0.5f, 0.5f, 1.0f, 1.0f)]
        
        [InlineData(1000.0f, 2000.0f, 500.0f, 500.0f, 1500.0f, 2500.0f)]
        
        [InlineData(123.45f, 67.89f, 0.0f, 0.0f, 123.45f, 67.89f)]


        public void Test_UpdateMatrix_MatrixSystemClass(float x1, float y1, float x2, float y2, float expX, float expY)
        {
           
            Matrix4 a = MatrixSystem.CreateMatrix("Translate", x1, y1);
            Matrix4 b = MatrixSystem.CreateMatrix("Translate", x2, y2);
            Matrix4 exp = MatrixSystem.CreateMatrix("Translate", expX, expY);

           
            var res = MatrixSystem.UpdateMatrix(a, b);


            
            Assert.Equal(exp.M41, res.M41, 5);

            
            Assert.Equal(exp.M42, res.M42, 5);
        }


    }
}