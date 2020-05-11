// import { NgModule } from '@angular/core';
// import { ReactiveFormsModule, FormsModule } from '@angular/forms';
// import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
// import { GridModule } from '@progress/kendo-angular-grid';
// import { BsDatepickerModule } from 'ngx-bootstrap';

// import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
// import { ChecksUnderCollectionRouterModule } from '../Routers/checks-under-collection.router.module';
// import { ListComponent } from '../Components/list/list.component';

// @NgModule({
//   declarations: [
//     ListComponent,
//   ],
//   imports: [
//     SharedMainModule,
//     ChecksUnderCollectionRouterModule,
//     ReactiveFormsModule,
//     FormsModule,
//     DropDownsModule,
//     GridModule,
//     BsDatepickerModule.forRoot(),
//   ],
//   providers: []
// })
// export class ChecksUnderCollectionModule { }





import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { ChecksUnderCollectionRouterModule } from '../Routers/checks-under-collection.router.module';
import { ListComponent } from '../Components/list/list.component';



@NgModule({
  declarations: [
    ListComponent
  ],
  imports: [
    SharedMainModule,
    ChecksUnderCollectionRouterModule,
    ReactiveFormsModule,    
    SharedMainModule,
    FormsModule,
    ExcelModule,
    DropDownsModule,
    GridModule , 
    BsDatepickerModule.forRoot()      
  ],
  providers: []
})
export class ChecksUnderCollectionModule { }

