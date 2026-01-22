import { Injectable } from '@angular/core';
import { Observable, of, delay } from 'rxjs';
import { Game } from '../models/game.interface';

@Injectable({
    providedIn: 'root'
})
export class GameService {

    // Datos simulados (Mock Data) traducidos al español
    private mockGames: Game[] = [
        {
            id: '1',
            title: 'Sweet Bonanza',
            provider: 'Pragmatic Play',
            thumbnailUrl: 'https://placehold.co/300x200/FF5733/FFF?text=Sweet+Bonanza',
            rtp: 96.48,
            volatility: 'High',
            isFeatured: true,
            description: '¡Disfruta de dulces victorias en este clásico colorido!'
        },
        {
            id: '2',
            title: 'Book of Dead',
            provider: 'Play\'n GO',
            thumbnailUrl: 'https://placehold.co/300x200/C70039/FFF?text=Book+of+Dead',
            rtp: 96.21,
            volatility: 'High',
            isFeatured: true,
            description: 'Explora los misterios del antiguo Egipto con Rich Wilde.'
        },
        {
            id: '3',
            title: 'Starburst',
            provider: 'NetEnt',
            thumbnailUrl: 'https://placehold.co/300x200/900C3F/FFF?text=Starburst',
            rtp: 96.09,
            volatility: 'Low',
            isFeatured: false,
            description: 'El clásico arcade espacial con joyas deslumbrantes.'
        },
        {
            id: '4',
            title: 'Big Bass Bonanza',
            provider: 'Pragmatic Play',
            thumbnailUrl: 'https://placehold.co/300x200/581845/FFF?text=Big+Bass',
            rtp: 96.71,
            volatility: 'Medium',
            isFeatured: true,
            description: '¡Pesca los premios más grandes en este éxito de pesca!'
        },
        {
            id: '5',
            title: 'Gonzo\'s Quest',
            provider: 'NetEnt',
            thumbnailUrl: 'https://placehold.co/300x200/FFC300/000?text=Gonzo',
            rtp: 95.97,
            volatility: 'Medium',
            isFeatured: false,
            description: 'Únete a Gonzo en la búsqueda de El Dorado.'
        },
        {
            id: '6',
            title: 'Wolf Gold',
            provider: 'Pragmatic Play',
            thumbnailUrl: 'https://placehold.co/300x200/DAF7A6/000?text=Wolf+Gold',
            rtp: 96.01,
            volatility: 'Medium',
            isFeatured: true,
            description: 'Aúlla a la luna y gana jackpots en el desierto.'
        },
        {
            id: '7',
            title: 'Ruleta Europea',
            provider: 'Evolution Gaming',
            thumbnailUrl: 'https://placehold.co/300x200/000000/FFF?text=Ruleta',
            rtp: 97.30,
            volatility: 'Medium',
            isFeatured: true,
            description: 'La experiencia clásica de casino en tu pantalla.'
        },
        {
            id: '8',
            title: 'Blackjack VIP',
            provider: 'Evolution Gaming',
            thumbnailUrl: 'https://placehold.co/300x200/006400/FFF?text=Blackjack',
            rtp: 99.28,
            volatility: 'Low',
            isFeatured: false,
            description: 'Juega contra el dealer en la mesa más exclusiva.'
        }
    ];

    constructor() { }

    /**
     * Simula una llamada a API para obtener todos los juegos
     * Retorna un Observable con un array de juegos
     */
    getAllGames(): Observable<Game[]> {
        return of(this.mockGames).pipe(delay(500)); // Simula latencia de red
    }

    /**
     * Simula una llamada a API para obtener juegos destacados
     */
    getFeaturedGames(): Observable<Game[]> {
        const featured = this.mockGames.filter(g => g.isFeatured);
        return of(featured).pipe(delay(500));
    }

    /**
     * Busca un juego por su ID
     * @param id Identificador del juego
     */
    getGameById(id: string): Observable<Game | undefined> {
        const game = this.mockGames.find(g => g.id === id);
        return of(game).pipe(delay(200));
    }
}
