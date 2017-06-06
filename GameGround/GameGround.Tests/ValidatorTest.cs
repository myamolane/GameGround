using GameGround.Tests.Service;
using GameGround.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace GameGround.Tests
{
    [TestClass]
    public class ValidatorTest : ServiceBase
    {
        [TestMethod]
        public void PlayerValidator_ShouldWork()
        {
            var model = new VmPlayer();
            try
            {
                ValidationProvider.Validate(model);
            }
            catch (LocalizedFormatException ex)
            {
                Console.WriteLine(ex.GetErrorMessage());
                Assert.AreEqual("Required", ex.Format);
                Assert.AreEqual("Name", ex.Parameter);
            }
        }
    }
}
