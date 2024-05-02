import { Component } from '@angular/core';
import { HeaderComponent } from '../components/header/header.component';
import { FooterComponent } from '../components/footer/footer.component';
import { SidebarComponent } from '../components/sidebar/sidebar.component';
import { MatSidenavModule } from '@angular/material/sidenav';
@Component({
  selector: 'app-default-layout',
  standalone: true,
  imports: [
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    MatSidenavModule,
  ],
  templateUrl: './default-layout.component.html',
  styleUrl: './default-layout.component.scss',
})
export class DefaultLayoutComponent {
  opened: boolean = false;
}
