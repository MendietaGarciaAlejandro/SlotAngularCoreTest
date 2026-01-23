import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Game } from '../../core/models/game.interface';
import { GameService } from '../../core/services/game.service';

@Component({
    selector: 'app-lobby',
    templateUrl: './lobby.component.html',
    standalone: false
})
export class LobbyComponent implements OnInit {
    juegos$!: Observable<Game[]>;

    constructor(private gameService: GameService) { }

    ngOnInit(): void {
        this.juegos$ = this.gameService.getAllGames();
    }
}
