import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { UserLoggedIn } from '../Models/user-login.model';
import { CurrentUserService } from '../Services/current-user.service';
import { NotificationService } from '../../../SharedFeatures/SharedMain/Services/notification.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private currentUserService: CurrentUserService,
    private notificationService: NotificationService
  ) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> |
    Promise<boolean> | boolean {
//debugger;
      let userString = localStorage.getItem(this.currentUser);

    if (next.data.allowAll && userString != null && userString != 'null') {
      return true;
    }
    else if (next.data.allowAll && (userString == null || userString == 'null')) {
      this.currentUserService.logOut();
    }
    else {      

      if (userString != null) {
        debugger;
        this.User = JSON.parse(userString);

        if (this.User &&
          this.User.permissions &&
          next.data.permissionCodes) {

          let isGrant: boolean = false;
          next.data.permissionCodes.forEach(element => {
            let permissionItem = this.User.permissions.find(x => x == +element);
            if (permissionItem) {
              isGrant = true;
            }
          });

          if (isGrant) {
            return true;
          }
          else {
            this.currentUserService.logOut();
          }
        }
        else {
          this.currentUserService.logOut();
        }
      }
      else {
        this.currentUserService.logOut();
      }
    }
    return false;


    // let url = state.url;
    // if (url.length > 1 && url.substring(0, 1) == '/') {
    //   url = state.url.substring(1);
    // }

    // //return true;
    // let baseUrl: string[] = state.url.split("/");

    // if (localStorage.getItem(this.currentUser) != null) {
    //   debugger;
    //   this.User = JSON.parse(localStorage.getItem(this.currentUser));
    //   if (this.User &&
    //     this.User.menuItemList &&
    //     //this.User.menuItemList.find(x => x.url == url)) {
    //     this.User.menuItemList.find(x => x.rootUrl == baseUrl[1])) {
    //     return true;
    //   }
    //   else {
    //     //this.notificationService.showAuthError();
    //     this.currentUserService.logOut();
    //     //return true;      
    //   }
    // }
    // else {
    //   //this.notificationService.showAuthError();
    //   this.currentUserService.logOut();
    //   //return true; 
    // }
  }

  // isLoggedIn(): boolean {
  //   //return true;
  //   const user =  localStorage.getItem(this.currentUser);
  //   console.log(user)
  //   this.User = JSON.parse(user);
  //   return (this.User != null);
  // }

  // gotoLogin(): void {
  //   this.router.navigate(['user/login']);
  // }

  // getCurrentUser() {
  //   return JSON.parse(localStorage.getItem(this.currentUser));
  // }

  // logOut() {
  //   localStorage.setItem(this.currentUser, null);
  //   this.router.navigate(['user/login']);
  // }

  private currentUser: string = 'currentUser';
  User: UserLoggedIn;
}
