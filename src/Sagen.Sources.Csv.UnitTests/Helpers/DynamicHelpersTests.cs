using FluentAssertions;
using Sagen.Sources.Csv.Helpers;
using System;
using System.Dynamic;
using Xunit;

namespace Sagen.Sources.Csv.UnitTests.Helpers
{
    public class DynamicHelpersTests
    {
        [Fact]
        public void GetPropertyValueAs_NullItem_ThrowsArgumentNullException()
        {
            Action act = () => DynamicHelpers.GetPropertyValueAs<string>(null, "prop1");

            act.Should()
                .Throw<ArgumentNullException>()
                .And
                .ParamName
                .Should()
                .Be("item");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("    ")]
        public void GetPropertyValueAs_InvalidPropertyName_ThrowsArgumentException(string propertyName)
        {
            dynamic d = 1;

            Action act = () => DynamicHelpers.GetPropertyValueAs<string>(d, propertyName);

            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("propertyName cannot be null or whitespace. (Parameter 'propertyName')")
                .And
                .ParamName
                .Should()
                .Be("propertyName");
        }

        [Fact]
        public void GetPropertyValueAs_PropertyNameDoesntExistOnExpandoObject_ThrowsArgumentException()
        {
            dynamic d = new ExpandoObject();
            Action act = () => DynamicHelpers.GetPropertyValueAs<string>(d, "prop1");

            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("A property with name 'prop1' does not exist. (Parameter 'propertyName')")
                .And
                .ParamName
                .Should()
                .Be("propertyName");
        }

        [Fact]
        public void GetPropertyValueAs_PropertyNameDoesntExistOnStandardType_ThrowsArgumentException()
        {
            dynamic d = 1;
            Action act = () => DynamicHelpers.GetPropertyValueAs<string>(d, "prop1");

            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("A property with name 'prop1' does not exist. (Parameter 'propertyName')")
                .And
                .ParamName
                .Should()
                .Be("propertyName");
        }
    }
}
