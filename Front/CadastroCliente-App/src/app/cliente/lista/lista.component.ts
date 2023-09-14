import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss']
})
export class ListaComponent implements OnInit {

    public cliente: any = {
        nome: 'Teste',
        dataNascimento: '2000-2-11',
        telefone: '1199999-0000',
        email: 'teste@teste.com',
        enderecos: [
            {
                cep: '01001-000',
                logradouro: 'Praça da Sé',
                complemento: 'lado ímpar',
                bairro: 'Sé',
                localidade:'São Paulo',
                uf:'SP',
                ddd:'11'
            }
        ]
    }

    constructor() {

    }

    ngOnInit(): void {
        
    }
}
