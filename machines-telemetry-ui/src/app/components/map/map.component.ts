import { DecimalPipe } from '@angular/common';
import { AfterViewInit, Component, Input } from '@angular/core';
import L from 'leaflet';

@Component({
  selector: 'app-map',
  standalone: true,
  imports: [],
  templateUrl: './map.component.html',
  styleUrl: './map.component.css'
})

export class MapComponent implements AfterViewInit {

  @Input() latitude: number  = 0;
  @Input() longitude: number = 0;

  map: L.Map | undefined;

  ngAfterViewInit(): void {

    delete (L.Icon.Default.prototype as any)._getIconUrl;
    L.Icon.Default.mergeOptions({
      iconRetinaUrl: 'https://unpkg.com/leaflet@1.9.4/dist/images/marker-icon-2x.png',
      iconUrl: 'https://unpkg.com/leaflet@1.9.4/dist/images/marker-icon.png',
      shadowUrl: 'https://unpkg.com/leaflet@1.9.4/dist/images/marker-shadow.png'
    });

    this.map = L.map('map').setView([this.latitude, this.longitude], 13);

    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(this.map);

    L.marker([this.latitude, this.longitude]).addTo(this.map)
      .bindPopup('Ultima localização da máquina')
      .openPopup();

    setTimeout(() => this.map?.invalidateSize(), 100);
  }
}
