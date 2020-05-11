import { MenuItemViewModel, UserLoggedIn } from './../../../../BusinessFeatures/User/Models/user-login.model';
import { Component, OnInit, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { SidebarStatus } from '../../../../ApplicationFeatures/AppMain/Services/sidebar.servic';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: [ './sidebar.component.scss'],
    providers: [SidebarStatus]
})
export class SidebarComponent implements OnInit {

    constructor(
        private translateService: TranslateService,
        private router: Router,
        private sidebarStatus: SidebarStatus
    ) { }
    language: any;
    ngOnInit(): void {
        debugger;
        const user = <UserLoggedIn>JSON.parse(localStorage.getItem('currentUser'));
        this.userRoutes = user.menuItemList;
        this.language = this.translateService.currentLang;
        
    }

    hideSidebar() {
        //  debugger;
        // this.sideStatus = !this.sideStatus;
        // this.firehideSidebar();
    }
    firehideSidebar(): void {
        // debugger;
        this.sidebarsStatus.emit(this.sideStatus);
    }

    getCurrentLang(): string {
        //debugger
        let x = this.translateService.currentLang;
        if(x.length > 2) {
            x = x.substring(0, 2);
        }
        return x;
    }

    showchild(e: MenuItemViewModel)
    {
        //debugger;
        if(e.show)
            e.show = false;
        else
            e.show = true;
    }


    searchText: any;
    userRoutes: MenuItemViewModel[] = [];
    sideStatus = false;;
    show: boolean = false;
    @Output() sidebarsStatus: EventEmitter<boolean> = new EventEmitter();
}
