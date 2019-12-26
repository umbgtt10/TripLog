using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;

namespace TripLog
{
    [TestClass]
    public class MainPageViewModelTests
    {
        private readonly MainPageViewModel testee;
        private readonly Mock<ITripLogFactory> tripLogFactoryMock;
        private readonly Mock<ITripLogDataService> tripLogDataServiceMock;

        public MainPageViewModelTests()
        {
            tripLogFactoryMock = new Mock<ITripLogFactory>();
            tripLogDataServiceMock = new Mock<ITripLogDataService>();
            testee = new MainPageViewModel(tripLogFactoryMock.Object, tripLogDataServiceMock.Object);
        }

        [TestMethod]
        public void Init_CallsRetrieveEntries()
        {
            // Arrange && Act
            testee.Init();

            // Assert
            tripLogDataServiceMock.Verify(m => m.ReadAllEntriesAsync());
        }

        [TestMethod]
        public void NewCommandFired_CallsNavigate()
        {
            // Arrange & Act
            testee.NewCommand.Execute(null);

            // Assert
            tripLogFactoryMock.Verify(m => m.NavigateToNewPage(), Times.Once);
            tripLogFactoryMock.Verify(m => m.NavigateToDetailPage(It.IsAny<TripLogEntry>()), Times.Never);
        }

        [TestMethod]
        public void DetailSelectedFired_CallsNavigate()
        {
            // Arrange 
            var expectedEntry = new TripLogEntry();

            // Act
            testee.DetailSelectedItem = expectedEntry;

            // Assert
            tripLogFactoryMock.Verify(m => m.NavigateToDetailPage(expectedEntry), Times.Once);
            tripLogFactoryMock.Verify(m => m.NavigateToNewPage(), Times.Never);
        }
    }
}
