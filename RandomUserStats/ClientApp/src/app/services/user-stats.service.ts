import { Injectable, Inject } from '@angular/core';
import { UserStats } from '../user-stats';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserStatsService {

  private fiftyRandomUsersUrl = 'https://randomuser.me/api/?results=50';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };

  private dataStore: {
    userStats: UserStats
  };

  private _userStats: BehaviorSubject<UserStats>;
  private userStatsUrl: string;
  dataRequested: Boolean;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._userStats = <BehaviorSubject<UserStats>>new BehaviorSubject(null);
    this.dataStore = { userStats: null };
    this.userStatsUrl = baseUrl + 'api/RandomUserStats/CreateRandomUserStatReport';
  }

  getUserStats(): Observable<UserStats> {
    return this._userStats.asObservable();
  }

  requestUserStats(request: string) {
    this.dataRequested = true;
    this.http.post<UserStats>(this.userStatsUrl, request, this.httpOptions)
      .subscribe(data => {
        this.dataStore.userStats = data;
        this._userStats.next(Object.assign({}, this.dataStore).userStats);
      }, error => console.log('Could not load stats'));
  }

  requestRandomUsers() {
    return this.http.get<string>(this.fiftyRandomUsersUrl);
  }
}
