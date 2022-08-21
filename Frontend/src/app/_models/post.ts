import { PostImage } from "./postImage";

export interface Post{
    
postId:number;
title:string;
description:string;
createdAt:Date;
price:number;
isNew:boolean;
isNegotiable:boolean;
isAvailable:boolean;
categoryId:number;
subCategoryId:number;
locationId:number;
userID:number;
subCategoryName:string;
cityName:string;
fullName:string;
phoneNumber:number;
aboutMe: string,
minPrice:number;
maxPrice:number;
postImages: PostImage[];
}
