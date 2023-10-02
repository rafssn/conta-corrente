import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../types/type';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  private apiUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) { }

  cadastrar(user: any) {
    console.log(user);
    var body = {
      name: user.nome,
      password: user.senha,
      email: user.email
    }
    return this.http.post(`${this.apiUrl}/register`, body);
  }
}
