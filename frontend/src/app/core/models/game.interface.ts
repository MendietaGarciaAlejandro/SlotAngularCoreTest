export interface Game {
    id: string;
    title: string;
    provider: string;
    thumbnailUrl: string;
    rtp: number;
    volatility: 'High' | 'Medium' | 'Low';
    isFeatured: boolean;
    description: string;
}

export interface GameConfig {
    gameId: string;
    symbols: string[]; // Emojis o URLs de imágenes
    rows: number;
    cols: number;
    paylines: number; // Por ahora visual
    themeColor: string;
    backgroundImage?: string;
}
