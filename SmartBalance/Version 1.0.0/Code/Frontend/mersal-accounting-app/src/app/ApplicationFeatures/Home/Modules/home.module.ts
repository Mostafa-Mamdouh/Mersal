import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { ChartModule } from '@progress/kendo-angular-charts';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { HomeRoutingModule } from '../Routers/home.router.module';
import { HomeComponent } from '../Components/home/home.component';
import { DashboardComponent } from '../Components/dashboard/dashboard.component';
import { SharedTemplateModule } from 'src/app/SharedFeatures/shared-template/module/shared-template.module';
import { DashboardService } from '../Services/dashboard.service';
import { RTL, MessageService } from '@progress/kendo-angular-l10n';

@NgModule({
  declarations: [
    HomeComponent,
    DashboardComponent
  ],
  imports: [
    CommonModule,
    SharedMainModule,
    HomeRoutingModule,
    SharedTemplateModule,
    ChartModule
  ],
  providers: [DashboardService,{ provide: RTL, useValue: false },MessageService ]
})
export class HomeModule { }
