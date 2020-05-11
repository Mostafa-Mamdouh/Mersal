import { TranslateService } from '@ngx-translate/core';
import { Router, NavigationEnd } from '@angular/router';
import { Component, OnInit } from '@angular/core';


@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
    public pushRightClass: string;

    constructor(private translate: TranslateService, public router: Router) {
       // const dom: any = document.querySelector('body');
       // dom.classList.value = 'rtl';
        // this.translate.setDefaultLang('ar');
        // this.translate.use('ar');
       /// const browserLang = this.translate.getBrowserLang();
       /// this.translate.use(browserLang.match(/en|ar/) ? browserLang : 'ar');
        // this.translate.use('ar');
        this.router.events.subscribe(val => {
            if (
                val instanceof NavigationEnd &&
                window.innerWidth <= 992 &&
                this.isToggled()
            ) {
                this.toggleSidebar();
            }
        });
    }

    ngOnInit() {
        this.changeLang('ar');
        const dom: any = document.querySelector('body');
        if (this.translate.getBrowserLang() === 'ar') {
            dom.classList.value = 'rtl';
        } else {
            dom.classList.value = 'ltr';
        }
        this.translate.use('ar');

        dom.classList.value = 'rtl';
        this.pushRightClass = 'push-right';
    }

    isToggled(): boolean {
        const dom: Element = document.querySelector('body');
        return dom.classList.contains(this.pushRightClass);
    }

    toggleSidebar() {
        const dom: any = document.querySelector('body');
        dom.classList.toggle(this.pushRightClass);
    }

    rltAndLtr() {
        // debugger;
        const dom: any = document.querySelector('body');
        dom.classList.value = 'rtl';
    }

    onLoggedout() {
        localStorage.removeItem('isLoggedin');
    }

    changeLang(language: string) {
        // this.rltAndLtr();
        if (language === 'ar') {
            const dom: any = document.querySelector('body');
            dom.classList.value = 'rtl';
        } else {
            const dom: any = document.querySelector('body');
            dom.classList.value = 'ltr';
        }
        this.translate.use(language);
    }
}
