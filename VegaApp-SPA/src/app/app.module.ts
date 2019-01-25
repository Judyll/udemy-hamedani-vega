// Node modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

// Local components
import { AppComponent } from './app.component';
import { VehicleDetailsComponent } from './vehicle/vehicle-details/vehicle-details.component';
import { HomeComponent } from './home/home.component';
import { appRoutes } from './routes';

@NgModule({
   declarations: [
      AppComponent,
      VehicleDetailsComponent,
      HomeComponent
   ],
   imports: [
      BrowserModule,
      // We will be importing this inside our value.component in order to get the values from our DatingApp.API
      // with the Http service that it provides like HttpClient which allows us to do an Http GET request
      // and retrieve values from the server.  The HttpClient can be injected in the ValueComponent (value.component.ts)
      // constructor like constructor(private http:HttpClient)
      HttpClientModule,
      // Add a router to our SPA which is defined in the routes.ts
      RouterModule.forRoot(appRoutes)
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
