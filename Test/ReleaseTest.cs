using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Infra.Database;
using Domain.Aggregations;
using Application.Services;
using Microsoft.Extensions.Logging;

namespace Tests
{  
    [TestClass]
    public class ReleaseTest
    {
        [Test]
        public void CreateRelease()
        {
            // Arrange
            var release = new Release()
            {
                Description = "Teste",
                Amount = 20M,
                TransactionType = Domain.Enum.TransactionType.Credit
            };

            var mockLogger = new Mock<ILogger<AccountingService>>();
            var mockSet = new Mock<DbSet<Accounting>>();   
            
            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(m => m.Accounting).Returns(mockSet.Object);

            // Act     
            var service = new AccountingService(mockContext.Object, mockLogger.Object);
            service.Create(release);

            // Assert
            mockSet.Verify(m => m.AddAsync(It.IsAny<Accounting>(),default), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Test]
        public void RemoveRelease()
        {
            // Arrange
            var id = 1;
            var accounting = new Accounting();

            var mockLogger = new Mock<ILogger<AccountingService>>();
            var mockSet = new Mock<DbSet<Accounting>>();

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(m => m.Accounting).Returns(mockSet.Object);
            mockContext.Setup(m => m.Accounting.FindAsync(id)).ReturnsAsync(accounting);

            // Act     
            var service = new AccountingService(mockContext.Object, mockLogger.Object);
            service.Remove(id);

            // Assert
            mockSet.Verify(m => m.Remove(accounting), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Test]
        public void GetRelease()
        {
            // Arrange
            var id = 1;
            var accounting = new Accounting();

            var mockLogger = new Mock<ILogger<AccountingService>>();
            var mockSet = new Mock<DbSet<Accounting>>();

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(m => m.Accounting).Returns(mockSet.Object);
            mockContext.Setup(m => m.Accounting.FindAsync(id)).ReturnsAsync(accounting);

            // Act     
            var service = new AccountingService(mockContext.Object, mockLogger.Object);
            service.Get(id);

            // Assert
            mockSet.Verify(m => m.FindAsync(id), Times.Once());
        }
    }
}