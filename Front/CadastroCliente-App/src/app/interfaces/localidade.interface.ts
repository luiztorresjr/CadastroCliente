export interface LocalidadeModel{
    cep: string;
    logradouro?: string;
    complemento?: string;
    bairro?: string;
    localidade?: string;
    uf?: string;
    ibge?: number;
    ddd?: number;
    erro?: boolean;
  }