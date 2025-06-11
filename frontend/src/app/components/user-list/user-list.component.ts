import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UserService, User } from '../../services/user.service';

@Component({
  standalone: true,
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  imports: [CommonModule, RouterModule]
})
export class UserListComponent {
  users: User[] = [];
  feedback: string = '';

  constructor(private userService: UserService) {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers().subscribe(data => this.users = data);
  }

  deleteUser(id: number) {
    if (confirm('Deseja realmente excluir?')) {
      this.userService.deleteUser(id).subscribe({
        next: () => {
          this.feedback = 'Usuário excluído com sucesso!';
          this.loadUsers();
        },
        error: () => this.feedback = 'Erro ao excluir usuário.'
      });
    }
  }
}