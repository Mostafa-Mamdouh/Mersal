import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { BankDocument } from '../Models/bank-document.model';
//import { PostSearch } from '../../Bank-Document/Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class BankDocumentService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}BankDocuments`;


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getBankDocumentsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }


  //  getBankDocumentsByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
  //    let url: string = `${this.controller}/get-with-filter`;
  //    return this.postData<GenericResult<any>>(url, postSearch);
  //  }
  getAllBankDocuments(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getBankDocument(id: any): Observable<BankDocument[]> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<BankDocument[]>(url);
  }
  addBankDocument(item: BankDocument): Observable<BankDocument> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }

  addBankDocuments(item: BankDocument[]): Observable<BankDocument[]> {
    let url: string = `${this.controller}/add-collection`;
    return this.postData(url, item);
  }
  updateBankDocument(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteBankDocument(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
