import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { PermissionEnum } from '../../User/Models/permission-enum';
//import {PostJournalComponent} from '../Components/post-journal/post-journal.component';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/journal/list'
  },
  {
    path: 'list', 
    data: { permissionCodes: [+PermissionEnum.journalEntriesList] },
    canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'preview-list', 
    data: { permissionCodes: [
      +PermissionEnum.approveOrRejectJournalEntriesUnderReview,
      +PermissionEnum.journalEntriesUnderReviewList
    ] },
    canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'preview-list/:postReceiptsMovement/:postPaymentMovement/:postBankMovement/:postPurchaseInvoice/:postPurchaseRebate/:postStoreMovement/:postSalesInvoice/:postSalesRebate', 
    data: { permissionCodes: [
      +PermissionEnum.approveOrRejectJournalEntriesUnderReview,
      +PermissionEnum.journalEntriesUnderReviewList
    ] },
    canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'add', 
    data: { permissionCodes: [+PermissionEnum.addJournalEntries] },
    canActivate: [AuthGuard],
    component: EditorComponent
  },
  {
    path: 'edit/:editId', 
    data: { 
      permissionCodes: [
        +PermissionEnum.reverseJournalEntries, 
        +PermissionEnum.journalEntriesList
      ] 
    },
    canActivate: [AuthGuard], 
    component: EditorComponent
  },
  {
    path: 'detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.journalEntriesList] },
    canActivate: [AuthGuard], 
    component: EditorComponent
  },
  //{ path: 'post-journal', canActivate: [AuthGuard], component: PostJournalComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JournalEntriesRoutingModule { }
