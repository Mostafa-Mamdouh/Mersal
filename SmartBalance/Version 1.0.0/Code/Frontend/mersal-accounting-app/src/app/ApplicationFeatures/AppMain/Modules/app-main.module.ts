import { SharedTemplateModule } from '../../../SharedFeatures/shared-template/module/shared-template.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import {LoaderModule} from '../../Loader/Modules/loader.module';
import { AppRoutingModule } from '../Routers/app-main.router.module';
import { AppMainComponent } from '../Components/app-main/app-main.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { ChartsModule } from '@progress/kendo-angular-charts';
import 'hammerjs';
import { AddCostCenterComponent } from 'src/app/BusinessFeatures/Financial/Components/add-cost-center/add-cost-center.component';




// AoT requires an exported function for factories
// export function HttpLoaderFactory(http: HttpClient) {
//   return new TranslateHttpLoader(http);
// }
export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}


@NgModule({
  declarations: [
    AppMainComponent,
    

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      progressBar: true,
      iconClasses: {
        error: 'toast-error',
        info: 'toast-info',
        success: 'toast-success',
        warning: 'toast-warning'
      }
    }),
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (createTranslateLoader),
        //useFactory: HttpLoaderFactory,
        deps: [HttpClient]
    }
    }),
    AppRoutingModule,
    LoaderModule,
    SharedTemplateModule,
    NgbModule,
    ChartsModule
  ],
  providers: [],
  bootstrap: [AppMainComponent]
})
export class AppMainModule { }


// @NgModule({
//   imports: [
//       TranslateModule.forChild({
//           loader: {provide: TranslateLoader, useClass: CustomLoader},
//           compiler: {provide: TranslateCompiler, useClass: CustomCompiler},
//           parser: {provide: TranslateParser, useClass: CustomParser},
//           missingTranslationHandler: {provide: MissingTranslationHandler, useClass: CustomHandler},
//           isolate: true
//       })
//   ]
// })
// export class LazyLoadedModule { }
