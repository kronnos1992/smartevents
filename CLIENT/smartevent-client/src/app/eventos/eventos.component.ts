import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get('https://localhost:7001/api/events').subscribe({
      next: (response) => {
        this.eventos = response;
      },
      error: (error) => {
        console.log(error);
      },
      complete() {
        console.info('completed');
      },
    });
  }
}
