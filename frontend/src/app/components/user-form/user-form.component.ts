import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService, User } from '../../services/user.service';

@Component({
  standalone: true,
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  imports: [CommonModule, FormsModule]
})
export class UserFormComponent implements OnInit {
  user: User = { username: '',  password: '' };
  feedback: string = '';

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.userService.getUser(+id).subscribe(user => {
        this.user = user;
        this.user.password = '';
      });
    }
  }

  onSubmit() {
    const op = this.user.id
      ? this.userService.updateUser(this.user)
      : this.userService.createUser(this.user);

    op.subscribe({
      next: () => {
        this.feedback = 'Usuário salvo com sucesso!';
        setTimeout(() => this.router.navigate(['/users']), 1500);
      },
      error: () => this.feedback = 'Erro ao salvar usuário.'
    });
  }
}