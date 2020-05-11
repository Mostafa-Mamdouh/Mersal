import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, from } from 'rxjs';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { BillTypes } from '../Models/bill-types-lookup.model';
import { Costumer } from '../Models/customer.model';
import { CostCenter } from '../Models/cost-center.model';
import { Delegate } from '../Models/delegate.model';
import { Inventory } from '../Models/inventory.model';
import {CurrentUserService} from '../../User/Services/current-user.service';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
    providedIn: 'root'
})
export class SalesService extends BaseService {

    // tslint:disable-next-line:no-inferrable-types
    private controller: string = `${this.backendServerUrl.baseApiUrl}users`;

    constructor(
        private http: HttpClient,
        private currentUserService: CurrentUserService,
        private translateService: TranslateService
    ) {
        super(http, currentUserService, translateService);
    }

    getBillTypesLookups(): Observable<BillTypes[]> {
        let url: string = `${this.backendServerUrl.baseApiUrl}SalesBillTypes/get-lookup`;
        return this.getData(url);
    }
    getCostumersLookups(): Observable<Costumer[]> {
        let url: string = `${this.backendServerUrl.baseApiUrl}Customers/get-lookup`;
        return this.getData(url);
    }
    getCostCentersLookups(): Observable<CostCenter[]> {
        let url: string = `${this.backendServerUrl.baseApiUrl}CostCenters/get-lookup`;
        return this.getData(url);
    }
    getDelegatesListLookups(): Observable<Delegate[]> {
        let url: string = `${this.backendServerUrl.baseApiUrl}DelegateMans/get-lookup`;
        return this.getData(url);
    }
    getInventoriesLookups(): Observable<Inventory[]> {
        let url: string = `${this.backendServerUrl.baseApiUrl}Inventorys/get-lookup`;
        return this.getData(url);
    }
    // getAll(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<User>> {
    //     let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    //     return this.getAllData<GenericResult<User>>(url);
    // }
    // get(id: any): Observable<User> {
    //     let url: string = `${this.controller}/get/${id}`;
    //     return this.getData(url);
    // }
    // add(item: any): Observable<User> {
    //     let url: string = `${this.controller}/add`;
    //     return this.postData(url, item);
    // }
    // update(item: any): Observable<User> {
    //     let url: string = `${this.controller}/update`;
    //     return this.postData(url, item);
    // }
    // delete(id: any): Observable<User> {
    //     let url: string = `${this.controller}/delete/${id}`;
    //     return this.deleteData(url);
    // }
}
