export interface Game {
    id: string; // uuid in backend
    titulo: string;
    proveedor: string;
    urlMiniatura?: string;
    rtp: number;
    volatilidad?: string;
    esDestacado: boolean;
    descripcion?: string;
    creadoEn: string;
}
