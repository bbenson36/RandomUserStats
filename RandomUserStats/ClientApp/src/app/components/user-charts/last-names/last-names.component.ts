import { Component, OnInit } from '@angular/core';
import { UserStatsService } from '../../../services/user-stats.service';
import { UserStats } from '../../../user-stats';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet } from 'ng2-charts';

@Component({
  selector: 'app-last-names',
  templateUrl: './last-names.component.html',
  styleUrls: ['./last-names.component.css']
})
export class LastNamesComponent implements OnInit {
  public pieChartOptions: ChartOptions = {
    responsive: true
  };
  public pieChartLabels: Label[] = ['Last Names A-M', 'Last Names N-Z'];
  public pieChartData: SingleDataSet = [.5, .5];
  public pieChartType: ChartType = 'pie';

  constructor(private userStatsService: UserStatsService) { }

  ngOnInit() {
    this.userStatsService.getUserStats()
      .subscribe(userStats => this.updateChart(userStats));
  }

  updateChart(userStats: UserStats) {
    if (userStats) {
      this.pieChartData = [userStats.aThroughMLastNameRatio, 1 - userStats.aThroughMLastNameRatio];
    }
  }
}
