using RandomUserStats.Controllers;
using RandomUserStats.Services;
using Xunit;
using Moq;
using RandomUserStats.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RandomUserStatsTests.Controllers
{
	public class RandomUserStatsControllerTest
	{
		[Theory, AutoMoqData]
		public async void ReturnsOkayResponse(
			Mock<IRandomUserStatService> randomUserStatService,
			RootObject request)
		{
			var sut = new RandomUserStatsController(randomUserStatService.Object);

			var result = await sut.CreateRandomUserStatReport(request);

			randomUserStatService.Verify(x => x.GenerateReport(It.IsAny<List<User>>()), Times.Once);

			Assert.IsType<OkObjectResult>(result);
		}

		[Theory, AutoMoqData]
		public async void ReturnsBadRequestOnFailedParse(Mock<IRandomUserStatService> randomUserStatService)
		{
			var sut = new RandomUserStatsController(randomUserStatService.Object);

			var result = await sut.CreateRandomUserStatReport(null);

			randomUserStatService.Verify(x => x.GenerateReport(It.IsAny<List<User>>()), Times.Never);

			Assert.IsType<BadRequestResult>(result);
		}
	}
}
