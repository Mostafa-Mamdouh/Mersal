import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { UserLoggedIn } from '../Models/user-login.model';
import { NotificationService } from '../../../SharedFeatures/SharedMain/Services/notification.service';

@Injectable({
  providedIn: 'root'
})
export class CurrentUserService {

  constructor(
    private router: Router, 
    private route: ActivatedRoute,
    private notificationService: NotificationService,
    ) { }

  isLoggedIn(): boolean {    
    let user = this.getCurrentUser();
    return (user != null);
  }

  getCurrentUser(): UserLoggedIn {
    let user = <UserLoggedIn>JSON.parse(localStorage.getItem(this.currentUser));
    return user;
  }
  getCurrentUserIdString(): string {
    let result: string; 
    let user = this.getCurrentUser();
        
    if(user) {
        result = user.id.toString();
    }
    return result;
  }

  logOut(showAuthError: boolean = false) {
    localStorage.setItem(this.currentUser, null);
    if(showAuthError) {
      this.notificationService.showAuthError();
    }
    this.router.navigate(['user/login']);
  }

  private currentUser: string = 'currentUser';
  //User: UserLoggedIn;
}
