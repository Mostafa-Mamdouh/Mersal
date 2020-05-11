import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoaderRoutingModule } from '../Routing/loader.routing.module';
import { LoaderComponent } from '../Components/loader/loader.component';


@NgModule({
  declarations: [
    LoaderComponent
  ],
  imports: [
    CommonModule,
    LoaderRoutingModule
  ],
  exports: [
    LoaderComponent
  ],
  providers: [],
  bootstrap: [LoaderComponent]
})
export class LoaderModule { }
