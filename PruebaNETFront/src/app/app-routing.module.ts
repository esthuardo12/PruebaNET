import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistroComponent } from './pages/registro/registro.component';
import { ObtenerRegistroComponent } from './pages/obtener-registro/obtener-registro.component';

const routes: Routes = [{path:'',redirectTo:'/registro', pathMatch:'full'},
  {path: 'registro',component:RegistroComponent},
  {path: 'obtener-registro',component:ObtenerRegistroComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
