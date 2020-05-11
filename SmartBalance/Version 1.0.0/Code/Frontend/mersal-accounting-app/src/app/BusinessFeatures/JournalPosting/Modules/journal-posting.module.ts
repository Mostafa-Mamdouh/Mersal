import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { JournalPostingRouterModule } from '../Routers/journal-posting.router.module';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import {PostJournalComponent} from '../Components/post-journal/post-journal.component';

@NgModule({
  declarations: [
    ListComponent,
    EditorComponent,
    PostJournalComponent
  ],
  imports: [
    SharedMainModule,
    JournalPostingRouterModule,
    ReactiveFormsModule,
    FormsModule,
    DropDownsModule,
    GridModule,
    ExcelModule,
    BsDatepickerModule.forRoot()
  ],
  providers: []
})
export class JournalPostingModule { }
