import { Component, OnInit, Inject, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/platform-browser';
import { AuthGuard } from '../../../../BusinessFeatures/User/Services/auth-guard.service';
import { CurrentUserService } from '../../../../BusinessFeatures/User/Services/current-user.service';
import { UserLoggedIn } from '../../../../BusinessFeatures/User/Models/user-login.model';
import { LanguageService } from '../../../SharedMain/Services/language.service';
import { SidebarStatus } from '../../../../ApplicationFeatures/AppMain/Services/sidebar.servic';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss'],
    providers:[SidebarStatus]
})
export class HeaderComponent implements OnInit {  

    constructor(
        private translateService: TranslateService,
        private router: Router,
        @Inject(DOCUMENT) private document: any,
        private userAuth: AuthGuard,
        private currentUserService: CurrentUserService,
        private languageService: LanguageService,
        private sidebarStatus: SidebarStatus
    ) {

     }

    ngOnInit(): void {
        this.currentUser = this.currentUserService.getCurrentUser();
    }
    

    showLangDropdown() {
        this.langDropdownShow = true;
    }

    hideLangDropdown() {
        this.langDropdownShow = false;
    }

    showUserDropdown() {
        this.userDropdownShow = true;
    }

    hideUserDropdown() {
        this.userDropdownShow = false;
    }

    changeLanguage(lang: any) {       
        this.languageService.changeLanguage(lang);        
        this.hideLangDropdown();
        document.location.reload();
    }

    userLogout() {
        this.hideUserDropdown();
        this.currentUserService.logOut();
    }
    hideSidebar(){
       //debugger;
        this.sideStatus =!this.sideStatus;
        this.firehideSidebar();
    }
    
    firehideSidebar(): void {
       // debugger;
        this.sidebarsStatus.emit(this.sideStatus);
    }


    langDropdownShow = false;
    userDropdownShow = false;
    sideStatus= true;
    @Output() sidebarsStatus: EventEmitter<boolean> = new EventEmitter();
    currentUser: UserLoggedIn;
}
