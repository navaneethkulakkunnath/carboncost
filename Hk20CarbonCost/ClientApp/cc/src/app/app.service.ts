import { Injectable } from '@angular/core';
import { HttpApiService } from './http-api.service';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams,HttpHandler } from '@angular/common/http';
export function extract(s: string) {
  return s;
}

interface SharedObject {
  [id: string]: any;
}

@Injectable()
export class AppState {
  shared: SharedObject = {};
  baseUrl = '/SampleApp';

  get state() {
    return this.shared = this._clone(this.shared);
  }
  public url: string;
  constructor(private http: HttpClient) { 
    this.url = this.baseUrl+'/weatherforecast/AccountList';
  }
  fromAccountList() {
    const url = this.baseUrl+'/weatherforecast/FromAccountList';
    return this.http.get(url);
  }
  toAccountList() {
    const url = this.baseUrl+'/weatherforecast/ToAccountList';
    return this.http.get(url);
  }
  emissionCategory() {
    const url = this.baseUrl+'/weatherforecast/EmissionCategory';
    return this.http.get(url);
  }
  calculate(amount, category) {
    const url = this.baseUrl+'/weatherforecast/Calculate?amount=' + amount + '&category='+category;
    return this.http.get(url);
  }
  set state(value) {
    throw new Error('do not mutate the `.state` directly');
  }

  get(prop?: any) {
    const state = this.state;
    return state.hasOwnProperty(prop) ? state[prop] : state;
  }

  set(prop: string, value: any) {
    return this.shared[prop] = value;
  }

  private _clone(object: SharedObject) {
    return JSON.parse(JSON.stringify( object ));
  }
}
