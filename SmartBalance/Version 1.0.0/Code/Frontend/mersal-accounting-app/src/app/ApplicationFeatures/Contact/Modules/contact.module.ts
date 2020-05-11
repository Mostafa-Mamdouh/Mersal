import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { ContactRoutingModule } from '../Routers/contact.router.module';
import { ContactComponent } from '../Components/contact/contact.component';
//import { ErrorComponent } from './error/error.component';

@NgModule({
  declarations: [
    ContactComponent,
    //ErrorComponent
  ],
  imports: [
    CommonModule,
    SharedMainModule,
    ContactRoutingModule
  ],
  providers: []
})
export class ContactModule { }
