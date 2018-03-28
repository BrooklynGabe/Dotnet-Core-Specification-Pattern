using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

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

        [TestMethod]
        public void When_The_Restriction_Matches_Then_The_Specification_Is_Satisfied()
        {
            var vSpecification = new Specification<bool>(testValue => testValue);

            Assert.IsTrue(vSpecification.IsSatisfiedBy(true), "Restriction that tests true should satisfy the specification");
        }

        [TestMethod]
        public void When_The_Restriction_Does_Not_Match_Then_The_Specification_Is_Not_Satisfied()
        {
            var vSpecification = new Specification<bool>(testValue => testValue);

            Assert.IsFalse(vSpecification.IsSatisfiedBy(false), "Restriction that tests false should not satisfy the specification");
        }

        [TestMethod]
        public void When_Needed_As_An_Expression_Then_The_Specification_Implicitly_Casts()
        {
            var vSpecification = new Specification<bool>(testValue => testValue);
            Expression<Func<bool, bool>> vImplicitCast = vSpecification;

            Assert.IsNotNull(vImplicitCast, "The specificaiton should implicitly cast back to an expression.");
        }
    }
}
