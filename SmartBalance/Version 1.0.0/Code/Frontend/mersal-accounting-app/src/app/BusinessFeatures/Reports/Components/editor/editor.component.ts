import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';


@Component({
  selector: 'user-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.css']
})
export class EditorComponent implements OnInit {

  
  constructor(
    private router: Router,
    private route: ActivatedRoute) 
  {}

  ngOnInit() {
    let editId = this.route.snapshot.params['editId'];
    let detailId = this.route.snapshot.params['detailId'];

    if (editId) {
      this.mode = 'edit';
      this.id = editId;
      this
    }
    else if (detailId) {
      this.mode = 'detail';
      this.id = detailId;
    }

    else {
      this.mode = 'add';
 
    }
    //debugger;
    if (this.id) {
 
    }

  }



  gotoList() {
    let url = [`/reports/list`];
    this.router.navigate(url);
  }

  language: any;
  editorForm: FormGroup;
  editorFormErrors: any;
  mode: any = 'add';
  id: any;
  item: any;
}
