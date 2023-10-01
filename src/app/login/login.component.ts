import { Component } from '@angular/core';
import { FormControl, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LoginService } from './login.service';
import { Router } from '@angular/router';


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
    if (this.loginService.Login(this.username.value!, this.password.value!)){
      console.log("true")
      this.router.navigate(['/results']);
    };
  }

}
