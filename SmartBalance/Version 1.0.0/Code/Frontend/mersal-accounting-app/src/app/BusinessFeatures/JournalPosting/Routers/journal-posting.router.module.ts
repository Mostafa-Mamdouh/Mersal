import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { PostJournalComponent } from '../Components/post-journal/post-journal.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/journal-posting/post-journal'
  },
  // {
  //   path: 'list', 
  //   data: { permissionCodes: [+PermissionEnum.userList] },
  //   canActivate: [AuthGuard], component: ListComponent
  // },
  // {
  //   path: 'list/:pageIndex', canActivate: [AuthGuard], component: ListComponent
  // },
  {
    path: 'post-journal', 
    data: { permissionCodes: [+PermissionEnum.postJournalEntries] },
    canActivate: [AuthGuard],
    component: PostJournalComponent
  },
  // {
  //   path: 'detail/:detailId', canActivate: [AuthGuard], component: EditorComponent
  // },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JournalPostingRouterModule { }
