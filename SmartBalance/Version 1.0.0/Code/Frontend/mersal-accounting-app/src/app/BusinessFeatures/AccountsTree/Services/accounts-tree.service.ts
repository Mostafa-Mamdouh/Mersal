import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { User } from '../../User/Models/user.model';
import { accountChartTreeList } from '../Models/AccountChartTreeList.model';
import { simpleLookupModel } from '../Models/simple-lookup.model';
import {CurrentUserService} from '../../User/Services/current-user.service';
import { TranslateService } from '@ngx-translate/core';
import { levelModel } from '../Models/level.model';
import { accountTree } from '../Models/AccountTree.model';
import { accountTypeLookup } from '../Models/account-type-lookup';

@Injectable({
  providedIn: 'root'
})
export class AccountsTreeService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}AccountCharts`;
  private Groupscontroller: string = `${this.backendServerUrl.baseApiUrl}AccountChartGroups`;
  private Typescontroller: string = `${this.backendServerUrl.baseApiUrl}AccountTypes`;
  private Categoriescontroller: string = `${this.backendServerUrl.baseApiUrl}AccountChartCategories`;
  private AccountLevelsSetting: string = `${this.backendServerUrl.baseApiUrl}AccountChartLevelSettings`;

  
  constructor(
    private http: HttpClient,
    private currentUserService: CurrentUserService,
    private translateService: TranslateService
    ) {
    super(http, currentUserService, translateService);
  }

  getAccountTree(): Observable<any> {
    let url: string = `${this.controller}/get`;
    return this.getData(url);
  }

  getAccountTreeById(id:number): Observable<any> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData(url);
  }

  GetAccountChartGroupsLookup():Observable<simpleLookupModel[]>{
    let url: string = `${this.Groupscontroller}/Get/`;
    return this.getData(url);
  }
  GetAccountChartTypesLookup():Observable<accountTypeLookup[]>{
    let url: string = `${this.Typescontroller}/Get/`;
    return this.getData(url);
  }
  GetAccountChartCategoriesLookup():Observable<simpleLookupModel[]>{
    let url: string = `${this.Categoriescontroller}/Get/`;
    return this.getData(url);
  }
 
  GetLevels():Observable<levelModel[]>{
    let url: string = `${this.AccountLevelsSetting}/get/`;
    return this.getData(url);
  }

  AddAccount(add:accountTree):Observable<any>{
    let url: string = `${this.controller}/add/`;
    return this.postData(url,add);
  }

  editAccount(model: accountTree): Observable<any> {
    let url: string = `${this.controller}/update/`;
    return this.postData(url,model);
  }

  getDetails(id:number):Observable<accountTree>{
    let url: string = `${this.controller}/GetDetails/${id}`;
    return this.getData(url);
  }

  checkCode(code:string):Observable<number>{
    let url: string = `${this.controller}/check-account-chart-code/${code}`;
    return this.getData(url);
  }

  uploadExcelFile(data): Observable<any> {
    let url: string = `${this.controller}/upload`;
    return this.postFileData(url, data);
  }

  getAllUnSelectedAccountchartsForSafe(safeId){
    let url: string = `${this.controller}/get-all-un-selected-Accountcharts-for-safe/${safeId}`;
    return this.getAllData<any>(url);
  }
}
