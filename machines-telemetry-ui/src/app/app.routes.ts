import { Routes } from '@angular/router';

import { HomeComponent } from './pages/home/home.component';
import { CreateMachineComponent } from './pages/create-machine/create-machine.component';
import { DetailsComponent } from './pages/details/details.component';

export const routes: Routes = [

     { path: '', component: HomeComponent },
     { path: 'machines/create', component: CreateMachineComponent },
     { path: 'machines/:id', component: DetailsComponent }
];
