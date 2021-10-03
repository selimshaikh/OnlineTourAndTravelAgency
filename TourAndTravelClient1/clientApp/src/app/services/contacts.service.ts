import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor(private http: HttpClient) { }
  get(): Observable<Contact[]> {
    return this.http.get<Contact[]>("http://localhost:50212/api/contract");
  }
  post(data: Contact): Observable<Contact> {
    return this.http.post<Contact>("http://localhost:50212/api/contract", data);
  }
}
