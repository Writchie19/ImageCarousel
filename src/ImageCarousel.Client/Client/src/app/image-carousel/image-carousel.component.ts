import { Component, OnInit } from '@angular/core';
import { HttpRequestService } from '../http-request.service';

@Component({
  selector: 'app-image-carousel',
  templateUrl: './image-carousel.component.html',
  styleUrls: ['./image-carousel.component.scss']
})
export class ImageCarouselComponent implements OnInit {
  currentImage: Blob = new Blob();
  images: Blob[] = [];
  constructor(private httpService: HttpRequestService) { }

  ngOnInit(): void {
    this.httpService.getImages().subscribe(
      (images) => {
        if (images) {
          this.images = images;
        }
      }
    )
    this.currentImage
  }

}
