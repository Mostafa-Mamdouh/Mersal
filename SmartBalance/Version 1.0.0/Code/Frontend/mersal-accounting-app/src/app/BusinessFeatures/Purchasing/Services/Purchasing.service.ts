import { PurchaseInvoice } from './../Models/purchase-invoice.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import {CurrentUserService} from '../../User/Services/current-user.service';
import {PostSearch} from '../Models/search.model';
import { PurchaseRebate } from '../Models/purchase-rebate.model';

@Injectable({
  providedIn: 'root'
})
export class PurchasingService extends BaseService {

  private purchaseInvoicesController: string = `${this.backendServerUrl.baseApiUrl}PurchaseInvoices`;
  private purchaseRebatesController: string = `${this.backendServerUrl.baseApiUrl}PurchaseRebates`;
  //PurchaseRebates/add
  private purchaseInvoiceTypesController: string = `${this.backendServerUrl.baseApiUrl}PurchaseInvoiceTypes`;
  private safesController: string = `${this.backendServerUrl.baseApiUrl}Safes`;
  private measurementUnitsController: string = `${this.backendServerUrl.baseApiUrl}MeasurementUnits`;
  private brandController: string = `${this.backendServerUrl.baseApiUrl}Brands`;
  private ProductController: string = `${this.backendServerUrl.baseApiUrl}Products`;
  private OpeningBalanceController: string = `${this.backendServerUrl.baseApiUrl}OpeningBalance`;



  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getPurchaseInvoiceTypesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.purchaseInvoiceTypesController}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getSafesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.safesController}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }

  // lookup
  getUnits(): Observable<any[]> {
    let url: string = `${this.ProductController}/get-lookup`;
    return this.getData<any[]>(url);
  }
  getMeasurementUnitsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.measurementUnitsController}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  // getBrands(): Observable<any[]> {
  //   let url: string = `${this.purchaseInvoicesController}/get-lookup`;
  //   return this.postData<any[]>(url,null);
  // }





  getPurchaseInvoicesByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
    let url: string = `${this.purchaseInvoicesController}/get-with-filter`;
    return this.postData<GenericResult<any>>(url, postSearch);
  }
  getAllPurchaseInvoices(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<PurchaseInvoice>> {
    let url: string = `${this.purchaseInvoicesController}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getPurchaseInvoice(id: any): Observable<PurchaseInvoice> {
    let url: string = `${this.purchaseInvoicesController}/get/${id}`;
    return this.getData<PurchaseInvoice>(url);
  }
  addPurchaseInvoice(item: PurchaseInvoice): Observable<PurchaseInvoice> {
    let url: string = `${this.purchaseInvoicesController}/add`;
    return this.postData(url, item);
  }
  updatePurchaseInvoice(item: any): Observable<any> {
    let url: string = `${this.purchaseInvoicesController}/update`;
    return this.postData(url, item);
  }
  deletePurchaseInvoice(id: any): Observable<any> {
    let url: string = `${this.purchaseInvoicesController}/delete/${id}`;
    return this.deleteData(url);
  }

  //Rebates
  
  getPurchaseRebatesByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
    let url: string = `${this.purchaseRebatesController}/get-with-filter`;
    return this.postData<GenericResult<any>>(url, postSearch);
  }
  getAllPurchaseRebates(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.purchaseRebatesController}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getPurchaseRebates(id: any): Observable<PurchaseRebate> {
    let url: string = `${this.purchaseRebatesController}/get/${id}`;
    return this.getData<PurchaseRebate>(url);
  }
  getPurchaselookup(): Observable<any[]> {
    let url: string = `${this.purchaseInvoicesController}/get-lookup`;
    return this.getData<any[]>(url);
  }
  addPurchaseRebates(item: PurchaseRebate): Observable<PurchaseRebate> {
    let url: string = `${this.purchaseRebatesController}/add`;
    return this.postData(url, item);
  }
  updatePurchaseRebates(item: any): Observable<any> {
    let url: string = `${this.purchaseRebatesController}/update`;
    return this.postData(url, item);
  }
  deletePurchaseRebates(id: any): Observable<any> {
    let url: string = `${this.purchaseRebatesController}/delete/${id}`;
    return this.deleteData(url);
  }


  //brand
  getBrands(): Observable<GenericResult<any>> {
    let url: string = `${this.brandController}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }


  // Opening Balances
  getOpeningBalancesByVendorId(id: any): Observable<GenericResult<any>> {
    let url: string = `${this.OpeningBalanceController}/get-by-vendorId/${id}`;
    return this.getAllData<GenericResult<any>>(url);
  }
} 
