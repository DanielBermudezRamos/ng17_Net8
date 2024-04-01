export interface IEmpleado {
    id: number;
    dni: string;
    nombre: string;
    apellido: string;
    direccion: string;
    cargo_Id: number;
    sueldoHora_Default: number;
    activo: boolean;
    fechaAlta?: Date;
    fechaMod?: Date;
}
