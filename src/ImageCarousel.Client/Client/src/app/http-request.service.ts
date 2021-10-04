import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HttpRequestService {
  imagesPath = 'api/images';
  constructor(private http: HttpClient) {}

  getImages(): Observable<any> {
    return this.http.get<Blob[]>(this.imagesPath, { responseType: 'json' });
  }
}
