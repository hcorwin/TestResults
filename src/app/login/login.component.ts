import { Component } from '@angular/core';
import { FormControl, Validators} from '@angular/forms';
import { LoginService } from './login.service';
import { Router } from '@angular/router';
import {ITestResults} from "../interfaces/ITestResults";


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username = new FormControl('', [Validators.required, Validators.email])
  password = new FormControl('', [Validators.required])

  constructor(private loginService: LoginService,
              private router: Router){}

  Login(){
    this.loginService.Login(this.username.value!, this.password.value!)
      .subscribe(token => {
        if (token){
          localStorage.setItem('token', token)
          this.router.navigate(['/results']);
        }
        else {
          console.log("error with token retrieval")
        }
      })
  }
}
