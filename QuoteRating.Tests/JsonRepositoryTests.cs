using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework.Internal;
using Objectivity.AutoFixture.XUnit2.AutoMoq.Attributes;
using QuoteRating.Models;
using QuoteRating.Models.Factors;
using QuoteRating.Repositories;
using QuoteRating.Services;
using Xunit;

namespace QuoteRating.Tests
{
    public class JsonRepositoryTests
    {
        [Fact]
        public void ShouldReturnStateFactorsFromJsonFile()
        {
            var sut = new JsonRepository();
            var stateFactors = sut.GetStateFactors();
            Assert.True(stateFactors.Any());
        }

        [Fact]
        public void ShouldReturnBusinessFactorsFromJsonFile()
        {
            var sut = new JsonRepository();
            var businessFactors = sut.GetBusinessFactors();
            Assert.True(businessFactors.Any());
        }
    }
}
