import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lista-clientes',
  templateUrl: './lista-clientes.component.html',
  styleUrls: ['./lista-clientes.component.css']
})
export class ListaClientesComponent implements OnInit {

  public clientes: any;

  constructor(private http: HttpClient) {

  }


  ngOnInit() {
  }

  public getClientes(): void {
    this.http.get('https://localhost:5001/CadastroCliente')
    .subscribe(
        response => this.clientes = response,
        error => console.log(error)
    );
}
}
