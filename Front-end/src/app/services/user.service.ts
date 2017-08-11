import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { User } from '../models/index';
import { Settings } from '../settings';

@Injectable()

export class UserService {
  constructor(private http: Http) {
  }
  private baseUrl = Settings.UsersApiUrl;
  private headers = new Headers({'Content-Type':'application/json'});

  getUsers(): Promise<User[]> {
    return this.http.get(this.baseUrl)
    .toPromise()
    .then(responce => responce.json())
    .catch(this.handleError);
  }

  addUser(user: User):Promise<User> {
    return this.http.put(this.baseUrl+"/createuser", JSON.stringify(user), {headers:this.headers})
    .toPromise()
    .then(responce => responce.json())
    .catch(this.handleError);
  }

  deleteUser(id:number): Promise<void>{
    return this.http.delete(this.baseUrl + `/${id}`)
    .toPromise()
    .then(() => null)
    .catch(this.handleError);
  }

  editUser(user: User):Promise<void>{
    return this.http.post(this.baseUrl + '/edituser', JSON.stringify(user), {headers:this.headers})
    .toPromise()
    .then(() => null)
    .catch(this.handleError);
  }

  private handleError(error:any): Promise<any> {
    console.error('An error has occured', error);
    return Promise.reject(error.message || error);
  }
}
