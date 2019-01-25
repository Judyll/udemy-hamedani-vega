// Node modules
import { Routes } from '@angular/router';

// Local components
import { HomeComponent } from './home/home.component';
import { VehicleDetailsComponent } from './vehicle/vehicle-details/vehicle-details.component';

export const appRoutes: Routes = [
 // When the user is adding a url, or clicks on a link, or adding some path to the
  // url, then the router will attempt to match one of these routes and it keeps going
  // down to this list attempting to match to the url.  If nothing matches this path,
  // then it gonna use the wild card and it's gonna redirect to home.  So, the ordering
  // of these routes is important.

  // Instead of using 'home', we will just use '' so that when a user paste the url
  // localhost:4200, then the user will be redirected to the home component
  { path: '', component: HomeComponent},
  { path: 'vehicles/new', component: VehicleDetailsComponent},
  // redirect to the full path of the home URL
  { path: '**', redirectTo: '', pathMatch: 'full'}
];
