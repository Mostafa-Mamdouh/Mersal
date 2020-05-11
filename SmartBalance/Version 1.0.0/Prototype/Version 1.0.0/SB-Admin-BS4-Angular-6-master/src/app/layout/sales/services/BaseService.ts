// import { tap, catchError } from 'rxjs/operators';
// import { Injectable } from '@angular/core';
// import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
// import { Observable, of } from 'rxjs';

// /**
//  * Created by Ahmed Shaikoun on 5/2/2018.
//  */

// @Injectable()
// export class BaseService {
//   protected _headers: any = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

//   constructor(protected http: HttpClient) {}

//   getAll<T>(url: string, params: HttpParams): Observable<T> {
//     return this.http.get<T>(url, { params: params }).pipe(
//       tap(results => console.debug(`getAll<T> fetched, result: ${JSON.stringify(results)}`))
//       // catchError(this.handleError<T>('getAll<T>', null))
//     );
//   }

//   get<T>(url: string, params: HttpParams): Observable<any> {
//     return this.http.get<T>(url, { params: params }).pipe(
//       tap(result => console.debug(`get<T> fetched: result: ${JSON.stringify(result)}`))
//       //  catchError(this.handleError<any>('get<T>', null))
//     );
//   }

//   addNew<T>(url: string, model: T): Observable<any> {
//     return this.http.post(url, model, this._headers).pipe(
//       tap(result => console.debug(`addNew<T>, result: ${result}`))
//       // catchError(this.handleError<T>('addNew<T>', null))
//     );
//   }

//   update<T>(url: string, model: T): Observable<any> {
//     return this.http.put(url, model, this._headers).pipe(
//       tap(result => console.debug(`update<T>, result: ${result}`))
//       // catchError(this.handleError<T>('update<T>', null))
//     );
//   }

//   delete(url: string): Observable<any> {
//     return this.http.delete(url, this._headers).pipe(
//       tap(result => console.debug(`delete, result: ${result}`))
//       // catchError(this.handleError<any>('delete', null))
//     );
//   }

//   /**
//    * Handle Http operation that failed.
//    * Let the app continue.
//    * @param operation - name of the operation that failed
//    * @param result - optional value to return as the observable result
//    */
//   /* protected handleError<T>(operation = 'operation', result?: ResultSet<T>) {
//     return (error: any): Observable<ResultSet<T>> => {
//       // TODO: send the error to remote logging infrastructure
//       console.error(error); // log to console instead

//       // TODO: better job of transforming error for user consumption
//       console.error(`${operation} failed: ${error.message}`);
//       result = new ResultSet<T>();
//       result.errorMessage = error.statusText;
//       delete result.data;
//       delete result.pagination;
//       // Let the app keep running by returning an empty result.
//       return of(result as ResultSet<T>);
//     };
//   } */
// }
