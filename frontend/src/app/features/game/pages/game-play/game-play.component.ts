import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Game } from '../../../../core/models/game.interface';
import { ConfigJuego } from '../../../../core/models/config-juego.interface';
import { GameService } from '../../../../core/services/game.service';
import { Location } from '@angular/common';

@Component({
    selector: 'app-game-play',
    templateUrl: './game-play.component.html',
    styleUrls: ['./game-play.component.css'],
    standalone: false
})
export class GamePlayComponent implements OnInit {
    game: Game | undefined;
    config: ConfigJuego | undefined;
    loading = true;

    // Estado del juego
    grid: string[][] = [];
    isSpinning = false;
    balance = 1000; // Mockearemos Billetera por el momento
    bet = 10;
    lastWin = 0;

    constructor(
        private route: ActivatedRoute,
        private gameService: GameService,
        private location: Location
    ) { }

    ngOnInit(): void {
        const id = this.route.snapshot.paramMap.get('id');
        if (id) {
            this.gameService.getGameById(id).subscribe(g => {
                this.game = g;
                this.loading = false;
            });
            this.gameService.getGameConfig(id).subscribe((c: ConfigJuego) => {
                this.config = c;
                if (c) this.initializeGrid();
            });
        }
    }

    initializeGrid(): void {
        if (!this.config) return;
        this.grid = [];
        for (let r = 0; r < this.config.filas; r++) {
            const row = [];
            for (let c = 0; c < this.config.columnas; c++) {
                row.push(this.getRandomSymbol());
            }
            this.grid.push(row);
        }
    }

    getRandomSymbol(): string {
        if (!this.config || !this.config.simbolos) return "❓";
        const index = Math.floor(Math.random() * this.config.simbolos.length);
        return this.config.simbolos[index];
    }

    spin(): void {
        if (this.balance < this.bet || this.isSpinning || !this.config) return;

        this.isSpinning = true;
        this.balance -= this.bet;
        this.lastWin = 0;

        // Simular retardo
        setTimeout(() => {
            this.performSpin();
        }, 1000);
    }

    performSpin(): void {
        if (!this.config) return;

        this.isSpinning = false;
        this.initializeGrid(); // Generar un grid aleatorio final

        // Lógica simple y simulada de victoria
        let winAmount = 0;
        for (let row of this.grid) {
            let count = 1;
            for (let i = 1; i < row.length; i++) {
                if (row[i] === row[i - 1]) {
                    count++;
                } else {
                    if (count >= 3) winAmount += count * 5;
                    count = 1;
                }
            }
            if (count >= 3) winAmount += count * 5;
        }

        if (winAmount > 0) {
            this.lastWin = winAmount;
            this.balance += winAmount;
        }
    }

    goBack(): void {
        this.location.back();
    }
}

