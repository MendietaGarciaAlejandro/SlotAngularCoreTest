export interface ConfigJuego {
    id: string; // uuid
    idJuego: string; // uuid
    filas: number;
    columnas: number;
    lineasPago: number;
    colorTema?: string;
    simbolos: string[];
    actualizadoEn: string;
}
