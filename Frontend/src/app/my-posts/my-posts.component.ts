import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Post } from '../_models/post';
import { PostService } from '../_services/post.service';
import { AdsPagination } from'../_models/AdsPagination';


@Component({
  selector: 'app-my-posts',
  templateUrl: './my-posts.component.html',
  styleUrls: ['./my-posts.component.css']
})
export class MyPostsComponent implements OnInit {
  // available: boolean=true;
  // unavailable: boolean;

  AvailablePosts: Post[];
  UnvailablePosts: Post[];

  AllPosts:Post[];
  totalRecords:number;
 
  


  Adsfilter:AdsPagination={
    searchObject:{
  
      isAvailable:null
      
    },
    pageNumber:1,
    pageSize:20,
    sortBy:"createdAt",
    sortDirection:"dec"
  }

  constructor(private http: HttpClient, private postService: PostService) { }

  ngOnInit(): void {
     this.getAvAds();
     this.getUnAvAds();
     this.getAllMyAds()
  }

  
  getAvAds() {
    this.postService.getMyAvailableAds().subscribe(posts => this.AvailablePosts=posts);
  }

  getUnAvAds() {
    this.postService.getMyUnvailabaleAds().subscribe(posts => this.UnvailablePosts=posts);
  }

  // alltrue() {
  //   this.available = this.unavailable = true;
  // }

  

  getAllMyAds(){
    this.postService.getAllMyAds(this.Adsfilter).subscribe((response: any) => {
      console.log(response);
      this.AllPosts = response.results;
      this.totalRecords=response.totalRecords;
    })
  }

  getAll(){
    this.Adsfilter.searchObject.isAvailable=null;
    this.getAllMyAds();
    
  }

  getAvailable(){
    this.Adsfilter.searchObject.isAvailable=true;
    this.getAllMyAds();
  }

  getUnAvailable(){
    this.Adsfilter.searchObject.isAvailable=false;
    this.getAllMyAds();
  }
  

  imagepath:any;
  createImgPath(post: any){ 
    this.imagepath = (post.postImages[0].imageURL);
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

  pageChanged(event:any){
    this.Adsfilter.pageNumber=event.page;
    this.getAllMyAds();
  }

  calculatePostDays(createdAt){

    let Today = new Date();
    let mydate=new Date(createdAt);
    let difference = Today.getTime() - mydate.getTime();
    let TotalDays = Math.ceil(difference / (1000 * 3600 * 24));
    return TotalDays;
 
   }


 

  // pageChanged(event:any){
  //   this.Adsfilter.pageNumber=event.page;
  //   this.loadPosts();
  // }

}
