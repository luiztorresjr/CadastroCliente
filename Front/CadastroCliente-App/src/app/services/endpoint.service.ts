import { Inject, Injectable } from "@angular/core";

@Injectable()
export class EndpointService {

    public GetUrlViaCep(filtro: any, tipoRetorno:any): string {
        return 'https://viacep.com.br/ws/' + filtro + '/' + tipoRetorno;
    }

    public GetUrlRestService(filtro?: any): string {
        var url = 'https://localhost:5001/CadastroCliente/'
        if(filtro == null)
            return url;
        else{
            return url+filtro;
        }
    }
}