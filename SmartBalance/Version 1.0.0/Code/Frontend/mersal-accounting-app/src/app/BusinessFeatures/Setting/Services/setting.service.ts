import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { PostingSetting } from '../Models/posting-setting.model';
import { FinancialSetting } from '../Models/financial-setting.model';
import { VendorSetting } from '../Models/vendor-setting.model';
import { GeneralSetting } from '../Models/general-setting.model';
import { SystemCurrencySetting } from '../Models/system-currency-setting.model';
import { AccountChartSettings } from '../Models/account-chart-setting.model';
import { AccountChart, FixedAssetAccountChart } from '../Models/account-chart.model';
import { TestamentAndAdvancesSetting } from '../Models/testament-and-advances-setting.model';

@Injectable({
    providedIn: 'root'
})
export class SettingService extends BaseService {

    private controller: string = `${this.backendServerUrl.baseApiUrl}Settings`;
    private accountChartSettingsController: string = `${this.backendServerUrl.baseApiUrl}AccountChartSettings`;


    constructor(
        private http: HttpClient,
        private currentUserService: CurrentUserService,
        private translateService: TranslateService
    ) {
        super(http, currentUserService, translateService);
    }

    getVAT(): Observable<any> {
        let url: string = `${this.controller}/get-vat`;
        return this.getData<any>(url);
    }
    updateVAT(item: any): Observable<any> {
        let url: string = `${this.controller}/update-vat`;
        return this.postData<any>(url, item);
    }

    getVendorSetting(): Observable<VendorSetting> {
        let url: string = `${this.controller}/get-vendor-setting`;
        return this.getData<VendorSetting>(url);
    }
    updateVendorSetting(item: VendorSetting): Observable<VendorSetting> {
        let url: string = `${this.controller}/update-vendor-setting`;
        return this.postData<VendorSetting>(url, item);
    }

    getFinancialSetting(): Observable<FinancialSetting> {
        let url: string = `${this.controller}/get-financial-setting`;
        return this.getData<FinancialSetting>(url);
    }
    getTestamentAndAdvancesSetting(): Observable<TestamentAndAdvancesSetting> {
        let url: string = `${this.controller}/get-testament-and-advances-setting`;
        return this.getData<TestamentAndAdvancesSetting>(url);
    }
    updateFinancialSetting(item: FinancialSetting): Observable<FinancialSetting> {
        let url: string = `${this.controller}/update-financial-setting`;
        return this.postData<FinancialSetting>(url, item);
    }
    updateTestamentAndAdvancesSetting(item: TestamentAndAdvancesSetting): Observable<TestamentAndAdvancesSetting> {
        let url: string = `${this.controller}/update-testament-and-advances-setting`;
        return this.postData<TestamentAndAdvancesSetting>(url, item);
    }

    getPostingSetting(): Observable<PostingSetting> {
        let url: string = `${this.controller}/get-posting-setting`;
        return this.getData<PostingSetting>(url);
    }
    updatePostingSetting(item: PostingSetting): Observable<PostingSetting> {
        let url: string = `${this.controller}/update-posting-setting`;
        return this.postData<PostingSetting>(url, item);
    }

    getGeneralSetting(): Observable<GeneralSetting> {
        let url: string = `${this.controller}/get-general-setting`;
        return this.getData<GeneralSetting>(url);
    }
    updateGeneralSetting(item: GeneralSetting): Observable<GeneralSetting> {
        let url: string = `${this.controller}/update-general-setting`;
        return this.postData<GeneralSetting>(url, item);
    }

    getSystemCurrencySetting(): Observable<SystemCurrencySetting> {
        let url: string = `${this.controller}/get-system-currency-setting`;
        return this.getData<SystemCurrencySetting>(url);
    }
    updateSystemCurrencySetting(item: SystemCurrencySetting): Observable<SystemCurrencySetting> {
        let url: string = `${this.controller}/update-system-currency-setting`;
        return this.postData<SystemCurrencySetting>(url, item);
    }

    getAccountLevelsLookups(): Observable<GenericResult<AccountChartSettings>> {
        let url: string = `${this.accountChartSettingsController}/get-by-pagger/${null}/${null}`;
        return this.getData<GenericResult<AccountChartSettings>>(url);
    }

    getAccountChartSetting(): Observable<AccountChartSettings> {
        let url: string = `${this.accountChartSettingsController}/get`;
        return this.getData<AccountChartSettings>(url);
    }
    updateFixedAssetAccountSetting(item: AccountChart[]): Observable<AccountChart[]> {
        let url: string = `${this.controller}/update-fixed-asset-account-setting`;
        return this.postData<AccountChart[]>(url, item);
    }
    getFixedAssetAccountSetting(): Observable<FixedAssetAccountChart[]> {
        let url: string = `${this.controller}/get-fixed-asset-account-setting`;
        return this.getData(url);
    }
    getMaxLength(): number {
        return 1000000;
    }


}