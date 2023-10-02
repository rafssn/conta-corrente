import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserService } from './user.service';

interface AuthResponse {
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class AutenticacaoService {

  private apiAuthUrl: string = environment.apiUrl;

  constructor(
    private http: HttpClient,
    private userService: UserService
  ) {}

  autenticar(email: string, senha: string): Observable<HttpResponse<AuthResponse>> {
    return this.http.post<AuthResponse>(
      `${this.apiAuthUrl}/auth/login`,
      { email, password: senha },
      { observe: 'response'}
    ).pipe(
      tap((response) => {
        const authToken = response.body?.token || '';
        this.userService.salvarToken(authToken);
      })
    );
  }

}
