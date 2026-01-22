import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Game } from '../../core/models/game.interface';
import { GameService } from '../../core/services/game.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    standalone: false
})
export class HomeComponent implements OnInit {
    featuredGames$!: Observable<Game[]>;

    constructor(private gameService: GameService) { }

    ngOnInit(): void {
        this.featuredGames$ = this.gameService.getFeaturedGames();
    }
}
