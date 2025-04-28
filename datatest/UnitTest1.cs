using System.Security.Cryptography.X509Certificates;
using Creams_Macro_Protocol;
namespace datatest
{
    public class Tests
    {
        public static string testdata = "1000011X1____10____32FFFFFF\r\n";
       

        [Test]
        public void Test1()
        {

            if (Creams_Macro_Protocol.Datahandeling.DataTest(testdata)) { Assert.Pass(); return; }



            

            Assert.Fail();
        }
        [Test]
        public void audioTest()
        {
            string[] strings = { "discord", "spotify", "chrome" };

            AudioHandeler.SearchforAudio(strings);

            Assert.Pass();


        }


        [Test]
        public void volumeTest()

    }
}