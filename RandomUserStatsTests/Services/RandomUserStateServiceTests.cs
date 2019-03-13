using RandomUserStats.Models;
using RandomUserStats.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RandomUserStatsTests.Services
{
	public class RandomUserStateServiceTests
	{
		[Fact]
		public async void ProperlyCaclulatesPercentageOfFemaleToMale()
		{
			var users = new List<User>()
			{
				new User()
				{
					Gender = Gender.Male
				},
				new User()
				{
					Gender = Gender.Male
				},
				new User()
				{
					Gender = Gender.Male
				},
				new User()
				{
					Gender = Gender.Female
				}
			};

			var sut = new RandomUserStatService();

			var result = await sut.GenerateReport(users);

			Assert.Equal(.25, result.FemaleToMaleRatio);
		}

		[Fact]
		public async void HandlesUsersMissingAllData()
		{
			var users = new List<User>()
			{
				new User(),
				new User(),
				new User(),
				new User()
			};

			var sut = new RandomUserStatService();

			var result = await sut.GenerateReport(users);

			Assert.Equal(0, result.FemaleToMaleRatio);
			Assert.Null(result.AgeRangePercentages);
			Assert.Empty(result.MostPopulousStates);
			Assert.Equal(0, result.AThroughMFirstNameRatio);
			Assert.Equal(0, result.AThroughMLastNameRatio);
		}

		[Fact]
		public async void ProperlyCaclulatesFirstNameAThroughMRatio()
		{
			var users = new List<User>()
			{
				new User()
				{
					Name = new Name
					{
						First = "anderson"
					}
				},
				new User()
				{
					Name = new Name
					{
						First = "BILLy"
					}
				},
				new User()
				{
					Name = new Name
					{
						First = "Xavier"
					}
				},
				new User()
				{
					Name = new Name
					{
						First = "Patty"
					}
				}
			};

			var sut = new RandomUserStatService();

			var result = await sut.GenerateReport(users);

			Assert.Equal(.5, result.AThroughMFirstNameRatio);
		}

		[Fact]
		public async void ProperlyCaclulatesLastNameAThroughMRatio()
		{
			var users = new List<User>()
			{
				new User()
				{
					Name = new Name
					{
						Last = "anderson"
					}
				},
				new User()
				{
					Name = new Name
					{
						Last = "BILLy"
					}
				},
				new User()
				{
					Name = new Name
					{
						Last = "Xavier"
					}
				},
				new User()
				{
					Name = new Name
					{
						Last = "Patty"
					}
				}
			};

			var sut = new RandomUserStatService();

			var result = await sut.GenerateReport(users);

			Assert.Equal(.5, result.AThroughMLastNameRatio);
		}

		[Fact]
		public async void ProperlyCaclulatesStatePopulationPercentages()
		{
			var users = new List<User>()
			{
				new User()
				{
					Gender = Gender.Female,
					Location = new Location
					{
						State = "New York"
					}
				},
				new User()
				{
					Gender = Gender.Male,
					Location = new Location
					{
						State = "New York"
					}
				},
				new User()
				{
					Gender = Gender.Female,
					Location = new Location
					{
						State = "Florida"
					}
				},
				new User()
				{
					Gender = Gender.Male,
					Location = new Location
					{
						State = "Texas"
					}
				},
				new User()
				{
					Gender = Gender.Male,
					Location = new Location
					{
						State = "Texas"
					}
				},
				new User()
				{
					Gender = Gender.Female,
					Location = new Location
					{
						State = "Texas"
					}
				}
			};

			var sut = new RandomUserStatService();

			var result = await sut.GenerateReport(users);

			Assert.Equal(3, result.MostPopulousStates.Count);
			Assert.Equal("Texas",
				result.MostPopulousStates.First().State);
			Assert.Equal(.5,
				result.MostPopulousStates.First().PercentageOfTotalPopulation, 4);
			Assert.Equal(.6667,
				result.MostPopulousStates.First().MalePercent, 4);
			Assert.Equal(.3333,
				result.MostPopulousStates.First().FemalePercent, 4);
		}

		[Fact]
		public async void ProperlyCalculatesAgeRangePercentages()
		{
			var users = new List<User>()
			{
				new User()
				{
					DateOfBirth = new AgeInfo
					{
						Age = 5
					}
				},
				new User()
				{
					DateOfBirth = new AgeInfo
					{
						Age = 89
					}
				},
				new User()
				{
					DateOfBirth = new AgeInfo
					{
						Age = 30
					}
				},
				new User()
				{
					DateOfBirth = new AgeInfo
					{
						Age = 115
					}
				}
			};

			var sut = new RandomUserStatService();

			var result = await sut.GenerateReport(users);

			var ageRanges = result.AgeRangePercentages;

			Assert.Equal(.25, ageRanges.ZeroThroughTwenty);
			Assert.Equal(.25, ageRanges.TwentyOneThroughForty);
			Assert.Equal(0, ageRanges.FortyOneThroughSixty);
			Assert.Equal(0, ageRanges.SixtyOneThroughEighty);
			Assert.Equal(.25, ageRanges.EightyOneThroughOneHundred);
			Assert.Equal(.25, ageRanges.OverOneHundred);

		}

		[Fact]
		public async void ProperlyCalculatesUserTitleCounts()
		{
			var users = new List<User>()
			{
				new User()
				{
					Name = new Name
					{
						Title = "Mr"
					}
				},
				new User()
				{
					Name = new Name
					{
						Title = "Mr"
					}
				},
				new User()
				{
					Name = new Name
					{
						Title = "Mr"
					}
				},
				new User()
				{
					Name = new Name
					{
						Title = "Mrs"
					}
				},
				new User()
				{
					Name = new Name
					{
					}
				}
			};

			var sut = new RandomUserStatService();

			var result = await sut.GenerateReport(users);

			var titleStatistics = result.PreferredTitleStatistics;

			Assert.True(titleStatistics.ContainsKey("Mrs"));
			Assert.Equal(1, titleStatistics["Mrs"]);
			Assert.True(titleStatistics.ContainsKey("Mr"));
			Assert.Equal(3, titleStatistics["Mr"]);
			Assert.True(titleStatistics.ContainsKey("none"));
			Assert.Equal(1, titleStatistics["none"]);
		}
	}
}
