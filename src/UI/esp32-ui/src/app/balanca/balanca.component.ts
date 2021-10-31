import { Component, OnInit } from '@angular/core';
import { BalancaDTO } from '../shared/DTOs/BalancaDTO';
import { Paginacao } from '../shared/DTOs/Paginacao';
import { BalancaService } from '../shared/services/balanca.service';

@Component({
  selector: 'app-balanca',
  templateUrl: './balanca.component.html',
  styleUrls: ['./balanca.component.scss']
})
export class BalancaComponent implements OnInit {
  public balanca: Paginacao<BalancaDTO>;

  constructor(private balancaService: BalancaService) {
    this.balanca = { } as Paginacao<BalancaDTO>;
    this.balancaService.list(0, 10, true).subscribe(balanca => {
      this.balanca = balanca;
    });
  }

  ngOnInit(): void {
    
  }

}
