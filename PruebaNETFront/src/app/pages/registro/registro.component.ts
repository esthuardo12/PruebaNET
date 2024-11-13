import { Component } from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import { ProductosService } from '../../services/productos.service';
import { IProductoSet } from '../../services/Producto';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.css'
})
export class RegistroComponent {
  registroForm = this.formBuilder.group({
    Name:['',Validators.required],
    Status:[1,Validators.required],
    Stock:[0,[Validators.required,Validators.min(0)]],
    Description:['',Validators.required],
    Price:[0,[Validators.required,Validators.min(1)]]
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

  crearProducto(){
    let correcto:boolean=false;
    if(this.registroForm.valid){
      this.productService.SetProduct(this.registroForm.value as IProductoSet).subscribe({
        next: (userData)=>{
          console.log(userData);
          if(userData.isSuccess){
            correcto=true;
            console.log("Cambiando el valor de correcto")
          }else{
            alert(userData.mensaje);
          }
        },
        error: (errorData)=>{
          console.error(errorData);
        },
        complete:()=>{
          console.log("Registro completo");
          if(correcto){
            this.registroForm.reset();
          }
        }
      });

    }else{
      this.registroForm.markAllAsTouched();
    }
  }
}
