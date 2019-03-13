import { Component, OnInit } from '@angular/core';
import { UserStatsService } from '../../services/user-stats.service';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef } from '@angular/material';
import { ProgressSpinnerDialogComponent } from '../progress-spinner-dialog/progress-spinner-dialog.component';

@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css']
})
export class UserDataComponent implements OnInit {
  userDataInput = '';
  dialogRef: MatDialogRef<ProgressSpinnerDialogComponent>;

  constructor(public userStatsService: UserStatsService,
    private router: Router, private dialog: MatDialog) { }

  ngOnInit() {
  }

  onSubmit() {
    this.userStatsService.requestUserStats(this.userDataInput);
    this.router.navigate(['/', 'user-charts']);
  }

  getRandomData() {
    this.dialogRef = this.dialog.open(ProgressSpinnerDialogComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.userStatsService.requestRandomUsers().subscribe(value => {
      this.userDataInput = JSON.stringify(value);
      this.dialogRef.close();
    });
  }

  handleFileInput(files: FileList) {
    this.dialogRef = this.dialog.open(ProgressSpinnerDialogComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    const reader = new FileReader();
    const that = this;
    reader.onload = () => {
      that.userDataInput = reader.result.toString();
      that.dialogRef.close();
    };
    reader.readAsText(files.item(0));
  }

}
