import { Component, OnInit } from '@angular/core';
import { Department, User } from './models/index';
import { NgForm } from '@angular/forms';
import { DepartmentService, UserService } from './services/index';

@Component({
    selector: 'app',
    templateUrl: 'app.component.html',
    styleUrls: ['app.component.css']
})

export class AppComponent implements OnInit {
  departments: Department[];
  users:User[];
  choosenUser:User = null;
  storedUser:User = null;
  isChoosen:boolean = false;
  constructor(private departmentService:DepartmentService, private userService:UserService){

  }
  ngOnInit(){
   Promise.all(
     [this.departmentService.getDepartments(),this.userService.getUsers()])
      .then(values =>{
        this.departments = values[0];
        this.users = values[1];
        for(let user of this.users)
        {
          user.DepartmentTitle = this.departments.find(d => d.Id === user.DepartmentId).Title;
        }
      })
  }

  AddUser(form: NgForm)
  {
    let newUser: User = new User();
    newUser.UserName = form.value.username;
    newUser.DepartmentId = this.departments.find(d => d.Title === form.value.department).Id;
    this.userService.addUser(newUser)
    .then(user => {
      user.DepartmentTitle = form.value.department;
      this.users.push(user);
    });
  }

  ChooseUser(user: User){
    this.choosenUser = user;
  }

  isSelected(user: User): boolean {
		if(!this.choosenUser) {
			return false;
		}
		return this.choosenUser.Id ===  user.Id ? true : false;
	}

  DeleteUser(){
	  if(!this.choosenUser) {
			return false;
	   }
     this.userService.deleteUser(this.choosenUser.Id)
     .then(() => {
       this.users = this.users.filter(user => user !== this.choosenUser);
  	   this.choosenUser = null;
     });
   }

  EditUser(form: NgForm)
  {
    this.choosenUser.DepartmentId = this.departments.find(d => d.Title === this.choosenUser.DepartmentTitle).Id;
    this.userService.editUser(this.choosenUser);
  }

  StoreUser()
  {
    this.storedUser = new User();
    this.storedUser.UserName = this.choosenUser.UserName;
    this.storedUser.DepartmentId = this.choosenUser.DepartmentId;
    this.storedUser.DepartmentTitle = this.choosenUser.DepartmentTitle;
  }

  RestoreUser(){
    this.choosenUser.UserName = this.storedUser.UserName;
    this.choosenUser.DepartmentId = this.storedUser.DepartmentId;
    this.choosenUser.DepartmentTitle = this.storedUser.DepartmentTitle;
    this.storedUser = null;
  }
}
