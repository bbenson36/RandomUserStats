using RandomUserStats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomUserStats.Services
{
	public class RandomUserStatService : IRandomUserStatService
	{
		public async Task<UserStats> GenerateReport(List<User> users)
		{
			return await Task.Run(() =>
			{
				return new UserStats()
				{
					FemaleToMaleRatio = FemaleToMaleRatio(users),
					AThroughMFirstNameRatio = FirstNameAThroughMRatio(users),
					AThroughMLastNameRatio = LastNameAThroughMRatio(users),
					AgeRangePercentages = GetPercentOfPeopleInAgeRange(users),
					MostPopulousStates = GetStatePopulationPercentages(users),
					PreferredTitleStatistics = GetPreferredTitleStatistics(users)
				};
			});
		}


		private Dictionary<string, int> GetPreferredTitleStatistics(List<User> users)
		{
			var titleDictionary = new Dictionary<string, int>();
			if (users.Any(x => x.Name == null))
			{
				return titleDictionary;
			}
			foreach (var title in users.Select(x => x.Name.Title ?? "none"))
			{
				if (!titleDictionary.ContainsKey(title))
				{
					titleDictionary[title] = 1;
				}
				else
				{
					titleDictionary[title]++;
				}
			}
			return titleDictionary;
		}

		private double FemaleToMaleRatio(List<User> users)
		{
			return ((double)users.Count(x => x.Gender == Gender.Female)) / users.Count;
		}

		private double FirstNameAThroughMRatio(List<User> users)
		{
			if (users.Any(x => x.Name == null || string.IsNullOrEmpty(x.Name.First)))
			{
				return 0;
			}
			return ((double)users.Count(x => FirstCharacterIsInAToMRange(x.Name.First))) / users.Count;
		}

		private double LastNameAThroughMRatio(List<User> users)
		{
			if (users.Any(x => x.Name == null || string.IsNullOrEmpty(x.Name.Last)))
			{
				return 0;
			}
			return ((double)users.Count(x => FirstCharacterIsInAToMRange(x.Name.Last))) / users.Count;
		}

		private static bool FirstCharacterIsInAToMRange(string name)
		{
			var firstCharacter = name.ToUpper().First();
			return 'A' <= firstCharacter && firstCharacter <= 'M';
		}

		private List<StatePopulationPercentage> GetStatePopulationPercentages(List<User> users)
		{
			if (users.Any(x => x.Location == null))
			{
				return new List<StatePopulationPercentage>();
			}

			var statePopulationDictionary = new Dictionary<string, int[]>();
			foreach (var user in users)
			{
				var userState = user.Location.State;

				if (!statePopulationDictionary.ContainsKey(userState))
					statePopulationDictionary.Add(userState, new int[2]);

				statePopulationDictionary[userState][(int)user.Gender]++;
			}
			return CreateStatePopulationList(statePopulationDictionary, users.Count);
		}

		private List<StatePopulationPercentage> CreateStatePopulationList(Dictionary<string, int[]> statePopulationDictionary, double totalPopulation)
		{
			return statePopulationDictionary.Select(x =>
				{
					var totalStatePopulation = (double)x.Value.Sum();
					return new StatePopulationPercentage
					{
						State = x.Key,
						PercentageOfTotalPopulation = totalStatePopulation / totalPopulation,
						FemalePercent = x.Value[(int)Gender.Female] / totalStatePopulation,
						MalePercent = x.Value[(int)Gender.Male] / totalStatePopulation
					};
				}).OrderByDescending(x => x.PercentageOfTotalPopulation)
				.ToList();
		}

		private AgeRangePercentages GetPercentOfPeopleInAgeRange(List<User> users)
		{
			if (users.Any(x => x.DateOfBirth == null))
			{
				return null;
			}

			var ageHistogram = new int[6];
			foreach (var age in users.Select(x => x.DateOfBirth.Age))
			{
				if (age > 100)
					ageHistogram[5]++;
				else
					ageHistogram[(age - 1) / 20]++;
			}
			return new AgeRangePercentages
			{
				ZeroThroughTwenty = ((double)ageHistogram[0]) / users.Count,
				TwentyOneThroughForty = ((double)ageHistogram[1]) / users.Count,
				FortyOneThroughSixty = ((double)ageHistogram[2]) / users.Count,
				SixtyOneThroughEighty = ((double)ageHistogram[3]) / users.Count,
				EightyOneThroughOneHundred = ((double)ageHistogram[4]) / users.Count,
				OverOneHundred = ((double)ageHistogram[5]) / users.Count
			};
		}
	}
}
