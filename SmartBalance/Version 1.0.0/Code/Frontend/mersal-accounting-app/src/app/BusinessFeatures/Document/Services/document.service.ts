import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { Document } from '../Models/document.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class DocumentService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Documents`;


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getDocumentsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }


   getDocumentsByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllDocuments(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getDocument(id: any): Observable<Document> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Document>(url);
  }
  addDocument(item: Document): Observable<Document> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateDocument(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteDocument(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
