import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonaConsultaComponent } from './Pulsacion/persona-consulta/persona-consulta.component';
import { PersonaRegistroComponent } from './Pulsacion/persona-registro/persona-registro.component';

const routes: Routes = [
  {
    path: '',
    component: PersonaRegistroComponent, 
    pathMatch: 'full'
  },
  {
    path: 'personaRegistro',
    component: PersonaRegistroComponent,
  },
  {
    path: 'personaConsulta',
    component: PersonaConsultaComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
