import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArticleMenuService } from '../../services/article-menu.service';

@Component({
  selector: 'nb-md-reader',
  templateUrl: './md-reader.component.html',
  styleUrls: ['./md-reader.component.scss'],
  providers: [ArticleMenuService]
})
export class MdReaderComponent implements OnInit {

  id: number;

  constructor(private route: ActivatedRoute, private aricleMenuService: ArticleMenuService) {

  }

  ngOnInit() {
    this.aricleMenuService.getCategoriesMenu().subscribe(r => {
      console.log(r);
      console.log("foi");
    });
    this.route.params.subscribe((params: { id: number }) => {
      this.id = params.id;
    });
  }

}
