using System;
using Xunit;

namespace BkG.SpecificationPattern.Tests
{
    
    public class Given_A_Required_Argument_Null_Exception
    {
        [Fact]
        public void When_The_Exception_Is_Referenced_Then_It_Is_A_Type_Of_Null_Reference_Exception()
        {
            var vException = new RequiredArgumentNullException();

            Assert.True(vException is ArgumentNullException, "The exception should inherit from this type.");
        }
    }
}
