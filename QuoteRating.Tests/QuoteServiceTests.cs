using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Moq;
using Objectivity.AutoFixture.XUnit2.AutoMoq.Attributes;
using QuoteRating.Models;
using QuoteRating.Models.Factors;
using QuoteRating.Repositories;
using QuoteRating.Services;
using Xunit;
namespace QuoteRating.Tests
{
    public class QuoteServiceTests
    {
        [Theory, AutoMockData]
        public void ShouldReturnAdjustedQuoteWhenFactorsExistInRepository(Mock<IRepository> mockRepository, string mockState, string mockBusiness)
        {
            var stateFactor = 1.25;
            var businessFactor = 1.50;
            var revenue = 1000000;

            var inputs = new Inputs
            {
            Business = mockBusiness,
            State = mockState,
            Revenue = revenue
            };
            mockRepository.Setup(r => r.GetStateFactors()).Returns(
                new List<StateFactor>
                {
                    new StateFactor
                    {
                        State = mockState,
                        Factor = stateFactor
                    }
                });
            mockRepository.Setup(r => r.GetBusinessFactors()).Returns(
                new List<BusinessFactor>
                {
                    new BusinessFactor
                    {
                        Business = mockBusiness,
                        Factor = businessFactor
                    }
                });
            var sut = new QuoteService(mockRepository.Object);
            var quote = sut.GetQuote(inputs);
            Assert.Equal(7500,quote.Premium);
        }

        [Theory, AutoMockData]
        public void ShouldReturnNonAdjustedQuoteWhenFactorsDoNotExistInRepository(Mock<IRepository> mockRepository)
        {
            var stateFactor = 1.25;
            var businessFactor = 1.50;
            var revenue = 1000000;

            var inputs = new Inputs
            {
                Business = "Sheepshearer",
                State = "GA",
                Revenue = revenue
            };
            mockRepository.Setup(r => r.GetStateFactors()).Returns(
                new List<StateFactor>
                {
                    new StateFactor
                    {
                        State = "OH",
                        Factor = stateFactor
                    }
                });
            mockRepository.Setup(r => r.GetBusinessFactors()).Returns(
                new List<BusinessFactor>
                {
                    new BusinessFactor
                    {
                        Business = "Programmer",
                        Factor = businessFactor
                    }
                });
            var sut = new QuoteService(mockRepository.Object);
            var quote = sut.GetQuote(inputs);
            Assert.Equal(4000, quote.Premium);
        }
    }
}