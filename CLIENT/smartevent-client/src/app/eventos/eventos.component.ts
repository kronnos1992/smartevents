import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  public eventsFounded: any = [];
  //função para ocultar/exibir as imagens
  isCollapsed: boolean = false;

  // propriedades da imagem
  widthImg: number = 50;
  marginImg: number = 2;
  private _filterList: string = '';

  // função para fazer filtro

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.eventsFounded = this.filterList
      ? this.eventsFilter(this.filterList)
      : this.eventos;
  }

  eventsFilter(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) =>
        evento.subject.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        evento.place.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get('https://localhost:7001/api/events').subscribe({
      next: (response) => {
        this.eventos = response;
        this.eventsFounded = this.eventos;
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
