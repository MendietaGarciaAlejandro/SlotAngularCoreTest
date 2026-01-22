export interface Game {
    id: string;
    title: string;
    description?: string;
    provider: string; // e.g., 'Pragmatic Play', 'NetEnt'
    thumbnailUrl: string;
    rtp: number; // Return to Player percentage
    volatility: 'Low' | 'Medium' | 'High' | 'Very High';
    isFeatured?: boolean;
}
