using Moq;
using Xunit;
using PhoneOperator.Domain.Interfaces;
using PhoneOperator.Domain.Services;

namespace PhoneOperator.Test.Domain.Services
{
    public class PhoneOperatorServiceTest
    {
        [Fact]
        public void Should_Return_Success_GetAllPhoneOperators()
        {
            // Arrange
            var mockRepository = new Mock<IPhoneOperatorRepository>();

            // Act
            var service = new Mock<PhoneOperatorService>(mockRepository.Object);
            var phoneOperators = service.Object.GetAllPhoneOperators();

            // Assert
            Assert.NotEmpty(phoneOperators);
        }
    }
}