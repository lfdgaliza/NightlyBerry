import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrbComponent } from './components/orb/orb.component';
import { UniverseComponent } from './components/universe/universe.component';

@NgModule({
  declarations: [
    AppComponent,
    OrbComponent,
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
