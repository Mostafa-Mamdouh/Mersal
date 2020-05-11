import { HttpParams, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class  ReturnPurchasesService {
  BillTypes: {
    id: string;
    name: string;
  }[];
  constructor(http: HttpClient) {}

  getAllBillTypes() {
    return (this.BillTypes = [
      { id: 'FB1', name: 'Cash' },

      { id: 'FB1', name: 'Donuts1' },

      { id: 'FB1', name: 'Donuts2' },

      { id: 'FB1', name: 'Donuts3' }
    ]);
  }
  Get(params: HttpParams) {}

  add(Product: any) {}
}
