import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { Department } from '../models/index';
import { Settings } from '../settings';

@Injectable()

export class DepartmentService {
  constructor(private http: Http) {
  }
  private baseUrl = Settings.DepartmentsApiUrl;
  getDepartments(): Promise<Department[]> {
    return this.http.get(this.baseUrl)
    .toPromise()
    .then(responce => responce.json())
    .catch(this.handleError);
  }
  private handleError(error:any): Promise<any> {
    console.error('An error has occured', error);
    return Promise.reject(error.message || error);
  }
}
