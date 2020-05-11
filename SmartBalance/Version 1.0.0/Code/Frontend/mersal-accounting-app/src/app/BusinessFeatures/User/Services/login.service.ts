import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Login } from '../Models/login.model';
import { UserLoggedIn } from '../Models/user-login.model';
import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import {CurrentUserService} from '../../../BusinessFeatures/User/Services/current-user.service';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
    providedIn: 'root'
})
export class LoginService extends BaseService {

    private controller: string = `${this.backendServerUrl.baseApiUrl}Users/user-login`;

    constructor(
        private http: HttpClient,
        private currentUserService: CurrentUserService,
        private translateService: TranslateService
    ) {
        super(http, currentUserService, translateService);
    }

    login(item: Login): Observable<UserLoggedIn> {
        let url: string = `${this.controller}`;

        return this.postData(url, item);

// const httpOptions = {
//     headers: new HttpHeaders({
//       'Content-Type':  'application/x-www-form-urlencoded'
//     })};
  
//   const formData = new FormData();
//   formData.append('username', item.username);
//   formData.append('password', item.password);
//   formData.append('grant_type', 'password');

// var data = "username=" + item.username + "&password=" + item.password + "&grant_type=password";

 // const params = new HttpParams({
//     fromObject: {
//       grant_type: 'password',
//       username: item.username,
//       password: item.password,
//     }
//   });

//   const httpOptions = {
//     headers: new HttpHeaders({
//       'Content-Type': 'application/x-www-form-urlencoded',
//     })
//   };

//     console.log(this.controller);   
// const body = new HttpParams()
// .set("username", item.username)
// .set("password", item.password)
//  .set("grant_type", 'password');
//  let options = {
//     headers :new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' })
// };
//         let url: string = `${this.controller}`;
//         // let body = `grant_type=password&username=${item.username}&password=${item.password}`;
//         console.log("Content Type"+options.headers.getAll('Content-Type'));   

//         return this.postData(url, data, options);
    }   
}
