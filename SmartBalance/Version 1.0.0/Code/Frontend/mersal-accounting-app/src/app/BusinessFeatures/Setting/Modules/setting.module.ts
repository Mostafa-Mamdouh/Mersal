import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule } from '@progress/kendo-angular-grid';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { SettingRouterModule } from '../Routers/setting.router.module';
import { ControlPanelComponent } from '../Components/control-panel/control-panel.component';
import { FinancialEditorComponent } from '../Components/financial-editor/financial-editor.component';
import { PostingEditorComponent } from '../Components/posting-editor/posting-editor.component';
import { VatEditorComponent } from '../Components/vat-editor/vat-editor.component';
import { VendorEditorComponent } from '../Components/vendor-editor/vendor-editor.component';
import { SystemCurrencyEditorComponent } from '../Components/system-currency-editor/system-currency-editor.component';
import { GeneralSettingEditorComponent } from '../Components/general-setting-editor/general-setting-editor.component';
import { PostingSettingNotificationComponent } from '../Components/posting-setting-notification/posting-setting-notification.component';
import { AccountChartSettingeEditorComponent } from '../Components/account-chart-setting-editor/account-chart-setting-editor.component';
import { FixedAssetAccountSettingEditorComponent } from '../Components/fixed-asset-account/fixed-asset-account.component';
import { TestamentAndAdvancesEditorComponent } from '../Components/testament-and-advances-editor/testament-and-advances-editor.component';

@NgModule({
  declarations: [
    ControlPanelComponent,
    FinancialEditorComponent,
    PostingEditorComponent,
    VatEditorComponent,
    VendorEditorComponent,
    SystemCurrencyEditorComponent,
    GeneralSettingEditorComponent,
    PostingSettingNotificationComponent,
    AccountChartSettingeEditorComponent,
    FixedAssetAccountSettingEditorComponent,
    TestamentAndAdvancesEditorComponent
  ],
  exports: [
    PostingSettingNotificationComponent
  ],
  imports: [
    SharedMainModule,
    SettingRouterModule,
    ReactiveFormsModule,
    FormsModule,
    DropDownsModule,
    GridModule,
    BsDatepickerModule.forRoot()
  ],
  providers: []
})
export class SettingModule { }
