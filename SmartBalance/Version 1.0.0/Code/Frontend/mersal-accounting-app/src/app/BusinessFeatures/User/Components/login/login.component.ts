import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { UserService } from '../../Services/user.service';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { LoginService } from '../../Services/login.service';
import { UserLoggedIn } from '../../Models/user-login.model';
import { Login } from '../../Models/login.model';
//import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  language: string;
  loginForm: FormGroup;
  currentUser: UserLoggedIn = null;
  show: boolean;
  //userList: UserDTO[];
  showLoader: boolean;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private loginService: LoginService
  ) {

  }

  ngOnInit() {
    this.setLanguageSubscriber();
    //this.initializeHardCodedUserList();
    this.buildForm();
    this.show = false;
  }
  password() {
    this.show = !this.show;
  }
  setLanguageSubscriber(): void {
    this.language = this.translateService.currentLang;
    this.translateService.onLangChange.subscribe(val => {

      this.language = val.lang;
    },
      (error) => { },
      () => { });
  }

  buildForm(): void {
    this.loginForm = this.fb.group({
      username: [null, [Validators.required, Validators.minLength(2)]],
      password: [null, [Validators.required]]
    });
  }



  submit(): void {
    if (this.loginForm.valid) {
      this.showLoader = true;

      let loginModel: Login = {
        userName: this.loginForm.controls['username'].value,
        password: this.loginForm.controls['password'].value
      };

      this.loginService.login(loginModel)
        .subscribe(res => {
          //debugger;
          this.showLoader = false;
          this.currentUser = res;
          //this.notificationService.showOperationSuccessed();
          debugger;
          localStorage.setItem('currentUser', JSON.stringify(res));
          //console.info(jwt_decode(this.currentUser.access_token))
          this.router.navigate(this.defaultUrl);

        }, (error) => {
          debugger;
          console.log("FormErrors" + JSON.stringify(error));
          if (error.status == 400) {
            let key = 'error.0001';
            this.translateService.get([key])
            .subscribe(res => {
              this.notificationService.showErrorHtml(`<h5>${res[key]}</h5>`);
            });
          }
          else {
            this.notificationService.showOperationFailed();
          }
          this.showLoader = false;
          //}
        }, () => {
          debugger;
          this.showLoader = false;
        });
    } else {
      // this.gotoList();
      const loginFormFormKeys = Object.keys(this.loginForm.controls);
      loginFormFormKeys.forEach((control) => {
        this.loginForm.controls[control].markAsTouched();
      });
    }

  }

  gotoList() {
    let url = [`/user/list`];
    this.router.navigate(url);
  }

  defaultUrl: any[] = ["/home/dashboard"];
}
