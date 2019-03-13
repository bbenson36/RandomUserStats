import { Component, OnInit } from '@angular/core';
import { UserStatsService } from '../../services/user-stats.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-charts',
  templateUrl: './user-charts.component.html',
  styleUrls: ['./user-charts.component.css']
})
export class UserChartsComponent implements OnInit {

  constructor(private userStatsService: UserStatsService,
    private router: Router) { }

  ngOnInit() {
    if (!this.userStatsService.dataRequested) {
      this.router.navigate(['/']);
    }
  }

  updateCharts() {
  }
}
