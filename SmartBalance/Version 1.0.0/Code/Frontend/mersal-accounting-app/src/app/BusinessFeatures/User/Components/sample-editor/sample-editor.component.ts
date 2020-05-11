import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray, FormArrayName, MinLengthValidator } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { UserService } from '../../Services/user.service';
import { User } from '../../Models/user.model';

@Component({
  selector: 'sample-user-editor',
  templateUrl: './sample-editor.component.html',
  styleUrls: ['./sample-editor.component.css']
})
export class SampleEditorComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService,
    private notificationService: NotificationService,
    private translateService: TranslateService
  ) { }

  ngOnInit() {
    this.setLanguageSubscriber();
    this.buildForm();

    let editId = this.route.snapshot.params['editId'];
    let detailId = this.route.snapshot.params['detailId'];

    if (editId) {
      this.mode = 'edit';
      this.id = editId;
    }
    else if (detailId) {
      this.mode = 'detail';
      this.id = editId;
    }
    else {
      this.mode = 'add';
    }
    //debugger;
    if (this.id) {
      this.getItem();
    }
  }

  setLanguageSubscriber(): void {
    this.language = this.translateService.currentLang;
    this.translateService.onLangChange.subscribe(val => {

      this.language = val.lang;
    },
      (error) => {

      },
      () => {

      });
  }

  getItem() {
    this.userService.get(this.id)
      .subscribe(res => {
        this.item = res;
        this.fillForm();
      },
        (error) => {

        },
        () => {

        });
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      name: [null, [Validators.required, Validators.minLength(2)]],
      userName: [null, [Validators.required, Validators.minLength(2)]],
      password: [null, [Validators.required]]
    });

    this.translateService.get([
      'user.editor.name.error.required',
      'user.editor.name.error.minlength',
      'user.editor.userName.error.required',
      'user.editor.userName.error.minlength',
      'user.editor.password.error.required',
      'user.editor.password.error.minlength',
    ])
      .subscribe(val => {
        this.editorFormErrors = {
          name: {
            required: val['user.editor.name.error.required'],
            minlength: val['user.editor.name.error.minlength']
          },
          userName: {
            required: val['user.editor.userName.error.required'],
            min: val['user.editor.userName.error.minlength']
          },
          password: {
            required: val['user.editor.password.error.required'],
            minlength: val['user.editor.password.error.minlength']
          },
        };
      });

    this.editorForm.valueChanges.subscribe(x => {
      let name: FormControl = this.editorForm.controls["name"] as FormControl;
      let userName: FormControl = this.editorForm.controls["userName"] as FormControl;
      let password: FormControl = this.editorForm.controls["password"] as FormControl

      console.log(`name errors: ${JSON.stringify(name.errors)}`);
      console.log(`userName errors: ${JSON.stringify(userName.errors)}`);

    },
      (error) => {
        debugger;

      });
  }

  fillForm() {
    this.editorForm.controls['name'].setValue(this.item.name);
    this.editorForm.controls['userName'].setValue(this.item.userName);
    this.editorForm.controls['password'].setValue(this.item.password);
  }

  isControlHasError(controlName: string): boolean {
    return this.editorForm.controls[controlName].errors != null;
  }

  controlErrorMessages(controlName: string): any[] {
    let result: any[] = [];

    if (this.isControlHasError(controlName)) {
      for (const key in this.editorForm.controls[controlName].errors) {
        if (this.editorForm.controls[controlName].errors.hasOwnProperty(key)) {
          result.push(this.editorFormErrors[controlName][key]);
        }
      }
    }

    return result;
  }


  submit(): void {
    if (this.editorForm.valid) {
      this.item = this.editorForm.value;
      if (this.mode == 'add') {        
        this.userService.add(this.item)
          .subscribe(res => {
            this.notificationService.showOperationSuccessed();
            this.gotoList();
          },
            (error) => {
              this.notificationService.showOperationFailed();
            },
            () => {

            });
      }
      else if (this.mode == 'edit') {

      }
      else {
        this.gotoList()
      }
    }
  }
  gotoList() {
    let url = [`/user/list`];
    this.router.navigate(url);
  }
  password() {
    this.show = !this.show;
  }
  show: boolean;
  language: any;
  editorForm: FormGroup;
  editorFormErrors: any;
  mode: any = 'add';
  id: any;
  item: User;
}
