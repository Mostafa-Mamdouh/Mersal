import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { AboutRoutingModule } from '../Routers/about.router.module';
import { AboutComponent } from '../Components/about/about.component';

@NgModule({
  declarations: [
    AboutComponent
  ],
  imports: [
    CommonModule,
    SharedMainModule,
    AboutRoutingModule
  ],
  providers: []
})
export class AboutModule { }
