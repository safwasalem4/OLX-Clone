import { Component, TemplateRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { Token } from '../_models/token';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-profile-edit',
  templateUrl: './profile-edit.component.html',
  styleUrls: ['./profile-edit.component.css']
})
export class ProfileEditComponent implements OnInit {
  //Token: string;
  @ViewChild("ProfileEditForm") editForm: NgForm;
  changeModel: any = {};
  model: User = {
    userName: "", firstName: "", lastName: "", aboutMe: "", phone: null, email: "",
    password: '',
    confirmPassword: ''
  };  //The model containing data to be edited
  modalRef?: BsModalRef; //for the ngx-bootstrap modal
  confirm : boolean;

  constructor(private modalService: BsModalService, private router: Router, private accountService: AccountService, private toast: ToastrService, private postService: PostService) {
    //this.accountService.currentUser$.pipe(take(1)).subscribe(token => this.Token=token);
  }

  openModal(template: TemplateRef<any>) {   //For ngx modal
    this.modalRef = this.modalService.show(template);
  }


  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    this.accountService.getUser().subscribe(user => this.model = user);
  }

  update() {
    if (this.model.userName == "" || this.model.phone == null || this.model.email == "" || this.model.firstName == "" || this.model.lastName == "") {
      this.toast.error("Please fill all required fields");
    }
    else {
      this.accountService.update(this.model).subscribe(() => {
        this.toast.success("Profile updated successfully");
        this.editForm.reset(this.model);
      })
    }
  }

  delete() {
    this.accountService.delete().subscribe(() => {
      this.toast.success("Profile deleted successfully");
      this.router.navigateByUrl("/welcome");
      this.accountService.logout();
      this.modalRef?.hide();
    });
  }

  updatePassword() {
    this.postService.updatePassword(this.changeModel).subscribe({
      next: (response : Token) => {
        let model: any={username: this.model.userName,password: this.changeModel.new};
        this.toast.success("Password changed successfully");
        localStorage.setItem("user",JSON.stringify(response.token));
        this.accountService.currentUserSource.next(response.token);
        // this.accountService.logout();
        // this.accountService.login(model).subscribe({
        //   next: () => {
        //     this.toast.success(`Welcome ${this.model.userName}`);
        //     this.router.navigateByUrl("/home");
        //   },
        //   error: error => {
        //     console.log(error);
        //     this.toast.error(error.error.message);
        //   }
        // });
        // console.log(response);
        // this.route.navigateByUrl("/home");
        // this.cancel();
      },
      error: error => {
        this.toast.error("Enter the correct old password");
      }
    })
  }

  compare() {
    if(this.changeModel.newPassword==this.changeModel.confirmNewPassword) {
      this.confirm= true;
    }
    else {
      this.confirm= false;
    }
  }
}


