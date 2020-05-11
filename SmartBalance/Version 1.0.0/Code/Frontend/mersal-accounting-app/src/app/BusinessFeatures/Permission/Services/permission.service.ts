import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { Permission } from '../Models/permission.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class PermissionService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Permissions`;


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getPermissionsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getAllUnSelectedPermissions(roleId: number): Observable<any> {
    let url: string = `${this.controller}/get-all-un-selected-permissions/${roleId}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getAllUnSelectedPermissionsForUser(userId: number): Observable<any> {
    let url: string = `${this.controller}/get-all-un-selected-permissions-for-user/${userId}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getAllUnSelectedPermissionsForGroup(groupId: number): Observable<any> {
    let url: string = `${this.controller}/get-all-un-selected-permissions-for-group/${groupId}`;
    return this.getAllData<GenericResult<any>>(url);
  }

  getPermissionsByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-with-filter`;
    return this.postData<GenericResult<any>>(url, postSearch);
  }
  getAllPermissions(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getPermission(id: any): Observable<Permission> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Permission>(url);
  }
  addPermission(item: Permission): Observable<Permission> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updatePermission(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deletePermission(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
