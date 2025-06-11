import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap, mapTo, catchError } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AuthService {
  constructor(private http: HttpClient) {}

login(username: string, password: string): Observable<boolean> {
  return this.http
    .post<{ token: string }>('http://localhost:5000/api/auth/login', { username, password })
    .pipe(
      tap(response => localStorage.setItem('token', response.token)),
      mapTo(true),
      catchError(() => of(false))
    );
}

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }
}
