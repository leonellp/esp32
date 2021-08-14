import { BalancaDTO } from "./BalancaDTO";
import { HistoricoProdutoDTO } from "./HistoricoProdutoDTO";

export interface ProdutoDTO {
    Idproduto: string;
    Nome: string;
    Marca: string;
    Peso: number;
    Inativo: Date | string | null;

    Balanca: BalancaDTO[];
    HistoricoProduto: HistoricoProdutoDTO[];
}