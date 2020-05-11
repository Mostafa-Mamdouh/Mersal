import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-footer',
    templateUrl: './footer.component.html',
    //   styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
    constructor(
        private translateService: TranslateService,
        private router: Router
    ) { }

    ngOnInit(): void { }
}
