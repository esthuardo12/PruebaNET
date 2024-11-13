import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProductoGet,IProductoSet,urlProductos,IRegistro } from './Producto';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductosService {
  constructor(private http: HttpClient) { }

  GetProductByID(id:string):Observable<IProductoGet>{
    return this.http.get<IProductoGet>(urlProductos+id);
  }
  SetProduct(producto:IProductoSet):Observable<IRegistro>{
    return this.http.post<IRegistro>(urlProductos,producto);
  }
  UpdateProduct(producto:IProductoSet,id:string):Observable<IRegistro>{
    return this.http.put<IRegistro>(urlProductos+id,producto);
  }

}
