

export interface AdsPagination{

    searchObject:{
        isAvailable:boolean|null;
    },
    pageNumber: number,          //current page
    pageSize: number,            //items per page
    sortBy: string,
    sortDirection: string 
}