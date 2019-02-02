using Xunit;
using System;
using System.Linq.Expressions;

namespace BkG.SpecificationPattern.Tests
{

    public class Given_Two_Specifications_Are_Joined_Using_Or_Operation
    {
        [Fact]
        public void When_The_Other_Spec_Is_Null_Then_Required_Argument_Null_Exception_Is_Thrown()
        {
            Assert.Throws<RequiredArgumentNullException>(() =>
            {
                var vLeft = new Specification<bool>(testValue => testValue);
                Specification<bool> vRight = null;

                var vLeftOrRight = vLeft.Or(vRight);
            });
        }

        [Fact]
        public void When_Neither_Specifications_Is_Satisfied_Then_The_Or_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => !testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftOrRight = vLeft.Or(vRight);
            var vRightOrLeft = vRight.Or(vLeft);

            Assert.False(vRightOrLeft.IsSatisfiedBy(true), "When neither original specification is satisfied, then the OR operation should not be as well.");
            Assert.False(vLeftOrRight.IsSatisfiedBy(true), "When neither original specification is satisfied, then the OR operation should not be as well.");
        }

        [Fact]
        public void When_One_Specification_Is_Satisfied_Then_The_Or_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftOrRight = vLeft.Or(vRight);
            var vRightOrLeft = vRight.Or(vLeft);

            Assert.True(vLeftOrRight.IsSatisfiedBy(true), "When one specification is satisfied, then the OR operation should be as well.");
            Assert.True(vRightOrLeft.IsSatisfiedBy(true), "When one specification is satisfied, then the OR operation should be as well.");
        }

        [Fact]
        public void When_Both_Specifications_Is_Satisfied_Then_The_Or_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => testValue);

            var vLeftOrRight = vLeft.Or(vRight);
            var vRightOrLeft = vRight.Or(vLeft);

            Assert.True(vLeftOrRight.IsSatisfiedBy(true), "When both specifications are satisfied, then the OR operation should be as well.");
            Assert.True(vRightOrLeft.IsSatisfiedBy(true), "When both specifications are satisfied, then the OR operation should be as well.");
        }

        [Fact]
        public void Using_Overloaded_Operator_When_This_Spec_Is_Null_Then_Required_Argument_Null_Exception_Is_Thrown()
        {
            Assert.Throws<RequiredArgumentNullException>(() =>
            {
                Specification<bool> vLeft = null;
                var vRight = new Specification<bool>(testValue => testValue);

                var vLeftOrRight = vLeft | vRight;
            });
        }

        [Fact]
        public void Using_Overloaded_Operator_When_Neither_Specifications_Is_Satisfied_Then_The_Or_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => !testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftOrRight = vLeft | vRight;
            var vRightOrLeft = vRight | vLeft;

            Assert.False(vRightOrLeft.IsSatisfiedBy(true), "When neither original specification is satisfied, then the OR operation should not be as well.");
            Assert.False(vLeftOrRight.IsSatisfiedBy(true), "When neither original specification is satisfied, then the OR operation should not be as well.");
        }

        [Fact]
        public void Using_Overloaded_Operator_When_One_Specification_Is_Satisfied_Then_The_Or_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftOrRight = vLeft | vRight;
            var vRightOrLeft = vRight | vLeft;

            Assert.True(vLeftOrRight.IsSatisfiedBy(true), "When one specification is satisfied, then the OR operation should be as well.");
            Assert.True(vRightOrLeft.IsSatisfiedBy(true), "When one specification is satisfied, then the OR operation should be as well.");
        }

        [Fact]
        public void Using_Overloaded_Operator_When_Both_Specifications_Is_Satisfied_Then_The_Or_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => testValue);

            var vLeftOrRight = vLeft | vRight;
            var vRightOrLeft = vRight | vLeft;

            Assert.True(vLeftOrRight.IsSatisfiedBy(true), "When both specifications are satisfied, then the OR operation should be as well.");
            Assert.True(vRightOrLeft.IsSatisfiedBy(true), "When both specifications are satisfied, then the OR operation should be as well.");
        }
    }
}