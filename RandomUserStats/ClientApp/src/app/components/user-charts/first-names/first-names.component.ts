import { Component, OnInit } from '@angular/core';
import { UserStatsService } from '../../../services/user-stats.service';
import { UserStats } from '../../../user-stats';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet } from 'ng2-charts';

@Component({
  selector: 'app-first-names',
  templateUrl: './first-names.component.html',
  styleUrls: ['./first-names.component.css']
})
export class FirstNamesComponent implements OnInit {

  public pieChartOptions: ChartOptions = {
    responsive: true
  };
  public pieChartLabels: Label[] = ['First Names A-M', 'First Names N-Z'];
  public pieChartData: SingleDataSet = [.5, .5];
  public pieChartType: ChartType = 'pie';

  constructor(private userStatsService: UserStatsService) { }

  ngOnInit() {
    this.userStatsService.getUserStats()
      .subscribe(userStats => this.updateChart(userStats));
  }

  updateChart(userStats: UserStats) {
    if (userStats) {
      this.pieChartData = [userStats.aThroughMFirstNameRatio, 1 - userStats.aThroughMFirstNameRatio];
    }
  }
}
