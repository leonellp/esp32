import { Location } from '@angular/common';
import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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
  public qtdAnterior: Number = -1;
  public historicoData: string[] = [];
  private dataAnterior = '';
  private id = '';
  private loop: any;
  private myGraph: Chart<'line', Number[], string>;

  inicio: Date;
  fim: Date;

  range: FormGroup;

  @ViewChild('grafico', { static: true }) grafico: ElementRef;

  constructor(
    private activatedRoute: ActivatedRoute,
    private produtoService: ProdutoService,
    private _location: Location
  ) {
    var start = new Date();
    start.setDate(start.getDate() - 3);
    var end = new Date();
    end.setDate(end.getDate());

    this.range = new FormGroup({
      start: new FormControl(start),
      end: new FormControl(end),
    });
  }

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

  DateChange(): void {
    this.loadHistorico();
  }

  loadHistorico(): void {
    var inicio = new Date();
    var fim = new Date();
    inicio = this.range.controls['start'].value;
    fim = this.range.controls['end'].value;

    this.produtoService
      .historico(this.id, inicio?.toJSON(), fim?.toJSON())
      .subscribe((_historico) => {
        if (_historico) {
          this.historico = [];
          this.historicoQuantidade = [];
          this.historicoData = [];
          this.historico = _historico.values.reverse();

          _historico.values.forEach((qtd) => {
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
          });

          if (
            this.historicoQuantidade[this.historicoQuantidade.length - 1] !=
            this.qtdAnterior
          ) {
            if (this.myGraph) this.myGraph.destroy();
            Chart.register(...registerables);

            this.myGraph = new Chart(this.grafico?.nativeElement, {
              type: 'line',
              data: {
                labels: this.historicoData,
                datasets: [
                  {
                    data: this.historicoQuantidade,
                    fill: false,
                    label: 'Quantidade',
                    borderColor: 'rgb(75, 192, 192)',
                    tension: 0.25,
                    backgroundColor: 'rgba(255,255,0,0.28)',
                  },
                ],
              },
              options: {
                responsive: true,
              },
            });

            this.qtdAnterior =
              this.historicoQuantidade[this.historicoQuantidade.length - 1];
          }
        }
      });
  }
}
