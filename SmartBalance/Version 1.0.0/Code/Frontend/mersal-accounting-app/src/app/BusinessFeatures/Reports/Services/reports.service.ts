import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
//import { PostJournal } from '../Models/post-journal.model';

@Injectable({
    providedIn: 'root'
})
export class ReportsService extends BaseService {

    private controller: string = `${this.backendServerUrl.baseApiUrl}Journals`;
    private journalPostingsController: string = `${this.backendServerUrl.baseApiUrl}JournalPostings`;

    constructor(
        private http: HttpClient,
        private currentUserService: CurrentUserService,
        private translateService: TranslateService
    ) {
        super(http, currentUserService, translateService);
    }
  

    getAll(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
        let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
        return this.getAllData<GenericResult<any>>(url);
    }
    getJournalEntriesByPost(postSearch: any): Observable<any> {
        let url: string = `${this.controller}/get-with-filter`;
        return this.postData(url, postSearch);
    }
    get(id: any): Observable<any> {
        let url: string = `${this.controller}/getJournalsDetails/${id}`;
        return this.getData(url);
    }
    add(item: any): Observable<any> {
        let url: string = `${this.controller}/add-Journal`;
        return this.postData(url, item);
    }
    update(item: any): Observable<any> {
        let url: string = `${this.controller}/update`;
        return this.postData(url, item);
    }
    delete(id: any): Observable<any> {
        let url: string = `${this.controller}/delete/${id}`;
        return this.deleteData(url);
    }
}