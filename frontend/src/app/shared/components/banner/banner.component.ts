import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-banner',
    templateUrl: './banner.component.html',
    styleUrls: ['./banner.component.css'],
    standalone: false
})
export class BannerComponent {
    @Input() title: string = 'Bienvenido al Mejor Casino';
    @Input() subtitle: string = 'Juega y Gana en Grande';
    @Input() ctaText: string = 'Jugar Ahora';
}
