using System.Collections.Generic;
using System.Threading.Tasks;
using RandomUserStats.Models;

namespace RandomUserStats.Services
{
	public interface IRandomUserStatService
	{
		Task<UserStats> GenerateReport(List<User> users);
	}
}