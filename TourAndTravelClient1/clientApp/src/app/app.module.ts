import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatModuleModule } from './mat-module/mat-module.module';
import { HomeComponent } from './home/home.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { BookingComponent } from './booking/booking.component';
import { TourpackageComponent } from './tourpackage/tourpackage.component';
import { HotelComponent } from './hotel/hotel.component';
import { MoreComponent } from './more/more.component';
import { ContactComponent } from './contact/contact.component';
import { MatCarouselModule } from '@ngmodule/material-carousel';
import { FooterComponent } from './footer/footer.component';
import { ContactAddComponent } from './contact-add/contact-add.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutUsComponent,
    BookingComponent,
    TourpackageComponent,
    HotelComponent,
    MoreComponent,
    ContactComponent,
    FooterComponent,
    ContactAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatModuleModule,
    HttpClientModule,
    MatCarouselModule.forRoot(),
    FormsModule  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
