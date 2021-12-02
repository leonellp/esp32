import {
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Chart, registerables } from 'chart.js';
import { Paginacao } from '../shared/DTOs/Paginacao';
import { ProdutoDTO } from '../shared/DTOs/ProdutoDTO';
import { ProdutoService } from '../shared/services/produto.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit, AfterViewInit {
  produtos: Paginacao<ProdutoDTO>;
  labels: string[] = [];
  data: number[] = [];
  color: string[] = [];

  private myGraph: Chart<'pie', Number[], string>;
  @ViewChild('grafico', { static: true }) grafico: ElementRef;

  constructor(private produtoService: ProdutoService) {}

  ngAfterViewInit(): void {
    this.myGraph.show;
  }

  ngOnInit(): void {
    this.list();
  }

  list(): void {
    this.produtoService.list(0, 5, true, '').subscribe((produtos) => {
      this.produtos = produtos;
      produtos.values.forEach((prd) => {
        this.labels.push(prd.nome + ' ' + prd.marca);

        this.produtoService.historico(prd.idproduto).subscribe((historicos) => {
          var data = historicos.values[0]?.quantidade
            ? historicos.values[0]?.quantidade
            : 0;

          this.data.push(data);
          this.color.push(this.getRandomColor());
        });
      });
      if (this.myGraph) this.myGraph.destroy();
      Chart.register(...registerables);

      this.myGraph = new Chart(this.grafico?.nativeElement, {
        type: 'pie',

        data: {
          labels: this.labels,
          datasets: [
            {
              data: this.data,
              label: 'Quantidade',
              backgroundColor: this.color,
            },
          ],
        },
        options: {
          responsive: true,
          maintainAspectRatio: true,

          layout: {
            padding: {
              top: 6,
              left: 16,
              right: 16,
              bottom: 6,
            },
          },
        },
      });
    });
  }

  getRandomColor() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';
    for (var i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
  }
}
