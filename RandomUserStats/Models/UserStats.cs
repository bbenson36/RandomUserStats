using System.Collections.Generic;

namespace RandomUserStats.Models
{
	public class UserStats
	{
		public double FemaleToMaleRatio { get; set; }
		public double AThroughMFirstNameRatio { get; set; }
		public double AThroughMLastNameRatio { get; set; }
		public List<StatePopulationPercentage> MostPopulousStates { get; set; }
		public AgeRangePercentages AgeRangePercentages { get; set; }
		public Dictionary<string, int> PreferredTitleStatistics { get; set;}
	}
}
