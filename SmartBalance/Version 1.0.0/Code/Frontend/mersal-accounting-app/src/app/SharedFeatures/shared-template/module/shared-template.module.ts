import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { FooterComponent } from '../components/footer/footer.component';
import { HeaderComponent } from '../components/header/header.component';
import { SidebarComponent } from '../components/sidebar/sidebar.component';
import { AuthGuard } from 'src/app/BusinessFeatures/User/Services/auth-guard.service';

@NgModule({
    declarations: [
        FooterComponent,
        HeaderComponent,
        SidebarComponent,
    ],
    imports: [
        CommonModule,
        SharedMainModule,
        RouterModule,
        FormsModule,
        Ng2SearchPipeModule
    ],
    exports: [FooterComponent, HeaderComponent, SidebarComponent],
    providers: [AuthGuard]
})
export class SharedTemplateModule { }
