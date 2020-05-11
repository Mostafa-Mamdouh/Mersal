import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { SharedMainRoutingModule } from '../Routers/shared-main.router.module';
import {LoaderModule} from '../../../ApplicationFeatures/Loader/Modules/loader.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GridModule } from '@progress/kendo-angular-grid';
import { emailComponent } from '../Components/email/email.component';
import {ListEditorComponent} from '../Components/list-editor/list-editor.component';
import {AngularSplitModule} from 'angular-split';
import { textBoxComponent } from '../Components/text-box/text-box.component';
import { chequeComponent } from '../Components/cheque/cheque.component';
import { DropDownTreeComponent } from '../Components/drop-down-tree/drop-down-tree.component';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { BsDatepickerModule } from 'ngx-bootstrap';
import { TreeViewModule } from '@progress/kendo-angular-treeview';
import { PopupModule } from '@progress/kendo-angular-popup';
import { BrowserModule } from '@angular/platform-browser';
import { EffiencyRaiseComponent } from '../Components/effiency-raise/effiency-raise.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { RTL } from '@progress/kendo-angular-l10n';

// AoT requires an exported function for factories
// export function HttpLoaderFactory(http: HttpClient) {
//   return new TranslateHttpLoader(http);
// }

// export function createTranslateLoader(http: HttpClient) {
//   return new TranslateHttpLoader(http, './assets/i18n/', '.json');
// }


@NgModule({
  declarations: [
    // emailComponent
    ListEditorComponent,
    textBoxComponent,
    chequeComponent,
    DropDownTreeComponent,
    EffiencyRaiseComponent    
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    DropDownsModule,
    GridModule,
    BsDatepickerModule.forRoot(),
    TreeViewModule,
    PopupModule,
    //BrowserModule, 
    //BrowserAnimationsModule,
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
    TranslateModule.forChild({
    //   loader: {
    //     provide: TranslateLoader,
    //     useFactory: (createTranslateLoader),
    //     //useFactory: HttpLoaderFactory,
    //     deps: [HttpClient]
    // }
    }),
    SharedMainRoutingModule,
    LoaderModule,
    AngularSplitModule.forChild(),
    Ng2SearchPipeModule
  ],
  exports: [
    CommonModule, 
    TranslateModule, 
    LoaderModule,
    ListEditorComponent,
    AngularSplitModule,
    textBoxComponent,
    chequeComponent,
    DropDownTreeComponent,
    EffiencyRaiseComponent
  ],
  providers: [
    {provide: RTL, useValue: true}
  ]
})
export class SharedMainModule { }


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
