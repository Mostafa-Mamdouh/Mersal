import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { User } from '../../../BusinessFeatures/User/Models/user.model';
import { CurrentUserService } from '../../../BusinessFeatures/User/Services/current-user.service';
import { TranslateService } from '@ngx-translate/core';
import { NotificationService } from '../Services/notification.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorService extends BaseService {

 
  constructor(
    private http: HttpClient,
    private currentUserService: CurrentUserService,
    private translateService: TranslateService,
    private notificationService: NotificationService
    ) {
    super(http, currentUserService, translateService);
  }

  handerErrors(error: any) {
    if (error && error.status == 1) {
        this.notificationService.showTranslateHtmlError_h5('error.1');
      }
      else if (error && error.status == 2) {
        this.notificationService.showTranslateHtmlError_h5('error.2');
      }
      else if (error && error.status == 3) {
        this.notificationService.showTranslateHtmlError_h5('error.3');
      }
      else if (error && error.status == 4) {
        this.notificationService.showTranslateHtmlError_h5('error.4');
      }
      else if (error && error.status == 5) {
        this.notificationService.showTranslateHtmlError_h5('error.5');
      }
      else if (error && error.status == 6) {
        this.notificationService.showTranslateHtmlError_h5('error.6');
      }
      else if (error && error.status == 7) {
        this.notificationService.showTranslateHtmlError_h5('error.7');
      }
      else if (error && error.status == 8) {
        this.notificationService.showTranslateHtmlError_h5('error.8');
      }
      else if (error && error.status == 9) {
        this.notificationService.showTranslateHtmlError_h5('error.9');
      }
      else if (error && error.status == 10) {
        this.notificationService.showTranslateHtmlError_h5('error.10');
      }
      else if (error && error.status == 11) {
        this.notificationService.showTranslateHtmlError_h5('error.11');
      }
      else if (error && error.status == 12) {
        this.notificationService.showTranslateHtmlError_h5('error.12');
      }
      else if (error && error.status == 13) {
        this.notificationService.showTranslateHtmlError_h5('error.13');
      }
      else if (error && error.status == 14) {
        this.notificationService.showTranslateHtmlError_h5('error.14');
      }
      else if (error && error.status == 15) {
        this.notificationService.showTranslateHtmlError_h5('error.15');
      }
      else if (error && error.status == 16) {
        this.notificationService.showTranslateHtmlError_h5('error.16');
      }
      else if (error && error.status == 17) {
        this.notificationService.showTranslateHtmlError_h5('error.17');
      }
      else if (error && error.status == 18) {
        this.notificationService.showTranslateHtmlError_h5('error.18');
      }
      else if (error && error.status == 19) {
        this.notificationService.showTranslateHtmlError_h5('error.19');
      }
      else if (error && error.status == 20) {
        this.notificationService.showTranslateHtmlError_h5('error.20');
      }
      else if (error && error.status == 21) {
        this.notificationService.showTranslateHtmlError_h5('error.21');
      }
      else if (error && error.status == 22) {
        this.notificationService.showTranslateHtmlError_h5('error.22');
      }
      else if (error && error.status == 23) {
        this.notificationService.showTranslateHtmlError_h5('error.23');
      }
      else if (error && error.status == 24) {
        this.notificationService.showTranslateHtmlError_h5('error.24');
      }
      else if (error && error.status == 25) {
        this.notificationService.showTranslateHtmlError_h5('error.25');
      }
      else if (error && error.status == 26){
       this.notificationService.showTranslateHtmlError_h5('error.26'); 
      }
      else if (error && error.status == 27){
        this.notificationService.showTranslateHtmlError_h5('error.27');
      }
      else if(error && error.status == 28){
        this.notificationService.showTranslateHtmlError_h5('error.28');
      }
      else if(error && error.status == 29){
        this.notificationService.showTranslateHtmlError_h5('error.29');
      }
      else if(error && error.status == 30){
        this.notificationService.showTranslateHtmlError_h5('error.30');
      }
      else if (error && error.status == 400) {
        this.notificationService.showTranslateHtmlError_h5('error.400');
      }
      else if (error && error.status == 409) {     
        this.notificationService.showTranslateHtmlError_h5('error.409');
      }
      else {
        this.notificationService.showOperationFailed();
      }
  }

}
