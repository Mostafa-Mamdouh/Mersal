import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { Role, RolePermissionList } from '../Models/role.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class RoleService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Roles`;


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getRolesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }


   getRolesByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllRoles(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getRole(id: any): Observable<Role> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Role>(url);
  }
  addRole(item: Role): Observable<Role> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateRole(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteRole(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }

  getAllUnSelectedRolesForUser(userId: number): Observable<any> {
    let url: string = `${this.controller}/get-all-un-selected-roles-for-user/${userId}`;
    return this.getAllData<GenericResult<any>>(url);
  }




  getRolePermissions(roleId: number): Observable<RolePermissionList> {
    let url: string = `${this.controller}/get-role-permissions/${roleId}`;
    return this.getData(url);
  }
  updateRolePermissions(item: RolePermissionList): Observable<RolePermissionList> {
    let url: string = `${this.controller}/update-role-permissions`;
    return this.postData(url, item);
  }
}
