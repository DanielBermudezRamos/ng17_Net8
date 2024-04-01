import { Routes } from '@angular/router';
import { ListEmpleadosComponent } from './components/list-empleados/list-empleados.component';

export const routes: Routes = [
    {path: "", component:ListEmpleadosComponent},
    {path: "employee-list", component:ListEmpleadosComponent},
    {path: "**", component:ListEmpleadosComponent}
];
