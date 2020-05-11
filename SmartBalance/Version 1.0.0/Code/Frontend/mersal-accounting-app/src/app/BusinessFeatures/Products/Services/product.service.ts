import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import {GenericResult} from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { ProductLookup } from '../Models/product-lookup.model.';
import { UnitLookup } from '../Models/unit-lookup.model';
import {CurrentUserService} from '../../User/Services/current-user.service';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: "root"
})
export class AddProductService extends BaseService {
  private controller: string = `${this.backendServerUrl.baseApiUrl}Products`;

  constructor(
    private http: HttpClient,
    private currentUserService: CurrentUserService,
    private translateService: TranslateService
    ) {
    super(http, currentUserService, translateService);
  }
  getProductLookup(): Observable<ProductLookup[]> {
    let url: string = `${this.controller}/get-lookup`;
    return this.getData(url);
  }
  getUnitLookup(): Observable<UnitLookup[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}MeasurementUnits/get-lookup`;
    return this.getData(url);
  }
  
  getAll(pageIndex: number = null,pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  get(id: any): Observable<any> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData(url);
  }
  add(item: any): Observable<any> {
    let url: string = `${this.controller}/add`;
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
