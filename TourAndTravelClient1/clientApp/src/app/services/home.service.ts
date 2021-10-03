import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Packege } from '../models/packege';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }
  get(): Observable<Packege> {
    return this.http.get<Packege>("http://localhost:50212/HotPackages");
  }
}
