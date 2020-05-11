import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { CurrencyExchangeListComponent } from '../Components/currency-exchange-list/currency-exchange-list.component';
import { CurrencyExchangeEditorComponent } from '../Components/currency-exchange-editor/currency-exchange-editor.component';
import { CurrencyListComponent } from '../Components/currency-list/currency-list.component';
import { CurrencyEditorComponent } from '../Components/currency-editor/currency-editor.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
    {
        path: '', pathMatch: 'full', redirectTo: '/currency/exchange/list'
    },
    {
        path: 'exchange/list', 
        data: { permissionCodes: [+PermissionEnum.currencyExchangeList] },
        canActivate: [AuthGuard], 
        component: CurrencyExchangeListComponent
    },
    {
        path: 'exchange/list/:pageIndex', 
        data: { permissionCodes: [+PermissionEnum.currencyExchangeList] },
        canActivate: [AuthGuard], 
        component: CurrencyExchangeListComponent
    },
    {
        path: 'exchange/add', 
        data: { permissionCodes: [+PermissionEnum.addCurrencyExchange] },
        canActivate: [AuthGuard], 
        component: CurrencyExchangeEditorComponent
    },
    // {
    //     path: 'exchange/edit/:editId', 
    //     data: { permissionCodes: [+PermissionEnum.editCurrencyExchange] },
    //     canActivate: [AuthGuard], 
    //     component: CurrencyExchangeEditorComponent
    // },
    {
        path: 'exchange/detail/:detailId', 
        data: { permissionCodes: [+PermissionEnum.currencyExchangeList] },
        canActivate: [AuthGuard], 
        component: CurrencyExchangeEditorComponent
    },

    {
        path: 'list', 
        data: { permissionCodes: [+PermissionEnum.currencyList] },
        canActivate: [AuthGuard], 
        component: CurrencyListComponent
    },
    {
        path: 'list/:pageIndex', 
        data: { permissionCodes: [+PermissionEnum.currencyList] },
        canActivate: [AuthGuard], 
        component: CurrencyListComponent
    },
    {
        path: 'add', 
        data: { permissionCodes: [+PermissionEnum.addCurrency] },
        canActivate: [AuthGuard], component: CurrencyEditorComponent
    },
    {
        path: 'edit/:editId', 
        data: { permissionCodes: [+PermissionEnum.editCurrency] },
        canActivate: [AuthGuard], 
        component: CurrencyEditorComponent
    },
    {
        path: 'detail/:detailId', 
        data: { permissionCodes: [+PermissionEnum.currencyList] },
        canActivate: [AuthGuard], 
        component: CurrencyEditorComponent
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CurrencyRouterModule { }
