import { BalancaDTO } from './BalancaDTO';
import { HistoricoProdutoDTO } from './HistoricoProdutoDTO';

export class ProdutoDTO {
  idproduto: string;
  nome: string;
  marca: string;
  peso: number;
  inativo?: Date;

  balanca: BalancaDTO[];
  historicoProduto: HistoricoProdutoDTO[];
}
