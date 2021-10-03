import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { BookingComponent } from './booking/booking.component';
import { TourpackageComponent } from './tourpackage/tourpackage.component';
import { HotelComponent } from './hotel/hotel.component';
import { MoreComponent } from './more/more.component';
import { ContactComponent } from './contact/contact.component';
import { ContactAddComponent } from './contact-add/contact-add.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'aboutUs', component: AboutUsComponent },
  { path: 'booking', component: BookingComponent },
  { path: 'tourpackage', component: TourpackageComponent },
  { path: 'hotel', component: HotelComponent },
  { path: 'more', component: MoreComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'contact-add', component: ContactAddComponent },
  { path: '**', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
