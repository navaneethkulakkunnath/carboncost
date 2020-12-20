import { Observable, pipe, throwError as observableThrowError } from 'rxjs';
import { Injectable, ContentChildren, Injector } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { environment } from './../environments/environment';
import { AppState } from './app.service';

@Injectable()
export class HttpApiService {
  private modalRef: any;
  @ContentChildren('NgbModal') ngbModal;
  constructor(private httpClient: HttpClient,
              private injector: Injector,
              private appState: AppState) { }

  public fetch(url): Observable<any> {
    return this.httpClient.get(url)
      .pipe(tap(
        data => data
      ));
  }

  public get(url): Observable<any> {
    const headerJson = {
      'Cache-Control': 'no-cache no-store must-revalidate',
      'Pragma': 'no-cache',
      'Expires': 'Mon, 17 Aug 1700 12:00:00 GMT'
    };
    const options = {
      headers: new HttpHeaders(headerJson)
    };
    return this.httpClient.get(url, options)
      .pipe(tap(
        data => data
      ));
  }

  public createMultiPart(urlDataAsQueryString: string, fileData: FormData ): Observable<any> {
    const header = {
      'Authorization': this.appState.shared.userKey,
      'Content-Type': 'application/json'
    };
    const options = {
      headers: new HttpHeaders(header)
    };
    return this.httpClient.post(urlDataAsQueryString, fileData, options);
  }

  public create(body: Object, url): Observable<any> {
    const bodyString = JSON.stringify(body);
    const header = {
      'Authorization': this.appState.shared.userKey,
      'Content-Type': 'application/json'
    };
    const options = {
      headers: new HttpHeaders(header)
    };
    return this.httpClient.post(url, bodyString, options)
      .pipe(tap(
        data => data
      ));
  }

  public update(body: Object, url): Observable<any> {
    const header = {
      'Authorization': this.appState.shared.userKey,
      'Content-Type': 'application/json'
    };
    const options = {
      headers: new HttpHeaders(header)
    };
    return this.httpClient.put(url, body, options)
      .pipe(tap(
        data => data
      ));
  }

  public delete(url): Observable<any> {
    const header = {
      'Authorization': this.appState.shared.userKey,
      'Content-Type': 'application/json'
    };
    const options = {
      headers: new HttpHeaders(header)
    };
    return this.httpClient.delete(url, options)
      .pipe(
        tap(
          data => data
        ));
  }

  public InAppAuth(userName, password, url): Observable<any> {
    const body = new HttpParams();
    body.set('userName', userName);
    body.set('password', password);
    const header = {
      'Authorization': this.appState.shared.userKey,
      'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
    };
    const options = {
      headers: new HttpHeaders(header),
      withCredentials: true
    };
    return this.httpClient.post(url, body.toString(), options)
      .pipe(tap(
        data => data
      ));
  }

  public InAppLogOut(url): Observable<any> {
    const header = {
      'Authorization': this.appState.shared.userKey,
      'Content-Type': 'application/json'
    };
    const options = {
      headers: new HttpHeaders(header),
      withCredentials: true
    };
    return this.httpClient.post(url, null, options)
      .pipe(tap(
        data => data
      ));
  }

}
