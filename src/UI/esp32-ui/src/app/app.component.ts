import { Component, OnInit } from '@angular/core';
import { BalancaDTO } from './shared/DTOs/BalancaDTO';
import { BalancaService } from './shared/services/balanca.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'esp32-ui';

  constructor(private balancaService: BalancaService) { }

  ngOnInit(): void {
    this.balancaService.list(0, 5, true, '').subscribe(balancas => {
      console.log(balancas);
    })
  }


}
