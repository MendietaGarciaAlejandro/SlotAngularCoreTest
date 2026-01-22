import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GameCardComponent } from './components/game-card/game-card.component';

import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { BannerComponent } from './components/banner/banner.component';

@NgModule({
    declarations: [
        GameCardComponent,
        HeaderComponent,
        FooterComponent,
        BannerComponent
    ],
    imports: [
        CommonModule,
        RouterModule
    ],
    exports: [
        CommonModule,
        RouterModule,
        GameCardComponent,
        HeaderComponent,
        FooterComponent,
        BannerComponent
    ]
})
export class SharedModule { }
