import { Component, OnInit } from '@angular/core';
import { MatCarousel, MatCarouselComponent } from '@ngmodule/material-carousel';
import { HomeService } from '../services/home.service';
import { Packege } from '../models/packege';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public hotpac: Packege;
  constructor(private servic:HomeService) { }

  ngOnInit(): void {
    this.getHotPackage()
  }
  getHotPackage() {
    this.servic.get().subscribe(x => {
      this.hotpac = x;
      console.log(x);
      console.log(this.hotpac);
    })
  }
   // Slider Images
   slides = [
   {'image': '../assets/pic02.jpg'}, 
   {'image': '../assets/pic03.jpg'},
   {'image': '../assets/pic04.jpg'}, 
   {'image': '../assets/pic05.jpg'},
   {'image': '../assets/pic06.jpg'}, 
   {'image': '../assets/pic07.jpg'},
   {'image': '../assets/pic08.jpg'}, 
   {'image': '../assets/pic09.jpg'},
   {'image': '../assets/pic10.jpg'}
  ];

}
