import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArticleService } from '../../services/article.service';

@Component({
  selector: 'nb-md-reader',
  templateUrl: './md-reader.component.html',
  styleUrls: ['./md-reader.component.scss'],
  providers: [ArticleService]
})
export class MdReaderComponent implements OnInit {

  id: number;

  constructor(private route: ActivatedRoute, private aricleService: ArticleService) {

  }

  ngOnInit() {
    this.aricleService.getCategoriesMenu().subscribe(r => {
      console.log(r);
      console.log("foi");
    });
    this.route.params.subscribe((params: { id: number }) => {
      this.id = params.id;
    });
  }

}
