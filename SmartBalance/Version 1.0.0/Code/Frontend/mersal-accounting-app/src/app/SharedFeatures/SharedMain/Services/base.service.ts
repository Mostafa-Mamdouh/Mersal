import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap, map, catchError } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';
import { ServerUrl } from '../Models/server-url.model';
import { CurrentUserService } from '../../../BusinessFeatures/User/Services/current-user.service';
import { GlobalVariables } from '../Models/global-variables.enum';

import {AvilableServersEnum} from '../../../../environments/avilable-servers.enum';
import {avilableServers} from '../../../../environments/avilable-servers';

import { mersalEnvironmentApiUrlProd } from '../../../../environments/mersal/environment-mersal-prod-api-url';
import { mersalEnvironmentApiUrlTest } from '../../../../environments/mersal/environment-mersal-test-api-url';
import { smarttechEnvironmentApiUrlProd } from '../../../../environments/smarttech/environment-smarttech-prod-api-url';
import { smarttechEnvironmentApiUrlTest } from '../../../../environments/smarttech/environment-smarttech-test-api-url';
import { evisionEnvironmentApiUrlProd } from '../../../../environments/evision/environment-evision-prod-api-url';
import { evisionEnvironmentApiUrlTest } from '../../../../environments/evision/environment-evision-test-api-url';
import { UserLoggedIn } from '../../../BusinessFeatures/User/Models/user-login.model';

@Injectable({
    providedIn: 'root'
})
export class BaseService {
    private currentUser: string = 'currentUser';
  User: UserLoggedIn;

    protected _avilableServers: AvilableServersEnum = avilableServers;
    protected backendServerUrl: ServerUrl;
    

    protected options = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
            'language-code': 'ar'
        })
    };

    constructor(
        private _http: HttpClient,
        private _currentUserService: CurrentUserService,
        private _translateService: TranslateService
    ) {              
        this.setBackendServerUrl();
    }

    private setBackendServerUrl(): void {
        if (this._avilableServers == AvilableServersEnum.evisionEnvironmentApiUrlProd) {
            this.backendServerUrl = evisionEnvironmentApiUrlProd;
        }
        else if (this._avilableServers == AvilableServersEnum.evisionEnvironmentApiUrlTest) {
            this.backendServerUrl = evisionEnvironmentApiUrlTest;
        }
        else if (this._avilableServers == AvilableServersEnum.mersalEnvironmentApiUrlProd) {
            this.backendServerUrl = mersalEnvironmentApiUrlProd;
        }
        else if (this._avilableServers == AvilableServersEnum.mersalEnvironmentApiUrlTest) {
            this.backendServerUrl = mersalEnvironmentApiUrlTest;
        }
        else if (this._avilableServers == AvilableServersEnum.smarttechEnvironmentApiUrlProd) {
            this.backendServerUrl = smarttechEnvironmentApiUrlProd;
        }
        else if (this._avilableServers == AvilableServersEnum.smarttechEnvironmentApiUrlTest) {
            this.backendServerUrl = smarttechEnvironmentApiUrlTest;
        }
    }
    private setOptions(forFile: boolean = false) {
        //debugger;
        let contentType: string = 'application/json';
        let lang = this._translateService.currentLang;
        this.User = JSON.parse(localStorage.getItem(this.currentUser)); 
        let userId = this._currentUserService.getCurrentUserIdString();

        if(forFile) {
            if (userId) {
                this.options = {
                    headers: new HttpHeaders({
                        //'Content-Type': contentType,
                        'language-code': lang,
                        'user-id': userId,
                        'Authorization': this.User.token_type +" " +this.User.access_token
                    })
                };
            }
            else {
                this.options = {
                    headers: new HttpHeaders({
                        //'Content-Type': contentType,
                        'language-code': lang
                    })
                };
            }
        }
        else {
            if (userId) {
                this.options = {
                    headers: new HttpHeaders({
                        'Content-Type': contentType,
                        'language-code': lang,
                        'user-id': userId,
                        'Authorization': this.User.token_type +" " +this.User.access_token
                    })
                };
            }
            else {
                this.options = {
                    headers: new HttpHeaders({
                        'Content-Type': contentType,
                        'language-code': lang
                    })
                };
            }
        }      
    }

    protected getAllData<T>(url: string): Observable<T> {
        let fullUrl: string = `${url}`;
        //debugger;
        this.setOptions();
        return this._http.get(fullUrl, this.options)
            .pipe(
                tap(_ => console.log(`data fetched.`)),
                catchError(this.handleError<any>('getAll', []))
            );
    }
    protected getData<T>(url: string): Observable<T> {
        let fullUrl: string = `${url}`;
        //debugger;
        this.setOptions();

        return this._http.get(fullUrl, this.options)
            .pipe(
                tap(_ => console.log(`data fetched.`)),
                catchError(this.handleError<any>('get', []))
            );
    }
    protected postData<T>(url: string, item: any, headers?: any): Observable<T> {
        this.setOptions();
        if(headers != null) {
            this.options.headers.append(headers.name, headers.value);
        }
        //debugger;
        return this._http.post(url, item, this.options)
            .pipe(
                tap(_ => console.log(`response fetched.`)),
                catchError(this.handleError<any>('postData', []))
            );
    }
protected postFileData<T>(url: string, item: any): Observable<T> {
    this.setOptions(true);    
    //debugger;
    return this._http.post(url, item, this.options)
        .pipe(
            tap(_ => console.log(`response fetched.`)),
            catchError(this.handleError<any>('postData', []))
        );
}

    protected putData<T>(url: string, item: any): Observable<T> {
        let fullUrl: string = `${url}`;
        //debugger;
        this.setOptions();

        return this._http.put(fullUrl, item, this.options)
            .pipe(
                tap(_ => console.log(`response fetched.`)),
                catchError(this.handleError<any>('putData', []))
            );
    }
    protected deleteData<T>(url: string): Observable<T> {
        let fullUrl: string = `${url}`;
        //debugger;
        this.setOptions();

        return this._http.post(fullUrl, null, this.options)
            .pipe(
                tap(_ => console.log(`response fetched.`)),
                catchError(this.handleError<any>('deleteData', []))
            );
    }

    public getEnvironmentApiUrl(): ServerUrl {
        return this.backendServerUrl;
    }


    /*End Authentication region */
    /**
    * Handle Http operation that failed.
    * Let the app continue.
    * @param operation - name of the operation that failed
    * @param result - optional value to return as the observable result
    */
    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
            debugger;
            if (error &&
                error.status == GlobalVariables.InvalidLoginCode) {
                //debugger
                this._currentUserService.logOut();
                return of();
            }
            else if(error.status== 401)
            {
                this._currentUserService.logOut();
                console.error(JSON.stringify(error));
            }
            else {
                // TODO: send the error to remote logging infrastructure
                console.error(JSON.stringify(error)); // log to console instead

                // TODO: better job of transforming error for user consumption
                console.error(`${operation} failed: ${error.message}`);

                throw error;
                // Let the app keep running by returning an empty result.
                //return of(result as T);
            }
        };
    }

}