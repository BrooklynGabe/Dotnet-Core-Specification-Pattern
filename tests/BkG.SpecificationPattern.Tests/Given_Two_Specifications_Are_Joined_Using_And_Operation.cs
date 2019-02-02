using Xunit;
using System;
using System.Linq.Expressions;

namespace BkG.SpecificationPattern.Tests
{

    public class Given_Two_Specifications_Are_Joined_Using_And_Operation
    {
        [Fact]
        public void When_The_Other_Spec_Is_Null_Then_Required_Argument_Null_Exception_Is_Thrown()
        {
            Assert.Throws<RequiredArgumentNullException>(() =>
            {
                var vLeft = new Specification<bool>(testValue => testValue);
                Specification<bool> vRight = null;

                var vLeftAndRight = vLeft.And(vRight);
            });
        }

        [Fact]
        public void When_Both_Specifications_Are_Satisfied_Then_The_And_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !!testValue);

            var vLeftAndRight = vLeft.And(vRight);
            var vRightAndLeft = vRight.And(vLeft);

            Assert.True(vLeftAndRight.IsSatisfiedBy(true), "When both original specifications are satisfied, then the AND operation should be as well.");
            Assert.True(vRightAndLeft.IsSatisfiedBy(true), "When both original specifications are satisfied, then the AND operation should be as well.");
        }

        [Fact]
        public void When_One_Specification_Is_Not_Satisfied_Then_The_And_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftAndRight = vLeft.And(vRight);
            var vRightAndLeft = vRight.And(vLeft);

            Assert.False(vLeftAndRight.IsSatisfiedBy(true), "When one specification is not satisfied, then the AND operation should not be as well.");
            Assert.False(vRightAndLeft.IsSatisfiedBy(true), "When one specification is not satisfied, then the AND operation should not be as well.");
        }

        [Fact]
        public void When_Neither_Specifications_Is_Satisfied_Then_The_And_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => !testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftAndRight = vLeft.And(vRight);
            var vRightAndLeft = vRight.And(vLeft);

            Assert.False(vLeftAndRight.IsSatisfiedBy(true), "When both specifications are not satisfied, then the AND operation should not be as well.");
            Assert.False(vRightAndLeft.IsSatisfiedBy(true), "When both specifications are not satisfied, then the AND operation should not be as well.");
        }

        [Fact]
        public void Using_Overloaded_Operator_When_This_Spec_Is_Null_Then_Required_Argument_Null_Exception_Is_Thrown()
        {
            Assert.Throws<RequiredArgumentNullException>(() =>
            {
                Specification<bool> vLeft = null;
                var vRight = new Specification<bool>(testValue => testValue);

                var vLeftAndRight = vLeft & vRight;
            });
        }

        [Fact]
        public void Using_Overloaded_Operator_When_Both_Specifications_Are_Satisfied_Then_The_And_Operation_Is_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !!testValue);

            var vLeftAndRight = vLeft & vRight;
            var vRightAndLeft = vRight & vLeft;

            Assert.True(vLeftAndRight.IsSatisfiedBy(true), "When both original specifications are satisfied, then the AND operation should be as well.");
            Assert.True(vRightAndLeft.IsSatisfiedBy(true), "When both original specifications are satisfied, then the AND operation should be as well.");
        }

        [Fact]
        public void Using_Overloaded_Operator_When_One_Specification_Is_Not_Satisfied_Then_The_And_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftAndRight = vLeft & vRight;
            var vRightAndLeft = vRight & vLeft;

            Assert.False(vLeftAndRight.IsSatisfiedBy(true), "When one specification is not satisfied, then the AND operation should not be as well.");
            Assert.False(vRightAndLeft.IsSatisfiedBy(true), "When one specification is not satisfied, then the AND operation should not be as well.");
        }

        [Fact]
        public void Using_Overloaded_Operator_When_Neither_Specifications_Is_Satisfied_Then_The_And_Operation_Is_Not_Satisfied()
        {
            var vLeft = new Specification<bool>(testValue => !testValue);
            var vRight = new Specification<bool>(testValue => !testValue);

            var vLeftAndRight = vLeft & vRight;
            var vRightAndLeft = vRight & vLeft;

            Assert.False(vLeftAndRight.IsSatisfiedBy(true), "When both specifications are not satisfied, then the AND operation should not be as well.");
            Assert.False(vRightAndLeft.IsSatisfiedBy(true), "When both specifications are not satisfied, then the AND operation should not be as well.");
        }
    }
}