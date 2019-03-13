import { Component, OnInit } from '@angular/core';
import { UserStatsService } from '../../services/user-stats.service';
import { UserStats } from '../../user-stats';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-age-ranges',
  templateUrl: './age-ranges.component.html',
  styleUrls: ['./age-ranges.component.css']
})
export class AgeRangesComponent implements OnInit {

  public barChartOptions: ChartOptions = {
    responsive: true
  };
  public barChartLabels: Label[] = ['0-20', '21-40', '41-60', '61-80', '81-100', '100+'];
  public barChartData: ChartDataSets[] = [{ data: [.3, .5, .1, .1, 0, 0], label: 'Percent of Total Population' }];
  public barChartType: ChartType = 'bar';

  constructor(private userStatsService: UserStatsService) { }

  ngOnInit() {
    this.userStatsService.getUserStats()
      .subscribe(userStats => this.updateChart(userStats));
  }

  updateChart(userStats: UserStats) {
    if (userStats) {
      const ageStats = userStats.ageRangePercentages;
      this.barChartData = [{
        data: [
          ageStats.zeroThroughTwenty,
          ageStats.twentyOneThroughForty,
          ageStats.fortyOneThroughSixty,
          ageStats.sixtyOneThroughEighty,
          ageStats.eightyOneThroughOneHundred,
          ageStats.overOneHundred
        ],
        label: 'Percent of Total Population'
      }];
    }
  }

}
