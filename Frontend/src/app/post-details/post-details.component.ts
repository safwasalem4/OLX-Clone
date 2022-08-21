import { isNgTemplate } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../_models/post';
import { AccountService } from '../_services/account.service';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent implements OnInit {

  id: any;

  constructor(private PostService:PostService,private AccountService:AccountService,private route:ActivatedRoute) 
  { 
    this.id = this.route.snapshot.paramMap.get("id");
  }

  ngOnInit(): void {
    this.loadPost();
     
  }

  Post:Post;
  numberOfImages:number;

  loadPost(){
   this.PostService.getPost(this.id).subscribe(p=>{
     this.Post=p;
     this.numberOfImages = this.Post.postImages.length;
     console.log(this.numberOfImages);
    });

  }


  imagepath:any;
  createImgPath(post: any,i:number){ 
    this.imagepath = (post.postImages[i].imageURL);
    if(!this.imagepath.includes("webp"))
    {
      const re = /\\/gi;
      let newpath = this.imagepath.replace(re, "/");
      let path = `https://localhost:44355/${newpath}`;
      return path;
    } else 
    {
      return this.imagepath;
    } 
  }

  calculatePostDays(createdAt){

    let Today = new Date();
    let mydate=new Date(createdAt);
    let difference = Today.getTime() - mydate.getTime();
    let TotalDays = Math.ceil(difference / (1000 * 3600 * 24));
    return TotalDays;
 
   }

  show:boolean=false
  showNumber(){
    this.show=true;
  }



  Fav:boolean=false;

  FavPosts:object[]=[];


  favorite(i:object){
    this.Fav=!this.Fav;

    if(this.Fav==true){
      this.FavPosts.push(i)
      console.log(this.FavPosts);
    }
    else{
      this.FavPosts.pop()
      console.log(this.FavPosts);
    }
   
  }


  // _________________________Manually_____________________________________

//  Item:any;
 

//   getitem(){
//     this.Item=this.PostService.getItemsMaually();
//     console.log("from get details");
//   }



}
