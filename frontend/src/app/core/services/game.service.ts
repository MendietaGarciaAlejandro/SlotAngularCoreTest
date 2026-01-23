import { Injectable } from '@angular/core';
import { Observable, of, delay } from 'rxjs';
import { Game, GameConfig } from '../models/game.interface';

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

    private gameConfigs: { [key: string]: GameConfig } = {
        '1': { // Sweet Bonanza (Frutas/Dulces)
            gameId: '1',
            symbols: ['🍭', '🍇', '🍉', '🍌', '🍎', '🍬', '💣'],
            rows: 5, cols: 6, paylines: 0, // Cluster
            themeColor: '#ff69b4'
        },
        '2': { // Book of Dead (Egipto)
            gameId: '2',
            symbols: ['🏺', '🐕', '🦅', '🤠', '🔟', '🇯', '🇶', '🇰', '🇦'],
            rows: 3, cols: 5, paylines: 10,
            themeColor: '#d4af37'
        },
        '3': { // Starburst (Joyas)
            gameId: '3',
            symbols: ['💎', '💠', '🔶', '🟣', '⭐', '7️⃣'],
            rows: 3, cols: 5, paylines: 10,
            themeColor: '#8a2be2'
        },
        '4': { // Big Bass (Pesca)
            gameId: '4',
            symbols: ['🐟', '🎣', '🛶', '🦟', '🐠', '🌊'],
            rows: 3, cols: 5, paylines: 10,
            themeColor: '#00bfff'
        },
        'default': {
            gameId: '0',
            symbols: ['🍒', '🍋', '🔔', '7️⃣', '💎', '🍀'],
            rows: 3, cols: 5, paylines: 20,
            themeColor: '#ff0000'
        }
    };

    constructor() { }

    getAllGames(): Observable<Game[]> {
        return of(this.mockGames);
    }

    getFeaturedGames(): Observable<Game[]> {
        const featured = this.mockGames.filter(g => g.isFeatured);
        return of(featured);
    }

    getGameById(id: string): Observable<Game | undefined> {
        const game = this.mockGames.find(g => g.id === id);
        return of(game);
    }

    getGameConfig(id: string): Observable<GameConfig> {
        const config = this.gameConfigs[id] || this.gameConfigs['default'];
        return of(config);
    }
}
