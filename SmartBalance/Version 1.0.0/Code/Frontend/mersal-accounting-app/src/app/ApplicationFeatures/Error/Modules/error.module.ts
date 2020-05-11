import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { ErrorRoutingModule } from '../Routers/error.router.module';
import { ErrorComponent } from '../Components/error/error.component';
import { PageNotFoundComponent } from '../Components/page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    ErrorComponent,
    PageNotFoundComponent
  ],
  imports: [
    CommonModule,
    SharedMainModule,
    ErrorRoutingModule
  ],
  providers: []
})
export class ErrorModule { }
