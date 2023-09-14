export interface EnderecoModel{
    id: number,
    cep: string,
    logradouro: string,
    complemento: string,
    bairro: string,
    localidade: string,
    uf: string,
    ddd: string,
    clienteId:number
}

export interface ClienteModel{
    id: number, 
    nome: string,
    dataNascimento?: Date,
    enderecos: EnderecoModel[],
    telefone: string,
    email: string
}

export interface ResponseClientesModel{
    listaCliente: ClienteModel[]
}