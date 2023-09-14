import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { ClienteModel, ResponseClientesModel } from '../interfaces/cliente.interface';

@Component({
  selector: 'app-lista-clientes',
  templateUrl: './lista-clientes.component.html',
  styleUrls: ['./lista-clientes.component.css']
})
export class ListaClientesComponent implements OnInit {

  public clientes: any = [];

  exibeLoading = false;
  temCliente = false;

  constructor(private clienteService: ClienteService) {

  }


  ngOnInit() {
    this.carregarClientes();
  }

  public carregarClientes(): void {
    this.clienteService.getClientes().subscribe(
      response => this.clientes = response,
      error=> console.log(error)
    );
  }

  public detalheCliente(id:number) :void{

  }

  public filtrarClientes(event:EventTarget|null ):void{

  }

}
