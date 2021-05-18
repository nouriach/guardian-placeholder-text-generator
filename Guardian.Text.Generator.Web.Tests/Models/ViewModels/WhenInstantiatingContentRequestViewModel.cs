using Guardian.Text.Generator.Web.Application.Results.Authors;
using Guardian.Text.Generator.Web.Models.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardian.Text.Generator.Web.Tests.Models.ViewModels
{
    public class WhenInstantiatingContentRequestViewModel
    {
        [Test]
        public void GivenConstructor_WithStringCollection_FillProperties()
        {
            //Arrange
            GetAuthorsResult authors = new GetAuthorsResult()
            {
                Authors = new List<string>()
                {
                    "www",
                    "xxx",
                    "yyy",
                    "zzz"
                }
            };

            //Act
            ContentRequestViewModel req = new ContentRequestViewModel(authors);
            //Assert
            Assert.AreEqual(authors.Authors, req.Authors);
        }
    }
}
