using System.Security.Cryptography.X509Certificates;
using Creams_Macro_Protocol;
using CreamsConsole_utils;
using System.Diagnostics;
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
        public void processTest()
        {



            int o = 3000;

            //AudioManager.UpdateSession();
            //var i = AudioManager.getAudioProcesses(AudioManager.GetsessionEnum());
            //Debug.WriteLine($"{i.Count}");f

            //Debug.WriteLine($"sleeping for: {o} ms");
            //Thread.Sleep(o);

            //AudioManager.UpdateSession();

            //var j = AudioManager.getAudioProcesses(AudioManager.GetsessionEnum());

            //Debug.WriteLine($"{j.Count}");

            //var last = j.First();

            //AudioHelper.SetApplicationVolume(last.Id, 50);


            //if (i.Count == j.Count) { }
            







        }


       /* [Test]
        public void sessiontest() {
            AudioManager.UpdateSession();
            var getsesion = AudioManager.GetsessionEnum();

            int count1;
            getsesion.GetCount(out count1);

            Debug.WriteLine($"{count1}\n");


            Debug.WriteLine($"waiting for 10000ms");
            Thread.Sleep(10000);

            int count;
            getsesion.GetCount(out count);
            Debug.WriteLine($"{count}\n");









        
        }*/





    }
}