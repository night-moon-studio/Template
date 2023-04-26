namespace UnitTestProject
{
    [Trait("样例", "等式测试")]
    public class UnitTest1
    {
        [Fact(DisplayName = "1==1")]
        public void Test1()
        {
            int a = 1;
            Assert.Equal(1, a);
        }
    }


    [Trait("样例", "不等式测试")]
    public class UnitTest2
    {
        [Fact(DisplayName = "1!=1")]
        public void Test1()
        {
            int a = 2;
            Assert.NotEqual(1, a);
        }
    }
}