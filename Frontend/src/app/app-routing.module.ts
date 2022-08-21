import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPostComponent } from './add-post/add-post.component';
import { ErrorComponent } from './error/error.component';
import { HomePageComponent } from './home-page/home-page.component';
import { HomeComponent } from './home/home.component';
import { MyPostsComponent } from './my-posts/my-posts.component';
import { PostDetailsComponent } from './post-details/post-details.component';
import { PostEditComponent } from './post-edit/post-edit.component';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: "", component: HomeComponent },
  {path: "",
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: "profile", component: ProfileEditComponent },
      { path: "home", component: HomePageComponent },
      { path: "MyPosts", component: MyPostsComponent },
      // { path: "Welcome", component: HomeComponent },
      { path: "PostEdit/:id", component: PostEditComponent },
      { path: "Addpost", component: AddPostComponent },
      { path: "Postdetails/:id", component: PostDetailsComponent },
      
    ]
  },
  { path: "**", component: ErrorComponent, pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
