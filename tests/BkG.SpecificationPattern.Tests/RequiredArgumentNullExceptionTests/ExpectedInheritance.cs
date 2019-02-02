using System;
using Xunit;

namespace BkG.SpecificationPattern.Tests.RequiredArgumentNullExceptionTests
{
    public class ExpectedInheritance
    {
        protected readonly RequiredArgumentNullException exception;
        
        public ExpectedInheritance()
        {
            exception = new RequiredArgumentNullException();
        }

        [Fact]
        public void TypeOfArgumentNullException()
        {
            Assert.True(exception is ArgumentNullException, "The exception should inherit from this type.");
        }
    }
}