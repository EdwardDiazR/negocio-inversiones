import { NgClass } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterModule } from '@angular/router';


@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [NgClass,RouterLink,RouterModule],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss',
})
export class NavBarComponent {
  userRole: String = 'REPRESENTANTE DE SERVICIOS';

  showUserOptions: boolean = false;
}
