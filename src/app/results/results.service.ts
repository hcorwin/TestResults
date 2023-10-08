import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ITestResults} from "../interfaces/ITestResults";

@Injectable({
  providedIn: 'root'
})
export class ResultsService {

  constructor(private http: HttpClient) { }

  AllResults(token: string){
    return this.http.get<ITestResults[]>(`https://localhost:7104/api/Users/results`,
      {headers: {'Authorization': `Bearer ${token}`}, observe: 'body', responseType: 'json'})
  }
}
