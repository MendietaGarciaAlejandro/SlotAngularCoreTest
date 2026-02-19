import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface SaldoResponse {
    saldo: number;
}

export interface TransaccionResponse {
    id: string;
    idPerfil: string;
    idJuego?: string;
    tipo: string;
    monto: number;
    saldoDespues: number;
    creadoEn: string;
}

@Injectable({
    providedIn: 'root'
})
export class WalletService {
    private apiUrl = `${environment.apiUrl}/billetera`;

    constructor(private http: HttpClient) { }

    getSaldo(idPerfil: string): Observable<SaldoResponse> {
        return this.http.get<SaldoResponse>(`${this.apiUrl}/saldo/${idPerfil}`);
    }

    depositar(idPerfil: string, monto: number): Observable<TransaccionResponse> {
        return this.http.post<TransaccionResponse>(`${this.apiUrl}/deposito`, { idPerfil, monto });
    }
}
