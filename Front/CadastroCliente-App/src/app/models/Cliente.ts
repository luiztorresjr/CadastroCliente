import { Endereco } from "./Endereco";

export interface Cliente {
    id: number;
    nome: string;
    dataNascimento?: Date;
    clientesEnderecos?: Endereco[];
    telefone?: string;
    email?: string;
}
