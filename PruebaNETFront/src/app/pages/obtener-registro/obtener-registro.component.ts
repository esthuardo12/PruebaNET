import { Component, EventEmitter, Input, Output } from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import { ProductosService } from '../../services/productos.service';
import { IProductoGet,IProductoSet } from '../../services/Producto';

@Component({
  selector: 'app-obtener-registro',
  templateUrl: './obtener-registro.component.html',
  styleUrl: './obtener-registro.component.css'
})
export class ObtenerRegistroComponent {
  mostrarRegistro:Boolean=false;
  idChange:string="";
  DiscountChange:string="";
  FinalPriceChange:string="";
  nombreChange:string="";
  statusChange:number=1;
  stockChange:number=0;
  descripcionChange:string="";
  priceChange:number=0;
  idActual:string="";
  all:boolean=true;
  registroForm = this.formBuilder.group({
    Name:['',Validators.required],
    Status:[1,Validators.required],
    Stock:[0,[Validators.required,Validators.min(0)]],
    Description:['',Validators.required],
    Price:[0,[Validators.required,Validators.min(1)]]
  });
  getForm = this.formBuilder.group({
    id:[0,[Validators.required,Validators.min(1)]]
  });
  constructor(private productService:ProductosService,private formBuilder: FormBuilder){}

  get Name(){
    return this.registroForm.controls.Name;
  }
  get Status(){
    return this.registroForm.controls.Status;
  }
  get Stock(){
    return this.registroForm.controls.Stock;
  }
  get Description(){
    return this.registroForm.controls.Description;
  }
  get Price(){
    return this.registroForm.controls.Price;
  }

  get id(){
    return this.getForm.controls.id;
  }

  getProducto(){
    if(this.getForm.valid){
      this.idActual=this.getForm.value.id!.toString()
      this.productService.GetProductByID(this.idActual).subscribe({
        next: (userData)=>{
          console.log(userData);
          this.nombreChange=userData.Name;
          this.descripcionChange=userData.Description;
          this.priceChange=parseFloat(userData.Price);
          this.statusChange=userData.StatusName=="Inactive"?1:2
          this.stockChange=parseFloat(userData.Stock);
          this.idChange=this.idActual;
          this.DiscountChange=userData.Discount;
          this.FinalPriceChange=userData.FinalPrice;
          this.mostrarRegistro=true;
        },
        error: (errorData)=>{
          console.error(errorData);
        },
        complete:()=>{
          console.log("Get completo");
        }
      })
    }else{
      this.getForm.markAllAsTouched();
    }
  }

  modificarProducto(){
    if(this.registroForm.valid){
      this.productService.UpdateProduct(this.registroForm.value as IProductoSet,this.idActual).subscribe({
        next: (userData)=>{
          console.log(userData);
          if(userData.isSuccess){
            console.log("Cambiando el valor de correcto")
            alert("Producto modifiado correctamente");
          }else{
            alert(userData.mensaje);
          }
        },
        error: (errorData)=>{
          console.error(errorData);
        },
        complete:()=>{
          console.log("Registro completo");
        }
      });

    }else{
      this.registroForm.markAllAsTouched();
    }
  }
}
