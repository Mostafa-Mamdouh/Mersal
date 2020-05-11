// // //bank.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import {CurrentUserService} from '../../User/Services/current-user.service';
import { Testament } from '../Models/testament.model';
// import {PostSearch} from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class TestamentService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Testaments`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getTestamentsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getTestamentByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllTestaments(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getTestament(id: any): Observable<Testament> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Testament>(url);
  }
  addTestament(item: Testament): Observable<Testament> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateTestament(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteTestament(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
  getAdvancesTypesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.backendServerUrl.baseApiUrl}/AdvancesTypes/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }

  getTestamentExtractionsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.backendServerUrl.baseApiUrl}/TestamentExtractions/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }

  getCodes(advancesTypeId): Observable<string[]> {
    let url: string = `${this.controller}/get-codes/${advancesTypeId}`;
    return this.getAllData<string[]>(url);
  }

  generateNewCode(): Observable<string>{
    let url: string = `${this.controller}/generate-new-code`;
    return this.getAllData<string>(url);
  }

  addLiquidations(item: any[]): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Liquidations/add-collection`;
    return this.postData(url, item);
  }

  addLiquidation(item: any): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Liquidations/add`;
    return this.postData(url, item);
  }

  getUnliquidation(costCenterId: any, liquidationType: any, state: any): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Liquidations/get-unliquidation/${costCenterId}/${liquidationType}/${state}`;
    return this.getAllData(url);
  }

  generateNewDocumentCode(lastCode: string): Observable<string>{
    debugger;
    let url: string = `${this.backendServerUrl.baseApiUrl}Liquidations/generate-new-code/${lastCode}`;
    return this.getAllData<string>(url);
  }
}
