import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-loan-main-page',
  standalone: true,
  imports: [RouterLink,RouterOutlet],
  templateUrl: './loan-main-page.component.html',
  styleUrl: './loan-main-page.component.scss'
})
export class LoanMainPageComponent {

}
