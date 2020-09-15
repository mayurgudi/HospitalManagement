import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TokenService } from 'src/authorization/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit 
{  
  formGroup: FormGroup = null;
  username: string;
  sendData: string = "";

  constructor(private http: HttpClient, private tokenService: TokenService, private router: Router)
  {
    var builder = new FormBuilder();
    this.formGroup = builder.group({});
    this.formGroup.addControl("uname", new FormControl("", Validators.required));
  }

  myLogin() : void
  {
    let paramList = new HttpParams();
    paramList.append("name", this.username);
    this.http.get("https://localhost:44330/api/Security/", { params: paramList, responseType: "text"})
    .subscribe(data => {
      this.tokenService.token = data;
    });
    console.log(this.tokenService.token);
    this.router.navigate(['Home']);
  }

  ngOnInit(): void {  }
}
