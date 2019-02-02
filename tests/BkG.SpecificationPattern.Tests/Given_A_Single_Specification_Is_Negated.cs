using Xunit;
using System;
using System.Linq.Expressions;

namespace BkG.SpecificationPattern.Tests
{

    public class Given_A_Single_Specification_Is_Negated
    {
        [Fact]
        public void When_The_Restriction_Matched_Originally_Then_The_Specification_Is_Not_Satisfied()
        {
            var vSpecification = new Specification<bool>(testValue => testValue);
            var vNegatedSpecification = vSpecification.Not();

            Assert.False(vNegatedSpecification.IsSatisfiedBy(true), "Restriction that originally tested true should not satisfy the negation");
        }

        [Fact]
        public void When_The_Restriction_Did_Not_Match_Originally_Then_The_Specification_Is_Satisfied()
        {
            var vSpecification = new Specification<bool>(testValue => testValue);
            var vNegatedSpecification = vSpecification.Not();

            Assert.True(vNegatedSpecification.IsSatisfiedBy(false), "Restriction that originally tested false should satisfy the negation");
        }

        [Fact]
        public void Using_Overloaded_Operator_When_The_Restriction_Matched_Originally_Then_The_Specification_Is_Not_Satisfied()
        {
            var vSpecification = new Specification<bool>(testValue => testValue);
            var vNegatedSpecification = !vSpecification;

            Assert.False(vNegatedSpecification.IsSatisfiedBy(true), "Restriction that originally tested true should not satisfy the negation");
        }

        [Fact]
        public void Using_Overloaded_Operator_When_The_Restriction_Did_Not_Match_Originally_Then_The_Specification_Is_Satisfied()
        {
            var vSpecification = new Specification<bool>(testValue => testValue);
            var vNegatedSpecification = !vSpecification;

            Assert.True(vNegatedSpecification.IsSatisfiedBy(false), "Restriction that originally tested false should satisfy the negation");
        }

        [Fact]
        public void Using_Overloaded_Operator_When_Spec_Is_Null_Then_Throws_Required_Argument_Null_Exception()
        {
            Assert.Throws<RequiredArgumentNullException>(() =>
            {
                Specification<bool> vSpecification = null;
                var vNegatedSpecification = !vSpecification;
            });
        }
    }
}
