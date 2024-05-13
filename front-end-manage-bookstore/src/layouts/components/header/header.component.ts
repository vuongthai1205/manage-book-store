import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { MatIconModule, MatIconRegistry } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatBadgeModule } from '@angular/material/badge';
import { Router, RouterLink } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import {
  CART_ICON,
  HOME_ICON,
  LOG_OUT_ICON,
} from '../../../app/shared/icons/share-icon';
import { OrderService } from '../../../app/services/order.service';
import { Subscription } from 'rxjs';
import { ConfigApiService } from '../../../app/services/config-api.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatBadgeModule,
    RouterLink,
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent implements OnInit, OnDestroy {
  @Input() drawer: any;
  orderQuantity: number = 0;
  private orderDetailsSubscription?: Subscription;
  handleLogout() {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    localStorage.removeItem('currentOrder');
    this.router.navigate(['login']);
  }
  user: any | null;
  constructor(
    private router: Router,
    private orderService: OrderService,
    private apiConfig: ConfigApiService,
    iconRegistry: MatIconRegistry,
    sanitizer: DomSanitizer
  ) {
    iconRegistry.addSvgIconLiteral(
      'cart-icon',
      sanitizer.bypassSecurityTrustHtml(CART_ICON)
    );
    iconRegistry.addSvgIconLiteral(
      'logout-icon',
      sanitizer.bypassSecurityTrustHtml(LOG_OUT_ICON)
    );
    iconRegistry.addSvgIconLiteral(
      'home-icon',
      sanitizer.bypassSecurityTrustHtml(HOME_ICON)
    );
  }
  ngOnDestroy(): void {
    // Unsubscribe from the subscription to avoid memory leaks
    if (this.orderDetailsSubscription) {
      this.orderDetailsSubscription.unsubscribe();
    }
  }
  ngOnInit(): void {
    this.user = this.apiConfig.getCurrentUserFromLocal()
    this.orderDetailsSubscription = this.orderService.orderDetails$.subscribe(
      (details) => {
        this.orderQuantity = details.length; // Set the order quantity based on the length of orderDetails
      }
    );
  }
}
