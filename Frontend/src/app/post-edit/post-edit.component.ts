import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from '../_models/post';
import { AccountService } from '../_services/account.service';
import { PostService } from '../_services/post.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.css']
})
export class PostEditComponent implements OnInit {
  @ViewChild("PostEditForm") editForm: NgForm;
  id: any;
  model: Post={
    postId: 0,
    title: '',
    description: '',
    createdAt: new Date(),
    price: 0,
    isNew: false,
    isNegotiable: false,
    isAvailable: false,
    categoryId: 0,
    subCategoryId: 0,
    locationId: 0,
    userID: 0,
    subCategoryName: '',
    cityName: '',
    fullName: '',
    phoneNumber: 0,
    aboutMe:'',
    minPrice: 0,
    maxPrice: 0,
    postImages: []
  }
  modalRef?: BsModalRef; //for the ngx-bootstrap modal
  


  constructor(private postService:PostService,private accountService:AccountService,private route:ActivatedRoute,private modalService: BsModalService,private toast: ToastrService, private router: Router) {
    this.id = this.route.snapshot.paramMap.get("id");
   }

  ngOnInit(): void {
    this.getPost();
  }

  getPost() {
    this.postService.getPost(this.id).subscribe(post => this.model=post);
  }

  openModal(template: TemplateRef<any>) {   //For ngx modal
    this.modalRef = this.modalService.show(template);
  }

  deletePost() {
    this.postService.deletePost(this.model.postId).subscribe({
      next: () => {
        this.router.navigateByUrl("/MyPosts");
        this.toast.success("Post deleted successfully");
        this.modalRef?.hide();
      },
      error: error => {
        this.router.navigateByUrl("/MyPosts");
        this.toast.success("Post deleted successfully");
        this.modalRef?.hide();
      }
    });
  }

  updatePost() {
    this.postService.updatePost(this.model.postId,this.model).subscribe(() => {
      this.toast.success("Post updated successfully");
      this.editForm.reset(this.model);
    })
  }

}
