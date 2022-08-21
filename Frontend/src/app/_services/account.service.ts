import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Register } from '../_models/register';
import { Token } from '../_models/token';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  public currentUserSource = new ReplaySubject<string>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http : HttpClient) { }

  login(model : any) :Observable<Token>{
    return this.http.post(this.baseUrl + 'Account/login',model).pipe(
      map((response : Token) => {
        const user = response;
        if(user) {
          localStorage.setItem("user",JSON.stringify(user.token));
          this.currentUserSource.next(user.token);
        }
        return user;
      })
    )
  }

  register(model : Register) {
    return this.http.post(this.baseUrl + 'account/register',model);
  }
  // .pipe(
  //   map((user : Token) => {
  //     if (user) {
  //       localStorage.setItem("user",JSON.stringify(user.token));
  //       this.currentUserSource.next(user.token);
  //     }
  //   })
  // )

  setCurrentUser(user : string) {
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  update(model : User) {
    return this.http.put(this.baseUrl + 'User/update',model);
  }

  getUser() {
    return this.http.get<User>(this.baseUrl + "User/get");
  }

  delete() {
    return this.http.delete(this.baseUrl + "User/delete");
  }
}
