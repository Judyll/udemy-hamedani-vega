// Node modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

// Local components
import { AppComponent } from './app.component';
import { VehicleDetailsComponent } from './vehicle/vehicle-details/vehicle-details.component';

@NgModule({
  declarations: [
    AppComponent,
    VehicleDetailsComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
