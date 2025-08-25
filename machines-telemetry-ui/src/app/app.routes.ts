import { Routes } from '@angular/router';

import { HomeComponent } from './pages/home/home.component';
import { CreateMachineComponent } from './pages/create-machine/create-machine.component';

export const routes: Routes = [

     { path: '', component: HomeComponent },
     { path: 'machines/create', component: CreateMachineComponent }
];
