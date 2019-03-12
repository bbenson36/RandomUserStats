using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomUserStats.Models;
using RandomUserStats.Services;

namespace RandomUserStats.Controllers
{
	[Route("api/[controller]")]
	public class RandomUserStatsController : Controller
	{
		private readonly IRandomUserStatService _randomUserStatService;

		public RandomUserStatsController(IRandomUserStatService randomUserStatService)
		{
			_randomUserStatService = randomUserStatService;
		}

		[HttpPost("[action]")]
		[ProducesResponseType(typeof(UserStats), 200)]
		public async Task<IActionResult> CreateRandomUserStatReport([FromBody] RootObject rootObject)
		{
			if (rootObject == null || !ModelState.IsValid)
			{
				return new BadRequestResult();
			}
			return new OkObjectResult(await _randomUserStatService.GenerateReport(rootObject.Users));
		}
	}
}
