import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import {CurrentUserService} from '../../User/Services/current-user.service';
import { BankMovement } from '../Models/bank-movement.model';
import {PostSearch} from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class BankingService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}BankMovements`;
  private safesController: string = `${this.backendServerUrl.baseApiUrl}Safes`;
  private journalTypesController: string = `${this.backendServerUrl.baseApiUrl}JournalTypes`;
  private settingsController: string = `${this.backendServerUrl.baseApiUrl}Settings`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }

  getJournalTypes(): Observable<GenericResult<any>> {
    let url: string = `${this.journalTypesController}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getSafesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.safesController}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }


   getBankMovementsByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllBankMovements(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getBankMovement(id: any): Observable<BankMovement> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<BankMovement>(url);
  }
  addBankMovement(item: BankMovement): Observable<BankMovement> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateBankMovement(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteBankMovement(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
  

}
