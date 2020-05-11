import { Component, OnInit, ViewChild } from '@angular/core';
//import {ToastrService, ToastContainerDirective} from 'ngx-toastr';
import {NotificationService} from '../../../../SharedFeatures/SharedMain/Services/notification.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  //@ViewChild(ToastContainerDirective) toastContainer: ToastContainerDirective;
  
  constructor(
    private notification: NotificationService
    //private toastrService: ToastrService
  ) { }

  ngOnInit() {
    //this.toastrService.overlayContainer = this.toastContainer;
  }

  showAnimations(): void {
    this.notification.showSuccess("hello world","success");
    this.notification.showSuccessHtml("<h2>hello world</h2><h4>hello world</h4>","success");

    this.notification.showInfo("hello world","info");
    this.notification.showInfoHtml("<h2>hello world</h2><h4>hello world</h4>","info");
  }

  title = 'mersal-accounting-app';
}
