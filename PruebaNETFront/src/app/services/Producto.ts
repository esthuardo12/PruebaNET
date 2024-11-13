export interface IProductoGet{
    ProductID:string;
    Name:string;
    StatusName:string;
    Stock:string;
    Description:string;
    Price:string;
    Discount:string;
    FinalPrice:string;
}

export interface IProductoSet{
    Name:string;
    Status:number;
    Stock:number;
    Description:string;
    Price:number;
}

export interface IRegistro{
    isSuccess:string;
    mensaje:string;
}

export var urlProductos='https://localhost:7058/api/Productos/'