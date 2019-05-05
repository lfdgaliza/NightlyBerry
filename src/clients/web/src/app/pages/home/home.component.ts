import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';

export interface Distro
{
  logo: string;
  name: string;
  basedOn: string;
}
@Component({
  selector: 'dg-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent
{

  distroCtrl = new FormControl();
  filteredDistros: Observable<Distro[]>;

  distros: Distro[] = [
    {
      name: 'Ubuntu',
      basedOn: 'Debian',
      logo: 'https://upload.wikimedia.org/wikipedia/commons/3/3a/Logo-ubuntu_no%28r%29-black_orange-hex.svg'
    },
    {
      name: 'Manjaro',
      basedOn: 'Arch Linux',
      logo: 'https://upload.wikimedia.org/wikipedia/commons/a/a5/Manjaro_logo_text.png'
    },
    {
      name: 'Deepin',
      basedOn: 'Debian',
      logo: 'https://upload.wikimedia.org/wikipedia/commons/4/4f/About_logo.png'
    },
    {
      name: 'Fedora',
      basedOn: 'RedHat',
      logo: 'https://upload.wikimedia.org/wikipedia/commons/0/09/Fedora_logo_and_wordmark.svg'
    }
  ];

  constructor()
  {
    this.filteredDistros = this.distroCtrl.valueChanges
      .pipe(
        startWith(''),
        map(distro => distro ? this._filterDistros(distro) : this.distros.slice())
      );
  }

  private _filterDistros(value: string): Distro[]
  {
    const filterValue = value.toLowerCase();

    return this.distros.filter(distro => distro.name.toLowerCase().indexOf(filterValue) === 0);
  }

}
