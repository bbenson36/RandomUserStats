import { Component, OnInit } from '@angular/core';
import { UserStatsService } from '../../../services/user-stats.service';
import { UserStats } from '../../../user-stats';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet } from 'ng2-charts';

@Component({
  selector: 'app-female-ratio',
  templateUrl: './female-ratio.component.html',
  styleUrls: ['./female-ratio.component.css']
})
export class FemaleRatioComponent implements OnInit {

  public pieChartOptions: ChartOptions = {
    responsive: true
  };
  public pieChartLabels: Label[] = ['Male', 'Female'];
  public pieChartData: SingleDataSet = [.5, .5];
  public pieChartType: ChartType = 'pie';

  constructor(private userStatsService: UserStatsService) { }

  ngOnInit() {
    this.userStatsService.getUserStats()
      .subscribe(userStats => this.updateChart(userStats));
  }

  updateChart(userStats: UserStats) {
    if (userStats) {
      this.pieChartData = [userStats.femaleToMaleRatio, 1 - userStats.femaleToMaleRatio];
    }
  }
}
