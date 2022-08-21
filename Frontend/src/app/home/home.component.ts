import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;

  constructor(private accountService: AccountService, private route: Router) { }

  ngOnInit(): void {
    this.navigate();

  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }


  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

  navigate() {
    if(localStorage.getItem("user")) {
      this.route.navigateByUrl("/home");
    }
  }
  // this.accountService.currentUser$.pipe(
  //   map((user) => {
  //     if (user) {
  //       this.route.navigateByUrl("/home");
  //     }
  //   })
  // )

}

