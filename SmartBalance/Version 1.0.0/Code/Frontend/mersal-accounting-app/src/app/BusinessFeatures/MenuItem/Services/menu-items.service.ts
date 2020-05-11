import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { MenuItems, MenuItemUsersLisrt, UserMenuItemsLisrt } from '../Models/menu-items.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class MenuItemsService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}MenuItems`;


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getMenuItemsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }


   getMenuItemsByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllMenuItems(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getMenuItems(id: any): Observable<MenuItems> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<MenuItems>(url);
  }
  addMenuItems(item: MenuItems): Observable<MenuItems> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateMenuItems(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteMenuItems(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }

  getMenuItemUsers(menuItemId: number): Observable<MenuItemUsersLisrt> {
    let url: string = `${this.controller}/get-menu-item-users/${menuItemId}`;
    return this.getData(url);
  }
  getAllUnSelectedUsersForMenuItem(menuItemId :number): Observable<any>
  {
    let url: string = `${this.controller}/get-all-un-selected-users-for-menu-item/${menuItemId}`;
    return this.getData(url);
  }
  updateMenuItemUsers(item: MenuItemUsersLisrt): Observable<MenuItemUsersLisrt> {
    let url: string = `${this.controller}/update-menu-item-users`;
    return this.postData(url, item);
  }



  getUserMenuItems(menuItemId: number): Observable<UserMenuItemsLisrt> {
    let url: string = `${this.controller}/get-user-menu-items/${menuItemId}`;
    return this.getData(url);
  }
  getAllUnSelectedMenuItemsForUser(userId :number): Observable<any>
  {
    let url: string = `${this.controller}/get-all-un-selected-menu-items-for-user/${userId}`;
    return this.getData(url);
  }
  updateUserMenuItems(item: UserMenuItemsLisrt): Observable<UserMenuItemsLisrt> {
    let url: string = `${this.controller}/update-user-menu-items`;
    return this.postData(url, item);
  }

}
