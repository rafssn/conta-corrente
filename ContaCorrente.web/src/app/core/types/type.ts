export interface User {
  name: string;
  email: string;
  password: string;
}

export interface FormUser {
        nome: string,
        email: string,
        senha: string,
        confirmarEmail: string,
        confirmarSenha: string
}

interface AuthResponse {
    token: string;
  }