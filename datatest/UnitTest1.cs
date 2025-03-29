using Creams_Macro_Protocol;
namespace datatest
{
    public class Tests
    {
        public static string testdata = "1000011X1____00____64FFFFFF\n";
       

        [Test]
        public void Test1()
        {

            if (Creams_Macro_Protocol.Datahandeling.DataTest(testdata)) { Assert.Pass(); return; }



            

            Assert.Fail();
        }
    }
}