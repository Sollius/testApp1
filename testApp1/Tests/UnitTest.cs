using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;

using testApp1.Pages;
using testApp1.Back_end;

public class IndexModelTests
{
    [Fact]
    public void OnPost_ShouldSaveData_WhenValidDataProvided()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        using (var dbContext = new ApplicationDbContext(options))
        {
            var loggerMock = new Mock<ILogger<IndexModel>>();
            var pageModel = new IndexModel(dbContext, loggerMock.Object);

            pageModel.MouseTrackingData = "100,200,2024.03.20 12:00:00.123;150,250,2024.03.20 12:01:00.999;";

            pageModel.OnPost();

            var savedData = dbContext.MovementDatas.Include(m => m.TrackingData).FirstOrDefault();
            Assert.NotNull(savedData);
            Assert.Equal(2, savedData.TrackingData.Count);
            Assert.Equal(100, savedData.TrackingData[0].xCoord);
            Assert.Equal(200, savedData.TrackingData[0].yCoord);
        }
    }

    [Fact]
    public void OnPost_ShouldNotSave_WhenDataIsEmpty()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        using (var dbContext = new ApplicationDbContext(options))
        {
            var loggerMock = new Mock<ILogger<IndexModel>>();
            var pageModel = new IndexModel(dbContext, loggerMock.Object);

            pageModel.MouseTrackingData = "";

            pageModel.OnPost();

            var savedData = dbContext.MovementDatas.FirstOrDefault();
            Assert.Null(savedData);
        }
    }
}

