using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using PhoneOperator.Infra.Context;
using PhoneOperator.Domain.Models;
using PhoneOperator.Infra.Repositories;

namespace PhoneOperator.Test.Infra.Repositories
{
    public class PhoneOperatorRepositoryTest
    {
        [Fact]
        public void Should_Return_Success_GetAllPhoneOperators()
        {
            // Arrange
            var mockContext = new Mock<DatabaseContext>();
            var mockSet = new Mock<DbSet<Operator>>();
            var data = new List<Operator> { new Operator { } }.AsQueryable();

            mockSet.As<IQueryable<Operator>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockContext.Setup(m => m.Set<Operator>()).Returns(mockSet.Object);

            // Act
            var repository = new Mock<PhoneOperatorRepository>(mockContext.Object);
            var phoneOperators = repository.Object.GetAllOperators();

            // Assert
            Assert.NotEmpty(phoneOperators);
        }

        // [Theory]
        // [InlineData(21)]
        // public void Should_Return_Success_GetPhoneOperatorById(int id)
        // {

        // }
    }
}