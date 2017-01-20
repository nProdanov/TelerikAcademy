import { Component, OnInit } from '@angular/core';
import { Deal } from './deal';

import { AuthService } from './auth-service';
import { DealService } from './deal-service';

@Component({
    selector: 'public-deals',
    templateUrl: './public-deals.component.html',
    styleUrls: ['./public-deal.component.css']
})
export class PublicDealsComponent implements OnInit {
    private dealService: DealService;
    private authService: AuthService;

    publicDeals: Deal[];

    constructor(dealService: DealService, authService: AuthService) {
        this.dealService = dealService;
        this.authService = authService;
    }

    ngOnInit(): void {
        this.dealService.getPublicDeals()
            .subscribe((deals: Deal[]) => this.publicDeals = deals)
    }

    purchaseItem(item: any) {
        alert(`You bought me ${item.name}`)
    }
}