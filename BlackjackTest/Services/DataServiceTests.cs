using Uno.Services.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Uno.Services.Tests
{
    [TestClass()]
    public class DataServiceTests
    {
        [TestMethod()]
        public void DrawTest()
        {
            //DataService svc = new DataService();
            //DrawRequest req = new DrawRequest();
            //req.DeskID = "ul6h1doao98p";
            //req.NumberOfCards = 2;
            //svc.Draw(req);


            var resp = new DataService().Draw(new DrawRequest()
            {
               DeckID= "0lbyu48v57vi",
               NumberOfCards = 2
            });


            Assert.IsNotNull(resp);
        }
    }
}