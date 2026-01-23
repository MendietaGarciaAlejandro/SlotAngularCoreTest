import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GameService } from '../../../../core/services/game.service';
import { Game, GameConfig } from '../../../../core/models/game.interface';
import { delay, finalize } from 'rxjs';

@Component({
    selector: 'app-game-play',
    templateUrl: './game-play.component.html',
    styleUrls: ['./game-play.component.css'],
    standalone: false
})
export class GamePlayComponent implements OnInit {
    gameId: string | null = null;
    game: Game | undefined;
    config: GameConfig | undefined;

    // Estado del juego
    grid: string[][] = [];
    isSpinning = false;
    winAmount = 0;
    message = '¡Buena suerte!';
    balance = 1000; // Balance simulado
    bet = 10;

    constructor(
        private route: ActivatedRoute,
        private gameService: GameService
    ) { }

    ngOnInit(): void {
        this.gameId = this.route.snapshot.paramMap.get('id');
        if (this.gameId) {
            this.loadGame(this.gameId);
        }
    }

    loadGame(id: string) {
        // Cargar info del juego
        this.gameService.getGameById(id).subscribe(g => this.game = g);

        // Cargar configuración de la slot
        this.gameService.getGameConfig(id).subscribe(c => {
            this.config = c;
            this.initializeGrid();
        });
    }

    initializeGrid() {
        const config = this.config;
        if (!config) return;
        // Llenar grilla inicial con símbolos aleatorios
        this.grid = Array(config.rows).fill(null)
            .map(() => Array(config.cols).fill(null)
                .map(() => this.getRandomSymbol()));
    }

    getRandomSymbol(): string {
        if (!this.config) return '?';
        const index = Math.floor(Math.random() * this.config.symbols.length);
        return this.config.symbols[index];
    }

    spin() {
        if (this.isSpinning || this.balance < this.bet) {
            if (this.balance < this.bet) this.message = 'Saldo insuficiente';
            return;
        }

        this.isSpinning = true;
        this.message = '¡Girando...!';
        this.winAmount = 0;
        this.balance -= this.bet;

        // Simular tiempo de giro
        setTimeout(() => {
            this.performSpin();
            this.checkWin();
            this.isSpinning = false;
        }, 1500); // 1.5 segundos de tensión
    }

    performSpin() {
        if (!this.config) return;

        // Generar nueva matriz
        this.grid = this.grid.map(row =>
            row.map(() => this.getRandomSymbol())
        );
    }

    checkWin() {
        if (!this.config) return;
        let win = 0;

        // Lógica simple de victoria: 3 o más iguales en una fila
        // (Simplificado para la demo)
        for (let row of this.grid) {
            let count = 1;
            for (let i = 1; i < row.length; i++) {
                if (row[i] === row[i - 1]) {
                    count++;
                } else {
                    // Chequear si la racha anterior fue premio
                    if (count >= 3) win += count * 5;
                    count = 1;
                }
            }
            if (count >= 3) win += count * 5;
        }

        if (win > 0) {
            this.winAmount = win;
            this.balance += win;
            this.message = `¡PREMIO! Ganaste ${win} créditos`;
        } else {
            this.message = '¡Inténtalo de nuevo!';
        }
    }
}
