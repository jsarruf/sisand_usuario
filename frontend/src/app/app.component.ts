import { Component } from '@angular/core';
import { Router, RouterModule, NavigationEnd } from '@angular/router';
import { CommonModule } from '@angular/common';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, CommonModule], // ✅ precisa do CommonModule para *ngIf
  template: `
  <div class="d-flex">
   <div *ngIf="!hideNavbar" class="bg-dark text-white vh-100 p-3" style="width: 220px;">
      <h4 class="text-center mb-4">Menu</h4>
      <ul class="nav flex-column">
        <li class="nav-item mb-2">
          <a class="nav-link text-white" routerLink="/users" routerLinkActive="fw-bold">📋 Lista Usuários</a>
        <li class="nav-item mt-4">
          <a class="nav-link text-danger" (click)="logout()">🚪 Sair</a>
        </li>
      </ul>
    </div>
    <div class="flex-grow-1 p-4">
      <router-outlet></router-outlet>
    </div>
  </div>
`
})
export class AppComponent {
  hideNavbar = false;

  constructor(private router: Router) {
    this.router.events
      .pipe(filter(e => e instanceof NavigationEnd))
      .subscribe((e: NavigationEnd) => {
        this.hideNavbar = e.urlAfterRedirects === '/login';
      });
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
