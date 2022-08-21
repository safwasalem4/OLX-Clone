import { Component, OnInit, Output, EventEmitter, ViewChild, ElementRef} from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Token } from '../_models/token';
import { AccountService } from '../_services/account.service';
import { PostService } from '../_services/post.service';
import { Location } from '../_models/location';



@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  currentUser$: Observable<Token>;

 

  constructor(public postService:PostService, public accountService: AccountService, private router: Router, private toast: ToastrService) {
    
   }

  ngOnInit(): void {

  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: () => {
        this.toast.success(`Welcome ${this.model.username}`);
        this.router.navigateByUrl("/home");
      },
      error: error => {
        console.log(error);
        this.toast.error(error.error.message);
      }
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/");
    this.model.username="";
    this.model.password="";
  }

  



}
