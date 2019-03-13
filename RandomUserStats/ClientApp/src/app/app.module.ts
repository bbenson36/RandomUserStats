import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatInputModule,
  MatFormFieldModule,
  MatButtonModule,
  MatTabsModule,
  MatCardModule,
  MatToolbarModule,
  MatSidenavModule,
  MatListModule,
  MatProgressSpinnerModule,
  MatDialogModule
} from '@angular/material';

import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { UserChartsComponent } from './components/user-charts/user-charts.component';
import { UserStatsService } from './services/user-stats.service';
import { UserDataComponent } from './components/user-data/user-data.component';
import { FemaleRatioComponent } from './components/user-charts/female-ratio/female-ratio.component';
import { FirstNamesComponent } from './components/user-charts/first-names/first-names.component';
import { LastNamesComponent } from './components/user-charts/last-names/last-names.component';
import { MostPopulousStatesComponent } from './components/user-charts/most-populous-states/most-populous-states.component';
import { AgeRangesComponent } from './components/user-charts/age-ranges/age-ranges.component';
import { ProgressSpinnerDialogComponent } from './components/progress-spinner-dialog/progress-spinner-dialog.component';
import { PreferredTitlesComponent } from './components/user-charts/preferred-titles/preferred-titles.component';

const MATERIAL_MODULES: any[] = [
  MatInputModule,
  MatFormFieldModule,
  MatButtonModule,
  MatTabsModule,
  MatCardModule,
  MatToolbarModule,
  MatSidenavModule,
  MatListModule,
  MatProgressSpinnerModule,
  MatDialogModule
];


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    UserChartsComponent,
    UserDataComponent,
    FemaleRatioComponent,
    FirstNamesComponent,
    LastNamesComponent,
    MostPopulousStatesComponent,
    AgeRangesComponent,
    ProgressSpinnerDialogComponent,
    PreferredTitlesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    ChartsModule,
    FormsModule,
    ReactiveFormsModule,
    MATERIAL_MODULES,
    RouterModule.forRoot([
      { path: '', component: UserDataComponent, pathMatch: 'full' },
      { path: 'user-charts', component: UserChartsComponent }
    ])
  ],
  providers: [UserStatsService],
  entryComponents: [ProgressSpinnerDialogComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
