import { Component, OnInit, ViewChild } from '@angular/core';
import { ContactsService } from '../services/contacts.service';
import { Contact } from '../models/contact';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  constructor(private service: ContactsService) { }
  contacts: Contact[];
  contactDataSource: MatTableDataSource<any>;
  displayedColumns: string[] = ["name", "email", "message"];
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  ngOnInit(): void {
    this.service.get().subscribe(x => {
      this.contacts = x;
      console.log(this.contacts);
      this.contactDataSource = new MatTableDataSource(this.contacts);
      this.contactDataSource.paginator = this.paginator;
      console.log(this.contactDataSource);
    })
  }

}
