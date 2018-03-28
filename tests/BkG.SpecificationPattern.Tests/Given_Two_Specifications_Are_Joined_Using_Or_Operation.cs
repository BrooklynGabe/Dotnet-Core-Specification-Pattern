using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace BkG.SpecificationPattern.Tests
{
    [TestClass]
    public class Given_Two_Specifications_Are_Joined_Using_Or_Operation
    {
        [TestMethod]
        [ExpectedException(typeof(RequiredArgumentNullException))]
        public void When_The_Other_Spec_Is_Null_Then_Required_Argument_Null_Exception_Is_Thrown()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            Specification<bool> vRight = null;

            var vLeftOrRight = vLeft.Or(vRight);
        }

        [TestMethod]
        public void When_Neither_Specifications_Is_Satisfied_Then_The_Or_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => !testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftOrRight = vLeft.Or(vRight);
            var vRightOrLeft = vRight.Or(vLeft);

            Assert.IsFalse(vRightOrLeft.IsSatisfiedBy(true), "When neither original specification is satisfied, then the OR operation should not be as well.");
            Assert.IsFalse(vLeftOrRight.IsSatisfiedBy(true), "When neither original specification is satisfied, then the OR operation should not be as well.");
        }

        [TestMethod]
        public void When_One_Specification_Is_Satisfied_Then_The_Or_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftOrRight = vLeft.Or(vRight);
            var vRightOrLeft = vRight.Or(vLeft);

            Assert.IsTrue(vLeftOrRight.IsSatisfiedBy(true), "When one specification is satisfied, then the OR operation should be as well.");
            Assert.IsTrue(vRightOrLeft.IsSatisfiedBy(true), "When one specification is satisfied, then the OR operation should be as well.");
        }

        [TestMethod]
        public void When_Both_Specifications_Is_Satisfied_Then_The_Or_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => testValue);

            var vLeftOrRight = vLeft.Or(vRight);
            var vRightOrLeft = vRight.Or(vLeft);

            Assert.IsTrue(vLeftOrRight.IsSatisfiedBy(true), "When both specifications are satisfied, then the OR operation should be as well.");
            Assert.IsTrue(vRightOrLeft.IsSatisfiedBy(true), "When both specifications are satisfied, then the OR operation should be as well.");
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredArgumentNullException))]
        public void Using_Overloaded_Operator_When_This_Spec_Is_Null_Then_Required_Argument_Null_Exception_Is_Thrown()
        {
            Specification<bool> vLeft = null;
            var vRight = new Specification<bool>(testValue => testValue);

            var vLeftOrRight = vLeft | vRight;
        }

        [TestMethod]
        public void Using_Overloaded_Operator_When_Neither_Specifications_Is_Satisfied_Then_The_Or_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => !testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftOrRight = vLeft | vRight;
            var vRightOrLeft = vRight | vLeft;

            Assert.IsFalse(vRightOrLeft.IsSatisfiedBy(true), "When neither original specification is satisfied, then the OR operation should not be as well.");
            Assert.IsFalse(vLeftOrRight.IsSatisfiedBy(true), "When neither original specification is satisfied, then the OR operation should not be as well.");
        }

        [TestMethod]
        public void Using_Overloaded_Operator_When_One_Specification_Is_Satisfied_Then_The_Or_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftOrRight = vLeft | vRight;
            var vRightOrLeft = vRight | vLeft;

            Assert.IsTrue(vLeftOrRight.IsSatisfiedBy(true), "When one specification is satisfied, then the OR operation should be as well.");
            Assert.IsTrue(vRightOrLeft.IsSatisfiedBy(true), "When one specification is satisfied, then the OR operation should be as well.");
        }

        [TestMethod]
        public void Using_Overloaded_Operator_When_Both_Specifications_Is_Satisfied_Then_The_Or_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => testValue);

            var vLeftOrRight = vLeft | vRight;
            var vRightOrLeft = vRight | vLeft;

            Assert.IsTrue(vLeftOrRight.IsSatisfiedBy(true), "When both specifications are satisfied, then the OR operation should be as well.");
            Assert.IsTrue(vRightOrLeft.IsSatisfiedBy(true), "When both specifications are satisfied, then the OR operation should be as well.");
        }
    }
}