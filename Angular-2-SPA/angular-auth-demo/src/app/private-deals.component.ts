import { Component, OnInit } from '@angular/core';

import { Deal } from './deal';
import { DealService } from './deal-service';

@Component({
  selector: 'private-deals',
  templateUrl: './private-deals.component.html',
  styleUrls: ['./private-deals.component.css']
})
export class PrivateDealsComponent implements OnInit {
  privateDeals : Deal[];
  error: any;

  constructor(
    private dealService: DealService) { }

  getPrivateDeals(): void {
    this.dealService
      .getPrivateDeals()
      .subscribe(deals => this.privateDeals = deals);
  }

  ngOnInit(): void {
    this.getPrivateDeals();
  }

  purchase(item){
    alert("You bought the: " + item.name);
  }
}