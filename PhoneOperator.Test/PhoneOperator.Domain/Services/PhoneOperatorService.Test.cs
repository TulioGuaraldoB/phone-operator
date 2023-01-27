using Moq;
using Xunit;
using System.Collections.Generic;
using PhoneOperator.Domain.Models;
using PhoneOperator.Domain.Services;
using PhoneOperator.Domain.Interfaces;
using System.Linq;

namespace PhoneOperator.Test.Domain.Services
{
    public class PhoneOperatorServiceTest
    {
        [Fact]
        public void Should_Return_Success_GetAllPhoneOperators()
        {
            // Arrange
            var mockRepository = new Mock<IPhoneOperatorRepository>();
            var data = new List<Operator> { new Operator {
                Id = 12321,
                Name = "ASfasdfasdf",
                OperatorCode = 312
             } }.AsQueryable();

            mockRepository.Setup(r => r.GetAllOperators()).Returns(data.ToList());

            // Act
            var service = new Mock<IPhoneOperatorService>();
            service.Setup(s => s.GetAllPhoneOperators()).Returns(mockRepository.Object.GetAllOperators());
            var phoneOperators = service.Object.GetAllPhoneOperators();

            // Assert
            Assert.NotNull(phoneOperators);
        }
    }
}