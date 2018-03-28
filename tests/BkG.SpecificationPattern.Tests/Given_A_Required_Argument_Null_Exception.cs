using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BkG.SpecificationPattern.Tests
{
    [TestClass]
    public class Given_A_Required_Argument_Null_Exception
    {
        [TestMethod]
        public void When_The_Exception_Is_Referenced_Then_It_Is_A_Type_Of_Null_Reference_Exception()
        {
            var vException = new RequiredArgumentNullException();

            Assert.IsTrue(vException is ArgumentNullException, "The exception should inherit from this type.");
        }
    }
}
