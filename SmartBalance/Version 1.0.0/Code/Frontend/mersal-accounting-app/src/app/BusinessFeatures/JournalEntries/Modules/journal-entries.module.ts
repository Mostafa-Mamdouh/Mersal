import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap';
//import { PDFExportModule } from '@progress/kendo-angular-pdf-export';
import { DropDownsModule, AutoCompleteModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { NgxPrintModule } from 'ngx-print';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { JournalEntriesRoutingModule } from '../Routers/journal-entries.router.module';

import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
//import { PostJournalComponent } from '../Components/post-journal/post-journal.component';

@NgModule({
  declarations: [
    ListComponent,
    EditorComponent,
    //PostJournalComponent
  ],
  imports: [
    CommonModule,
    SharedMainModule,
    JournalEntriesRoutingModule,
    ReactiveFormsModule,
    CommonModule,
    SharedMainModule,
    ReactiveFormsModule,
    FormsModule,
    BsDatepickerModule.forRoot(),
    //PDFExportModule,
    DropDownsModule,
    AutoCompleteModule,
    GridModule,
    ExcelModule,
    InfiniteScrollModule,
    NgxPrintModule   
  ],
  exports: [
    EditorComponent
  ],
  providers: []
})
export class JournalEntriesModule { }
