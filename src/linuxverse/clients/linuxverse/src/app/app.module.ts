import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrbiterComponent } from './components/orbiter/orbiter.component';
import { UniverseComponent } from './components/universe/universe.component';

@NgModule({
  declarations: [
    AppComponent,
    OrbiterComponent,
    UniverseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
