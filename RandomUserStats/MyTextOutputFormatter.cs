using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using RandomUserStats.Models;

namespace RandomUserStats
{
	public class MyTextOutputFormatter : OutputFormatter, IOutputFormatter
	{
		public string ContentType { get; private set; }

		public MyTextOutputFormatter()
		{
			ContentType = "text/plain";
			SupportedMediaTypes.Add(ContentType);
		}

		public override bool CanWriteResult(OutputFormatterCanWriteContext context)
		{
			return context.Object is UserStats;
		}

		public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
		{
			var response = context.HttpContext.Response;

			var buffer = new StringBuilder();
			if (context.Object is UserStats userStats)
			{
				buffer.AppendLine($"Percentage female versus male: {ToPercent(userStats.FemaleToMaleRatio)}");
				buffer.AppendLine();

				buffer.AppendLine($"Percentage of first names that start with A-M versus N-Z: {ToPercent(userStats.AThroughMFirstNameRatio)}");
				buffer.AppendLine();

				buffer.AppendLine($"Percentage of last names that start with A-M versus N-Z: {ToPercent(userStats.AThroughMLastNameRatio)}");
				buffer.AppendLine();

				AddMostPopulousStates(buffer, userStats.MostPopulousStates);
				buffer.AppendLine();

				AddAgeRangePercentages(buffer, userStats.AgeRangePercentages);
				buffer.AppendLine();

				AddPreferredTitles(buffer, userStats.PreferredTitleStatistics);
			}

			return response.WriteAsync(buffer.ToString());
		}

		private static void AddPreferredTitles(StringBuilder buffer, Dictionary<string, int> preferredTitleStatistics)
		{
			buffer.AppendLine($"Number of people who prefer each title:");
			foreach (var preferredTitleInfo in preferredTitleStatistics)
			{
				buffer.AppendLine($"	{preferredTitleInfo.Key}: {preferredTitleInfo.Value}");
			}
		}

		private static void AddMostPopulousStates(StringBuilder buffer, List<StatePopulationPercentage> mostPopulousStates)
		{
			buffer.AppendLine($"Percentage of people in each state, up to the top 10 most populous states:");
			foreach (var state in mostPopulousStates)
			{
				buffer.AppendLine($"	{state.State}: {ToPercent(state.PercentageOfTotalPopulation)}");
				buffer.AppendLine($"		Female Ratio: {ToPercent(state.FemalePercent)}");
				buffer.AppendLine($"		Male Ratio: {ToPercent(state.MalePercent)}");
			}
		}

		private static void AddAgeRangePercentages(StringBuilder buffer, AgeRangePercentages ageRangePercentages)
		{
			buffer.AppendLine($"Percentage of people in the following age ranges:");
			buffer.AppendLine($"	0-20: {ToPercent(ageRangePercentages.ZeroThroughTwenty)}");
			buffer.AppendLine($"	21-40: {ToPercent(ageRangePercentages.TwentyOneThroughForty)}");
			buffer.AppendLine($"	41-60: {ToPercent(ageRangePercentages.FortyOneThroughSixty)}");
			buffer.AppendLine($"	61-80: {ToPercent(ageRangePercentages.SixtyOneThroughEighty)}");
			buffer.AppendLine($"	81-100: {ToPercent(ageRangePercentages.EightyOneThroughOneHundred)}");
			buffer.AppendLine($"	100+: {ToPercent(ageRangePercentages.OverOneHundred)}");
		}

		private static string ToPercent(double number)
		{
			return $"{(number * 100).ToString("0.##")}%";
		}
	}
}