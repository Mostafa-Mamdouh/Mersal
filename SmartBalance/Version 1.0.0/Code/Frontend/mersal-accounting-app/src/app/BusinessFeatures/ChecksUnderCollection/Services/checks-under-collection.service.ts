//bank.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import {CurrentUserService} from '../../User/Services/current-user.service';
import { ChecksUnderCollection } from '../Models/checks-under-collection.model';
import {PostSearch} from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class ChecksUnderCollectionService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Donations`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }

 
  
  getChecksUnderCollectionByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-checks-under-collection-with-filter`;
    return this.postData<GenericResult<any>>(url, postSearch);
  }
  getChecksUnderCollection(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-checks-under-collection-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getCheckByBank(bankId: number): any{
    let url: string = `${this.controller}/get-checks-by-bank/${bankId}`;
    return this.getAllData(url);
  }
  // updateCheckUnderCollection(item: ChecksUnderCollection): Observable<ChecksUnderCollection> {
  //   let url: string = `${this.controller}/update-check-under-collection`;
  //   return this.postData<ChecksUnderCollection>(url, item);
  // }
  UpdateCollectionOfCheckUnderCollection(array: any[]) : Observable<any[]> {
    let url: string = `${this.controller}/update-collection-of-check-under-collection`;
    return this.postData(url, array);
  }
}
