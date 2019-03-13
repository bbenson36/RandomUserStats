import { Component, OnInit } from '@angular/core';
import { UserStatsService } from '../../services/user-stats.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css']
})
export class UserDataComponent implements OnInit {
  userDataInput = '';

  constructor(private userStatsService: UserStatsService,
    private router: Router) { }

  ngOnInit() {
  }

  onSubmit() {
    this.userStatsService.requestUserStats(this.userDataInput);
    this.router.navigate(['/', 'user-charts']);
  }

  handleFileInput(files: FileList) {
    const reader = new FileReader();
    const that = this;
    reader.onload = () => {
      that.userDataInput = reader.result.toString();
    };
    reader.readAsText(files.item(0));
  }

}
