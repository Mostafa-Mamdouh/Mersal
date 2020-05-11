import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { UserService } from '../../Services/user.service';
import { User } from '../../Models/user.model';

@Component({
  selector: 'sample-user-list',
  templateUrl: './sample-list.component.html',
  styleUrls: ['./sample-list.component.css']
})
export class SampleListComponent implements OnInit {

  constructor(
    private router: Router,
    private translateService: TranslateService,
    private notificationService: NotificationService,
    private userService: UserService
  ) { }

  language: any;
  list: User[];
  itemIdToDelete: any;

  ngOnInit() {
    this.setLanguageSubscriber();
    this.getList();
  }

  setLanguageSubscriber(): void {
    this.language = this.translateService.currentLang;
    this.translateService.onLangChange.subscribe(val => {

      this.language = val.lang;
    },
      (error) => {

      },
      () => {

      });
  }

  getList() {
    this.userService.getAll()
      .subscribe(res => {
        // debugger;
        // console.log(JSON.stringify(res));

        this.list = res.collection;
      },
        (error) => {
         // debugger;
         this.notificationService.showOperationFailed();
         this.list = [];
        },
        () => {
          // debugger;

        });
  }
  setItemToDelete(id: any) {
    this.itemIdToDelete = id;
  }
  delete(): void {
    if (this.itemIdToDelete) {
      this.userService.delete(this.itemIdToDelete)
        .subscribe(res => {
          this.notificationService.showOperationSuccessed();
          this.getList();
        },
          (error) => {
            this.notificationService.showOperationFailed();
          },
          () => {

          });
    }
  }
}
