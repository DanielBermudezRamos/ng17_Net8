import { AfterViewInit, Component, ViewChild, inject } from '@angular/core';
import { IEmpleado } from '../../interfaces/empleado';
import { HttpService } from '../../services/http.service';

// Angular-Material
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

@Component({
  selector: 'app-list-empleados',
  standalone: true,
  imports: [MatTableModule, MatSortModule, MatInputModule, MatFormFieldModule, MatPaginatorModule],
  templateUrl: './list-empleados.component.html',
  styleUrl: './list-empleados.component.css'
})

export class ListEmpleadosComponent {
  empleadosList: MatTableDataSource<IEmpleado>;
  httpService = inject(HttpService);

  constructor() {
    // Create 100 users
    const users: IEmpleado[] = [];

    // Assign the data to the data source for the table to render
    this.empleadosList = new MatTableDataSource(users);
  }
  // ---------------------
  displayedColumns: string[] = ['Id', 'DNI', 'Nombre', 'Apellido', 'Direccion', 'Cargo_Id', 'SueldoHora_Default', 'Activo'];
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngAfterViewInit() {
    this.empleadosList.paginator = this.paginator;
    this.empleadosList.sort = this.sort;
  }
  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.empleadosList.filter = filterValue.trim().toLowerCase();

    if (this.empleadosList.paginator) {
      this.empleadosList.paginator.firstPage();
    }
  }
  // ---------------------

  ngOnInit() {
    this.httpService.getAllEmpleado().subscribe(result => {
      this.empleadosList = new MatTableDataSource(result);
    })
  }
} // */