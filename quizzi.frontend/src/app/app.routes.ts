import { Routes } from '@angular/router';
import { Home } from './home/home';
import { Questions } from './questions/questions';
import { Complete } from './complete/complete';

export const routes: Routes = [
     { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: Home },
    { path: "quiz", component: Questions, },
     { path: "quiz/complete", component: Complete, },
];
