import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartDataSets, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';
import { UserStatsService } from '../../../services/user-stats.service';
import { UserStats } from '../../../user-stats';

@Component({
  selector: 'app-preferred-titles',
  templateUrl: './preferred-titles.component.html',
  styleUrls: ['./preferred-titles.component.css']
})
export class PreferredTitlesComponent implements OnInit {

  public radarChartOptions: ChartOptions = {
    responsive: true,
  };
  public radarChartLabels: Label[] = ['mr', 'mrs', 'ms', 'none'];

  public radarChartData: ChartDataSets[] = [
    { data: [28, 48, 40], label: 'Users' }
  ];
  public radarChartType: ChartType = 'radar';

  constructor(private userStatsService: UserStatsService) { }

  ngOnInit() {
    this.userStatsService.getUserStats()
      .subscribe(userStats => this.updateChart(userStats));
  }

  updateChart(userStats: UserStats) {
    if (userStats) {
      this.radarChartLabels = Object.keys(userStats.preferredTitleStatistics);
      this.radarChartData = [{
        data: Object.values(userStats.preferredTitleStatistics).map((value => Number(value))),
        label: '# of Peoples Preferred Title'
      }];
    }
  }

}
