import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import { AppState } from './app.service';
import { TestComponent } from './test/test.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    TestComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatGridListModule,
    MatCardModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    AppState
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
