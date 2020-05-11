import { HttpParams, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class AddProductService {
  products: {
    id: string;
    ProductName: string;
    ProductCode: string;
    price: number;
    Quantity: number;
    Total: number;
    UnitName: string;
    UnitCode: string;
  }[];
  constructor(http: HttpClient) {
  }

  getAll() {
    return (this.products = [
      // tslint:disable-next-line:max-line-length
      { id: 'FB1', ProductName: 'Donuts0', ProductCode: 'FB1', price: 1.99, Quantity: 43, Total: 43, UnitName: 'Breads', UnitCode: 'FB1' },
      // tslint:disable-next-line:max-line-length
      { id: 'FB1', ProductName: 'Donuts1', ProductCode: 'FB1', price: 1.99, Quantity: 43, Total: 43, UnitName: 'Breads', UnitCode: 'FB1' },
      // tslint:disable-next-line:max-line-length
      { id: 'FB1', ProductName: 'Donuts2', ProductCode: 'FB1', price: 1.99, Quantity: 43, Total: 43, UnitName: 'Breads', UnitCode: 'FB1' },
      // tslint:disable-next-line:max-line-length
      { id: 'FB1', ProductName: 'Donuts3', ProductCode: 'FB1', price: 1.99, Quantity: 43, Total: 43, UnitName: 'Breads', UnitCode: 'FB1' }
    ]);
  }
  Get(params: HttpParams) {}

  add(Product: any) {}
}
