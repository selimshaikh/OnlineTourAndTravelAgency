import { Component, OnInit } from '@angular/core';
import { ContactsService } from '../services/contacts.service';
import { NgForm } from '@angular/forms';
import { Contact } from '../models/contact';
import { ToastService } from '../services/toast.service';

@Component({
  selector: 'app-contact-add',
  templateUrl: './contact-add.component.html',
  styleUrls: ['./contact-add.component.css']
})
export class ContactAddComponent implements OnInit {
  contact: Contact;
  constructor(private service: ContactsService, private toast: ToastService) { }
  onSubmitForm(f: NgForm) {
    console.log(this.contact);
    this.service.post(this.contact).subscribe(x => {
      this.contact = new Contact();
      this.toast.message("Your Information successfully Added", ['DISMISS']);
      f.reset();
    })
  }

  ngOnInit(): void {
    this.contact = new Contact();
  }

}
