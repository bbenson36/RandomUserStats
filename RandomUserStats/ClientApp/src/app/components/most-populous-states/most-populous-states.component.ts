import { Component, OnInit } from '@angular/core';
import { UserStatsService } from '../../services/user-stats.service';
import { UserStats } from '../../user-stats';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-most-populous-states',
  templateUrl: './most-populous-states.component.html',
  styleUrls: ['./most-populous-states.component.css']
})
export class MostPopulousStatesComponent implements OnInit {

  public barChartOptions: ChartOptions = {
    responsive: true
  };
  public barChartLabels: Label[] = ['Durango', 'Zacatecas'];
  public barChartData: ChartDataSets[] = [
    { data: [.8, .2], label: 'Total Population' },
    { data: [.5, .3], label: 'Male Ratio' },
    { data: [.5, .7], label: 'Female Ratio' }
  ];
  public barChartType: ChartType = 'bar';

  constructor(private userStatsService: UserStatsService) { }

  ngOnInit() {
    this.userStatsService.getUserStats()
      .subscribe(userStats => this.updateChart(userStats));
  }

  updateChart(userStats: UserStats) {
    if (userStats) {
      this.barChartLabels = userStats.mostPopulousStates.map(statePop => statePop.state);
      this.barChartData = [
        { data: userStats.mostPopulousStates.map(statPop => statPop.percentageOfTotalPopulation), label: 'Total Population' },
        { data: userStats.mostPopulousStates.map(statePop => statePop.malePercent), label: 'Male Ratio' },
        { data: userStats.mostPopulousStates.map(statePop => statePop.femalePercent), label: 'Female Ratio' }
      ];
    }
  }

}
