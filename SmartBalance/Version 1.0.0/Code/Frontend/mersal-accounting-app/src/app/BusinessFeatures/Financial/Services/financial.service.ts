import { MovmentsList } from '../Models/movement-list.model';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { Receipt } from '../Models/receipts.model';
import { PostSearch } from '../Models/search.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class FinancialService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Inventorys`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
    ) {
    super(http, currentUserService, translateService);
  }

//list
getReceipt(pageIndex: number = null, pageSize: number = null,BranchID: number = null,
  dateFrom: Date = null,dateTo: Date = null,amountFrom: number = null,amountTo: number = null): Observable<GenericResult<MovmentsList>> {
  let url: string =
   `${this.backendServerUrl.baseApiUrl}Donations/get-light-by-pagger/${pageIndex}/${pageSize}/${BranchID}/${dateFrom}/${dateTo}/${amountFrom}/${amountTo}`;
  return this.getAllData<GenericResult<MovmentsList>>(url);
}
getReceiptById(id: any): Observable<Receipt> {
  let url: string = `${this.backendServerUrl.baseApiUrl}Donations/get-by-id/${id}`;
  return this.getData<Receipt>(url);
}

getPaymentMovement(pageIndex: number = null, pageSize: number = null,BranchID: number = null,
  dateFrom: Date = null,dateTo: Date = null,amountFrom: number = null,amountTo: number = null): Observable<GenericResult<MovmentsList>> {
  let url: string =
   `${this.backendServerUrl.baseApiUrl}PaymentMovments/get-light-by-pagger/${pageIndex}/${pageSize}/${BranchID}/${dateFrom}/${dateTo}/${amountFrom}/${amountTo}`;
  return this.getAllData<GenericResult<MovmentsList>>(url);
}
getPaymentDetails(id: number ): Observable<any> {
  let url: string = `${this.backendServerUrl.baseApiUrl}PaymentMovments/get/${id}`;
  return this.getAllData<any>(url);
}
getReceiptDetails(id: number ): Observable<any> {
  let url: string = `${this.backendServerUrl.baseApiUrl}Donations/get/${id}`;
  return this.getAllData<any>(url);
}
//get data by post

getReceiptByPost(postSearch: PostSearch): Observable<any> {
  let url: string = `${this.backendServerUrl.baseApiUrl}Donations/get-with-filter`;
  return this.postData(url, postSearch);
}
getPaymentMovmentsByPost(postSearch: PostSearch): Observable<any> {
  let url: string = `${this.backendServerUrl.baseApiUrl}PaymentMovments/get-with-filter`;
  return this.postData(url, postSearch);
}
//
  add(receipt: Receipt): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Donations/add`;
    return this.postData(url, receipt);
  }
  addPaymentMovments(receipt: any): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}PaymentMovments/add`;
    return this.postData(url, receipt);
  }

  update(receipt: Receipt): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Donations/update`;
    return this.postData(url, receipt);
  }
  updatePaymentMovments(receipt: any): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}PaymentMovments/update`;
    return this.postData(url, receipt);
  }

  PaymentMovmentDetails(id: number): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}PaymentMovments/get/${id}`;
    return this.getData(url);
  }

  getPaymentCodes(): Observable<string[]>{
    let url: string = `${this.backendServerUrl.baseApiUrl}PaymentMovments/get-payment-codes`;
    return this.getData(url);
  }

  getStoreLookup(): Observable<any[]> {
    let url: string = `${this.controller}/get-lookup`;
    return this.getData(url);
  }
  getBranchLookup(): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Branchs/get-lookup`;
    return this.getData(url);
  }
  getDonatorLookup(): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Donators/get-lookup`;
    return this.getData(url);
  } 
  getCasesLookup(id, name, index, size, showCasesThatMetRequiredAmount = false): Observable<any[]> {
    let url: string = `${this.backendServerUrl.mersalApiUrl}Case/GetAllCasesNeedDonation`;
    url += `?caseId=${id}&caseName=${name}&pageSize=${size}&PageIndex=${index}`;
    url += `&getAllCases=${showCasesThatMetRequiredAmount}`;
    return this.getData(url);
  }
  getVendorsLookup(): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Vendors/get-lookup`;
    return this.getData(url);
  }
  getAccountChartsLookup(): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}AccountCharts/get-lookup`;
    return this.getData(url);
  }
  


  //payment
  getSafesByBranchId(Id:number): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Safes/get-by-branch-id/${Id}`;
    return this.getData(url);
  }

  getDelegateMensLookup(): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}DelegateMans/get-by-pagger/${null}/${null}`;
    return this.getData(url);
  }

  getCurrenciesLookup(): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Currencys/get-lookup`;
    return this.getData(url);
  }

  getDonationTypesLookup(id?:number): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}DonationTypes/get-light-by-Id/${id}`;
    return this.getData(url);
  }     
  getAllDonationTypesLookup(): Observable<GenericResult<any>> {
    let url: string = `${this.backendServerUrl.baseApiUrl}DonationTypes/get-light-by-pagger/${null}/${null}`;
    return this.getData(url);
  }     

  getSafesLookup(): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Safes/get-lookup`;
    return this.getData(url);
  }
  getReceivingMethodsLookup(): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}ReceivingMethods/get-lookup`;
    return this.getData(url);
  }
  getCostCentersLookups(): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}CostCenters/get-lookup`;
    return this.getData(url);
  }

  getDonationInvoice(id): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Donations/get/invoice/${id}`;
    return this.getData(url);
  }

  generateNewReciptNumber(): Observable<string> {
    let url: string = `${this.backendServerUrl.baseApiUrl}PaymentMovments/generate-new-recipt-number`;
    return this.postData(url, null);
  }


  getDiscountPercentagesLookup(): Observable<GenericResult<any>> {
    let url: string = `${this.backendServerUrl.baseApiUrl}DiscountPercentages/get-light-by-pagger/${null}/${null}`;
    return this.getData(url);
  }     
}
