import { Injectable, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
    providedIn: 'root'
})
export class LanguageService {
    constructor(
        private translateService: TranslateService,
        @Inject(DOCUMENT) private document: any
    ) { }


    changeLanguage(lang: any) {
        //debugger;
        localStorage.setItem("lang", lang);
        this.useLang(lang);       
    }
    getDefaultLang(): string {
        let defaultLang: string = 'ar';
        return defaultLang;
    }
    getSavedLang(): string {
        let lang = localStorage.getItem("lang");

        if (!lang) {
            lang = this.getDefaultLang();
        }

        return lang;
    }
    useLang(lang: string) {
        if (lang === 'ar') {
            this.document.documentElement.dir = 'rtl';
        } else {
            this.document.documentElement.dir = 'ltr';
        }

        this.translateService.use(lang);
    }
}