//Donator.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { Donator } from '../Models/donator.model';
//import {PostSearch} from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class DonatorService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Donators`;
  private casesController: string = `${this.backendServerUrl.baseApiUrl}Cases`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getDonatorsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getDonatorsByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllDonators(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getDonator(id: any): Observable<Donator> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Donator>(url);
  }
  addDonator(item: Donator): Observable<Donator> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateDonator(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteDonator(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }

  getLocalCasesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.casesController}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }

  uploadDonorsExcelFile(data): Observable<any> {
    let url: string = `${this.controller}/upload`;
    return this.postFileData(url, data);

    // const formData: FormData = new FormData();
    // for(let i =0; i< files.length; i++) {
    //   formData.append('fileKey', files[i], files[i].name);
    // }
    // debugger;
    // return this.postData(url, formData, {name: "encType", value: "multipart/form-data"});
  }
}
