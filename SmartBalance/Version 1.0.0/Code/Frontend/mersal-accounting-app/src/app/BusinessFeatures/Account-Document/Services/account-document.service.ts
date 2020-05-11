import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { AccountDocument } from '../Models/account-document.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class AccountDocumentService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}AccountChartDocuments`;


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getAccountDocumentsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }


   getAccountDocumentsByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllAccountDocuments(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getAccountDocument(id: any): Observable<AccountDocument[]> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<AccountDocument[]>(url);
  }
  addAccountDocument(item: AccountDocument): Observable<AccountDocument> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }

  addAccountDocuments(item: AccountDocument[]): Observable<AccountDocument[]> {
    let url: string = `${this.controller}/add-collection`;
    return this.postData(url, item);
  }
  updateAccountDocument(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }

  updateAccountDocuments(item: any): Observable<any> {
    let url: string = `${this.controller}/update-collection`;
    return this.postData(url, item);
  }
  deleteAccountDocument(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
