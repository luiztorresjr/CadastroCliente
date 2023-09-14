import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient, HttpParams, HttpHeaders } from "@angular/common/http";

import { EndpointService  } from "./endpoint.service";
import { ClienteModel, ResponseClientesModel } from "../interfaces/cliente.interface";

@Injectable({
    providedIn: 'root'
})
export class ClienteService{
    baseURL = 'https://localhost:5001/api/Cliente';

    constructor(
        private _http: HttpClient

    ){}

    private _obterHeaders(): any{
        return {
            'Content-type': 'application/json'
        };
    }

    getClientes(): Observable<ResponseClientesModel|null>{
        return this._http.get<ResponseClientesModel>(this.baseURL);
    }

    
}