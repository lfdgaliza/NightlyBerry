import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DistroDetailComponent } from './components/distro-detail/distro-detail.component';
import { DistroSearchComponent } from './components/distro/distro-search.component';

const routes: Routes = [
  { path: '', component: DistroSearchComponent },
  { path: 'distro/detail/:id', component: DistroDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
