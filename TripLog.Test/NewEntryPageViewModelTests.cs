using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog
{
    [TestClass]
    public class NewEntryPageViewModelTests
    {
        private readonly Mock<ITripLogNavigation> tripLogNavigation;
        private readonly Mock<IGeoLocationService> geoLocation;
        private readonly Mock<ITripLogDataService> dataService;
        private readonly NewEntryPageViewModel testee;

        public NewEntryPageViewModelTests()
        {
            tripLogNavigation = new Mock<ITripLogNavigation>();
            geoLocation = new Mock<IGeoLocationService>();
            dataService = new Mock<ITripLogDataService>();
            testee = new NewEntryPageViewModel(tripLogNavigation.Object, geoLocation.Object, dataService.Object);
        }

        [TestMethod]
        public void Init_SetsAttributes()
        {
            // Arrange 
            var expectedCoordinates = new Coordinates() { Latitude = 10, Longitude = 20 };
            geoLocation.Setup(m => m.GetCoordinatesAsync()).ReturnsAsync(expectedCoordinates);
            
            // Act
            testee.Init();

            // Assert
            Assert.AreEqual(1, testee.Rating);
            Assert.AreEqual(DateTime.Now.Date, testee.Date.Date);
            Assert.AreEqual(expectedCoordinates.Latitude, testee.Latitude);
            Assert.AreEqual(expectedCoordinates.Longitude, testee.Longitude);
            geoLocation.Verify(m => m.GetCoordinatesAsync(), Times.Once);
        }

        [TestMethod]
        public void SaveCommandFired_TitleSet_CallsNavigate()
        {
            // Arrange
            var expectedCoordinates = new Coordinates() { Latitude = 10, Longitude = 20 };
            geoLocation.Setup(m => m.GetCoordinatesAsync()).ReturnsAsync(expectedCoordinates);
            testee.Init();

            // Act
            testee.SaveCommand.Execute(null);

            // Assert
            dataService.Verify(m => m.AddEntryAsync(It.IsAny<TripLogEntry>()), Times.Once);
            tripLogNavigation.Verify(m => m.PopAsync(), Times.Once);
        }
    }
}
