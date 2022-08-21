import { SubCategory } from "./subCategory";

export interface Category {
    categoryID: number;
    categoryName: string;
    subCategories: SubCategory[];
}