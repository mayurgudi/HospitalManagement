import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuardService implements CanActivate {
  
  constructor(private _router: Router, public _token: TokenService) { }
  
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> |  boolean
  {
    if(this._token.token.length >= 0)
    {
      // console.log(this._token.token);
      return true;
    }
    // console.log("no token");
    this._router.navigate(['Login']);
    return false;
  }
}
