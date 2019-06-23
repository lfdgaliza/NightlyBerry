import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DistroDetailComponent } from './components/distro-detail/distro-detail.component';
import { DistroSearchComponent } from './components/distro/distro-search.component';
import { WidgetsModule } from './widgets/widgets.module';
import { ResourcePipe } from './pipes/resource.pipe';

@NgModule({
  declarations: [
    AppComponent,
    DistroSearchComponent,
    DistroDetailComponent,
    ResourcePipe
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    WidgetsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatAutocompleteModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
