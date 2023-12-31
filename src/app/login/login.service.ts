import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ITestResults} from "../interfaces/ITestResults";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  Login(username: string, password: string){
    return this.http.get(`https://localhost:7104/api/Users/login`,
      {params: {username, password}, observe: 'body', responseType: 'text'})
  }
}
