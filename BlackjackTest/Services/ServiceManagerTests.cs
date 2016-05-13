using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Services.Responses;

namespace Uno.Services.Tests
{
    [TestClass()]
    public class ServiceManagerTests
    {
        
        [TestMethod()]
        public void CallServiceTest()
        {
            ServiceManager mgr = new ServiceManager(new Uri("http://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1"));

            var response = mgr.CallService<DrawResponse>();
            Assert.IsNotNull(response);
        }
    }
}