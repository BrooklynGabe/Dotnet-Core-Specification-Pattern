using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace BkG.SpecificationPattern.Tests
{
    [TestClass]
    public class Given_Two_Specifications_Are_Joined_Using_And_Operation
    {
        [TestMethod]
        [ExpectedException(typeof(RequiredArgumentNullException))]
        public void When_The_Other_Spec_Is_Null_Then_Required_Argument_Null_Exception_Is_Thrown()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            Specification<bool> vRight = null;

            var vLeftAndRight = vLeft.And(vRight);
        }

        [TestMethod]
        public void When_Both_Specifications_Are_Satisfied_Then_The_And_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !!testValue);

            var vLeftAndRight = vLeft.And(vRight);
            var vRightAndLeft = vRight.And(vLeft);

            Assert.IsTrue(vLeftAndRight.IsSatisfiedBy(true), "When both original specifications are satisfied, then the AND operation should be as well.");
            Assert.IsTrue(vRightAndLeft.IsSatisfiedBy(true), "When both original specifications are satisfied, then the AND operation should be as well.");
        }

        [TestMethod]
        public void When_One_Specification_Is_Not_Satisfied_Then_The_And_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftAndRight = vLeft.And(vRight);
            var vRightAndLeft = vRight.And(vLeft);

            Assert.IsFalse(vLeftAndRight.IsSatisfiedBy(true), "When one specification is not satisfied, then the AND operation should not be as well.");
            Assert.IsFalse(vRightAndLeft.IsSatisfiedBy(true), "When one specification is not satisfied, then the AND operation should not be as well.");
        }

        [TestMethod]
        public void When_Neither_Specifications_Is_Satisfied_Then_The_And_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => !testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftAndRight = vLeft.And(vRight);
            var vRightAndLeft = vRight.And(vLeft);

            Assert.IsFalse(vLeftAndRight.IsSatisfiedBy(true), "When both specifications are not satisfied, then the AND operation should not be as well.");
            Assert.IsFalse(vRightAndLeft.IsSatisfiedBy(true), "When both specifications are not satisfied, then the AND operation should not be as well.");
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredArgumentNullException))]
        public void Using_Overloaded_Operator_When_This_Spec_Is_Null_Then_Required_Argument_Null_Exception_Is_Thrown()
        {
            Specification<bool> vLeft = null;
            var vRight = new Specification<bool>(testValue => testValue);

            var vLeftAndRight = vLeft & vRight;
        }

        [TestMethod]
        public void Using_Overloaded_Operator_When_Both_Specifications_Are_Satisfied_Then_The_And_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !!testValue);

            var vLeftAndRight = vLeft & vRight;
            var vRightAndLeft = vRight & vLeft;

            Assert.IsTrue(vLeftAndRight.IsSatisfiedBy(true), "When both original specifications are satisfied, then the AND operation should be as well.");
            Assert.IsTrue(vRightAndLeft.IsSatisfiedBy(true), "When both original specifications are satisfied, then the AND operation should be as well.");
        }

        [TestMethod]
        public void Using_Overloaded_Operator_When_One_Specification_Is_Not_Satisfied_Then_The_And_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftAndRight = vLeft & vRight;
            var vRightAndLeft = vRight & vLeft;

            Assert.IsFalse(vLeftAndRight.IsSatisfiedBy(true), "When one specification is not satisfied, then the AND operation should not be as well.");
            Assert.IsFalse(vRightAndLeft.IsSatisfiedBy(true), "When one specification is not satisfied, then the AND operation should not be as well.");
        }

        [TestMethod]
        public void Using_Overloaded_Operator_When_Neither_Specifications_Is_Satisfied_Then_The_And_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => !testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftAndRight = vLeft & vRight;
            var vRightAndLeft = vRight & vLeft;

            Assert.IsFalse(vLeftAndRight.IsSatisfiedBy(true), "When both specifications are not satisfied, then the AND operation should not be as well.");
            Assert.IsFalse(vRightAndLeft.IsSatisfiedBy(true), "When both specifications are not satisfied, then the AND operation should not be as well.");
        }
    }
}