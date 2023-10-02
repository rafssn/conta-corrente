import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {  FormUser } from '../types/type';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {

  private apiUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) { }

  cadastrar(user: FormUser) {
    console.log(user);
    var body = {
      name: user.nome,
      password: user.senha,
      email: user.email
    }
    return this.http.post(`${this.apiUrl}/register`, body);
  }
}
