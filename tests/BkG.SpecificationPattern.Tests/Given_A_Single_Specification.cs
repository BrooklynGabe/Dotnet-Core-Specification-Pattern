using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BkG.SpecificationPattern.Tests
{
    [TestClass]
    public class Given_A_Single_Specification
    {
        [TestMethod]
        [ExpectedException(typeof(RequiredArgumentNullException))]
        public void When_The_Restriction_Is_Not_Provided_Then_Required_Argument_Null_Exception_Is_Thrown()
        {
            var vSpecification = new Specification<bool>(null);
        }
    }
}
