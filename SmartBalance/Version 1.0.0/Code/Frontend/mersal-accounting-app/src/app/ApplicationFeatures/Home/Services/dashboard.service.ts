//bank.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../../BusinessFeatures/User/Services/current-user.service';

//import {PostSearch} from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Dashboard`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getPaymentMovementsChart(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-payment-movements-chart`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getPaymentAndReceiptChart(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-payment-receipt-chart`;
    return this.getAllData<GenericResult<any>>(url);
  }
  
}
