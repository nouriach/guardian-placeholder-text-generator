using Guardian.Text.Generator.Web.Extensions;
using NUnit.Framework;


namespace Guardian.Text.Generator.Web.Tests.Extensions
{
    public class WhenUsingRemoveSpecificCharacters
    {
         // Arrange
         // Act
         // Assert
        [Test]
        [TestCase("Sachin Nakrani is a writer and editor for Guardian Sport. Twitter&nbsp;@SachinNakrani", "Sachin Nakrani is a writer and editor for Guardian Sport. Twitter @SachinNakrani")]
        public void GivenString_WithNonBreakingSpace_RemoveAndReplaceWithSpace(string copy, string expected)
        {
            // Arrange
            // Act
            var actual = copy.RemoveNonBreakingSpaceFromString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
