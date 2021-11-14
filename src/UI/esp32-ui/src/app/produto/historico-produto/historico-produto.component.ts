import { Location } from '@angular/common';
import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Chart, registerables } from 'chart.js';
import { HistoricoProdutoDTO } from 'src/app/shared/DTOs/HistoricoProdutoDTO';
import { ProdutoDTO } from 'src/app/shared/DTOs/ProdutoDTO';
import { ProdutoService } from 'src/app/shared/services/produto.service';

@Component({
  selector: 'app-historico-produto',
  templateUrl: './historico-produto.component.html',
  styleUrls: ['./historico-produto.component.scss'],
})
export class HistoricoProdutoComponent implements OnInit, OnDestroy {
  public historico: HistoricoProdutoDTO[];
  public produto: ProdutoDTO;
  public historicoQuantidade: Number[] = [];
  public historicoData: string[] = [];
  private dataAnterior = '';
  private id = '';
  private loop: any;

  @ViewChild('grafico', { static: true }) grafico: ElementRef;

  constructor(
    private activatedRoute: ActivatedRoute,
    private produtoService: ProdutoService,
    private _location: Location
  ) {}

  ngOnDestroy(): void {
    if (this.loop) clearInterval(this.loop);
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((data) => {
      if (data.id) {
        this.id = data.id;
        this.loadHistorico();
        this.produtoService
          .getById(data.id)
          .subscribe((_produto) => (this.produto = _produto));
      }
    });

    this.loop = setInterval(() => {
      this.loadHistorico();
    }, 5000);
  }

  back(): void {
    this._location.back();
  }

  loadHistorico(): void {
    this.produtoService
      .historico(this.id, null, null)
      .subscribe((_historico) => {
        if (_historico) {
          this.historico = [];
          this.historicoQuantidade = [];
          this.historicoData = [];
          this.historico = _historico.values.reverse();

          _historico.values.forEach((qtd) => {
            if (qtd) {
              this.historicoQuantidade.push(qtd.quantidade);

              var data: string;
              var dd = qtd.data.toString().split('-')[2].split('T')[0];
              var hh =
                qtd.data.toString().split('-')[2].split('T')[1].split(':')[0] +
                ':' +
                qtd.data.toString().split('-')[2].split('T')[1].split(':')[1];

              var mm = qtd.data.toString().split('-')[1];
              var yyyy = qtd.data.toString().split('-')[0];

              data = dd + '/' + mm + '/' + yyyy;
              if (data != this.dataAnterior) this.historicoData.push(data);
              else this.historicoData.push(hh);
              this.dataAnterior = data;
            }
          });
          Chart.register(...registerables);

          new Chart(this.grafico?.nativeElement, {
            type: 'line',
            data: {
              labels: this.historicoData,
              datasets: [
                {
                  data: this.historicoQuantidade,
                  fill: false,
                  label: 'Quantidade',
                  borderColor: 'rgb(75, 192, 192)',
                  tension: 0.5,
                },
              ],
            },
          });
        }
      });
  }
}
