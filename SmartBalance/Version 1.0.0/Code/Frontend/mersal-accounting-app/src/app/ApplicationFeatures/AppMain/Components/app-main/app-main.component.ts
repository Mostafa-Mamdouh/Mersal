import { SidebarStatus } from './../../Services/sidebar.servic';
import { Component, OnInit, Inject, SimpleChanges } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import {LanguageService} from '../../../../SharedFeatures/SharedMain/Services/language.service';
import {
  NavigationStart,
  NavigationEnd,
  NavigationError,
  NavigationCancel,
  NavigationExtras,
  RouteConfigLoadStart,
  RouteConfigLoadEnd,
  Router
} from '@angular/router';

import { AuthGuard } from '../../../../BusinessFeatures/User/Services/auth-guard.service';
import { CurrentUserService } from '../../../../BusinessFeatures/User/Services/current-user.service';

@Component({
  selector: 'app-main',
  templateUrl: './app-main.component.html',
  styleUrls: ['./app-main.component.css'],
  providers:[SidebarStatus]
})
export class AppMainComponent implements OnInit {

  constructor(
    private authGuard: AuthGuard,
    public currentUserService: CurrentUserService,
    private languageService: LanguageService,
    private translateService: TranslateService,
    private sidebarStatus: SidebarStatus,
    private router: Router
  ) {
    this.sideStatus=true;
   }

  sidebarsStatusChange(event){
   // debugger
    this.sideStatus=event;
  }
  ngOnInit(): void {
    this.setLangChangeSubscriber();
    // this language will be used as 
    // a fallback when a translation 
    // isn't found in the current language
    this.translateService.setDefaultLang(this.languageService.getDefaultLang());
    // the lang to use, if the lang 
    // isn't available, it will use 
    // the current loader to get them
    
    // if(this.translateService.langs.find(currentLang) !== null)
    //debugger;
    let lang = this.languageService.getSavedLang();
    this.languageService.useLang(lang);

    this.subscribeOnRouterEvents();

    this.checkCurrentUser();
  }

  checkCurrentUser() {
    this.isAuth = this.currentUserService.isLoggedIn();
    return this.isAuth;
  }

  setLangChangeSubscriber() {
    this.translateService.onLangChange.subscribe(lang => {
      
    });
  }

  // changeLanguage(lang: any) {
  //   this.translateService.use(lang);
  // }

  subscribeOnRouterEvents() {
    this.router.events.subscribe(evnt => {
      if (evnt instanceof NavigationStart) {
        let navStart: NavigationStart = <NavigationStart>evnt;
        this._isNavigating = true;
      }

      if (evnt instanceof NavigationCancel) {
        let navCancel: NavigationCancel = <NavigationCancel>evnt;
        this._isNavigating = false;
      }

      if (evnt instanceof NavigationError) {
        let navError: NavigationError = <NavigationError>evnt;
        this._isNavigating = false;

        let url = [`/error/not-found`];
        this.router.navigate(url);
      }

      if (evnt instanceof NavigationEnd) {
        let navEnd: NavigationEnd = <NavigationEnd>evnt;
        this._isNavigating = false;
      }
    });
  }

  _isNavigating: boolean;
  isAuth:boolean = false;
  sideStatus:boolean = false;
  title = 'mersal-accounting-app';
}
