import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game } from '../models/game.interface';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class GameService {
    private apiUrl = `${environment.apiUrl}/juegos`;

    constructor(private http: HttpClient) { }

    getAllGames(): Observable<Game[]> {
        return this.http.get<Game[]>(this.apiUrl);
    }

    getFeaturedGames(): Observable<Game[]> {
        return this.http.get<Game[]>(`${this.apiUrl}/destacados`);
    }

    getGameById(id: string): Observable<Game> {
        return this.http.get<Game>(`${this.apiUrl}/${id}`);
    }

    getGameConfig(id: string): Observable<any> {
        return this.http.get<any>(`${this.apiUrl}/${id}/config`);
    }
}
