import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AuthGuardService } from 'src/authorization/auth-guard.service';
import { InterceptorService } from 'src/authorization/interceptor.service';
import { TokenService } from 'src/authorization/token.service';
import { MasterComponent } from './master/master.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSidenavModule } from '@angular/material/sidenav';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    MasterComponent
  ],
  imports: [
    BrowserModule, 
    CommonModule, 
    ReactiveFormsModule,
    FormsModule, 
    HttpClientModule, 
    MatFormFieldModule, 
    MatInputModule, 
    MatSidenavModule,
    RouterModule.forRoot([
      { path: 'Login' , component: LoginComponent },
      { path: 'Home' , component: HomeComponent, canActivate: [AuthGuardService] , 
        children: [
          { path: 'Patient' , loadChildren: () => import('../PatientModule/patient.module')
          .then(m => m.PatientModule) }
        ]
      },
      { path: '' , component: HomeComponent, canActivate: [AuthGuardService] }
    ]), BrowserAnimationsModule
  ],
  providers: [AuthGuardService, InterceptorService, TokenService],
  bootstrap: [MasterComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})

export class AppModule { }