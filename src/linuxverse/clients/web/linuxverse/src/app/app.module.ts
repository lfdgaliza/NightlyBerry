import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrbiterComponent } from './components/orbiter/orbiter.component';
import { UniverseComponent } from './components/universe/universe.component';

@NgModule({
  declarations: [AppComponent, OrbiterComponent, UniverseComponent],
  imports: [BrowserModule, AppRoutingModule, BrowserAnimationsModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
