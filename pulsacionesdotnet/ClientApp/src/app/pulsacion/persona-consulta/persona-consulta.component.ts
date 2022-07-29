import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-consulta',
  templateUrl: './persona-consulta.component.html',
  styleUrls: ['./persona-consulta.component.css']
})
export class PersonaConsultaComponent implements OnInit {
  personas: Persona[];
  constructor(private personaServices :PersonaService) { }

  ngOnInit(): void {
    this.get();
  }
  get(){
    
    this.personaServices.get().subscribe(result => {
      this.personas = result;
    });
    console.log(this.personas);
  }
}
