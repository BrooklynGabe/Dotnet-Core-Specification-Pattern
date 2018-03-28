using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace BkG.SpecificationPattern.Tests
{
    [TestClass]
    public class Given_A_Single_Specification_Is_Negated
    {
        [TestMethod]
        public void When_The_Restriction_Matched_Originally_Then_The_Specification_Is_Not_Satisfied()
        {
            var vSpecification = new Specification<bool>(testValue => testValue);
            var vNegatedSpecification = vSpecification.Not();

            Assert.IsFalse(vNegatedSpecification.IsSatisfiedBy(true), "Restriction that originally tested true should not satisfy the negation");
        }

        [TestMethod]
        public void When_The_Restriction_Did_Not_Match_Originally_Then_The_Specification_Is_Satisfied()
        {
            var vSpecification = new Specification<bool>(testValue => testValue);
            var vNegatedSpecification = vSpecification.Not();

            Assert.IsTrue(vNegatedSpecification.IsSatisfiedBy(false), "Restriction that originally tested false should satisfy the negation");
        }

        [TestMethod]
        public void Using_Overloaded_Operator_When_The_Restriction_Matched_Originally_Then_The_Specification_Is_Not_Satisfied()
        {
            var vSpecification = new Specification<bool>(testValue => testValue);
            var vNegatedSpecification = !vSpecification;

            Assert.IsFalse(vNegatedSpecification.IsSatisfiedBy(true), "Restriction that originally tested true should not satisfy the negation");
        }

        [TestMethod]
        public void Using_Overloaded_Operator_When_The_Restriction_Did_Not_Match_Originally_Then_The_Specification_Is_Satisfied()
        {
            var vSpecification = new Specification<bool>(testValue => testValue);
            var vNegatedSpecification = !vSpecification;

            Assert.IsTrue(vNegatedSpecification.IsSatisfiedBy(false), "Restriction that originally tested false should satisfy the negation");
        }
        
        [TestMethod]
        [ExpectedException(typeof(RequiredArgumentNullException))]
        public void Using_Overloaded_Operator_When_Spec_Is_Null_Then_Throws_Required_Argument_Null_Exception()
        {
            Specification<bool> vSpecification = null;
            var vNegatedSpecification = !vSpecification;
        }
    }
}
