import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { GamePlayComponent } from './pages/game-play/game-play.component';
import { SharedModule } from '../../shared/shared.module';

const routes: Routes = [
    { path: ':id', component: GamePlayComponent }
];

@NgModule({
    declarations: [
        GamePlayComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        SharedModule
    ]
})
export class GameModule { }
