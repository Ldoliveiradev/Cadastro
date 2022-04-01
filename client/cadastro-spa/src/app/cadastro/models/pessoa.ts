import { Cidade } from './cidade';

export interface Pessoa {
  id: number;
  nome: string;
  cpf: string;
  idade: number;
  cidadeId: number;
  nomeCidade: string;
  uf: string;
}
