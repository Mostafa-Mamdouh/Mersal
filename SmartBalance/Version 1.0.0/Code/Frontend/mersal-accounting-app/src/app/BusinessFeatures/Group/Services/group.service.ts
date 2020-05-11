import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { Group, GroupPermissionList } from '../Models/group.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class GroupService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Groups`;


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getGroupsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }


   getGroupsByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllGroups(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getGroup(id: any): Observable<Group> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Group>(url);
  }
  addGroup(item: Group): Observable<Group> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateGroup(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteGroup(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }

  getAllUnSelectedGroupsForUser(userId: number): Observable<any> {
    let url: string = `${this.controller}/get-all-un-selected-groups-for-user/${userId}`;
    return this.getAllData<GenericResult<any>>(url);
  }




  getGroupPermissions(groupId: number): Observable<GroupPermissionList> {
    let url: string = `${this.controller}/get-group-permissions/${groupId}`;
    return this.getData(url);
  }
  updateGroupPermissions(item: GroupPermissionList): Observable<GroupPermissionList> {
    let url: string = `${this.controller}/update-group-permissions`;
    return this.postData(url, item);
  }
}
