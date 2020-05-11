import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { User, UserPermissionList, UserRoleList, UserGroupList } from '../Models/user.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { TranslateService } from '@ngx-translate/core';
import { PostSearch } from '../Models/search.model';
import { ChangePasswod } from '../Models/change-password.model';
import { PermissionEnum } from '../Models/permission-enum';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}users`;

  constructor(
    private http: HttpClient,
    private currentUserService: CurrentUserService,
    private translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }
  public activeTab: string;

  getMaxPaymentLimitForCurrentUser(): Observable<number> {
    let url: string = `${this.controller}/get-max-payment-limit-for-current-user`;
    return this.getData<number>(url);
  }

  getUserBranch(userId: number): Observable<any> {
    let url: string = `${this.controller}/get-user-branch/${userId}`;
    return this.getData<any>(url);
  }
  getCurrentUserBranch(): Observable<any> {
    let url: string = `${this.controller}/get-current-user-branch`;
    return this.getData<any>(url);
  }

  getUsersByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-with-filter`;
    return this.postData<GenericResult<any>>(url, postSearch);
  }

  getAll(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<User>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<User>>(url);
  }
  get(id: any): Observable<User> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData(url);
  }
  add(item: any): Observable<User> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  update(item: any): Observable<User> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  delete(id: any): Observable<User> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }

  getUserPermissions(userId: number): Observable<UserPermissionList> {
    let url: string = `${this.controller}/get-user-permissions/${userId}`;
    return this.getData(url);
  }
  updateUserPermissions(item: UserPermissionList): Observable<UserPermissionList> {
    let url: string = `${this.controller}/update-user-permissions`;
    return this.postData(url, item);
  }


  getUserRoles(userId: number): Observable<UserRoleList> {
    let url: string = `${this.controller}/get-user-roles/${userId}`;
    return this.getData(url);
  }
  updateUserRoles(item: UserRoleList): Observable<UserRoleList> {
    let url: string = `${this.controller}/update-user-roles`;
    return this.postData(url, item);
  }


  getUserGroups(userId: number): Observable<UserGroupList> {
    let url: string = `${this.controller}/get-user-groups/${userId}`;
    return this.getData(url);
  }
  updateUserGroups(item: UserGroupList): Observable<UserGroupList> {
    let url: string = `${this.controller}/update-user-Groups`;
    return this.postData(url, item);
  }
  changePassword(item: ChangePasswod): Observable<any> {
    let url: string = `${this.controller}/change-password`;
    return this.postData(url, item);
  }
  resetPassword(userId: number) {
    let url: string = `${this.controller}/reset-password/${userId}`;
    return this.postData(url, null)
  }

  isUserHassPermission(userId: any, permissionItem: PermissionEnum): Observable<boolean> {
    let url: string = `${this.controller}/is-user-has-permission/${userId}/${+permissionItem}`;
    return this.postData(url, null);
  }

  isCurrentUserHassPermission(permissionItem: PermissionEnum): Observable<boolean> {
    let url: string = `${this.controller}/is-current-user-has-permission/${+permissionItem}`;
    return this.postData(url, null);
  }

  getUserBranchs(userId: number): Observable<UserPermissionList> {
    let url: string = `${this.controller}/get-user-branchs/${userId}`;
    return this.getData(url);
  }
  updateUserBranchs(item: UserPermissionList): Observable<UserPermissionList> {
    let url: string = `${this.controller}/update-user-branchs`;
    return this.postData(url, item);
  }

  setActiveTab(tab: string) {
    this.activeTab = tab;
  }
  getActiveTab() {
    return this.activeTab;
  }

}
