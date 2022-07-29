import { DecimalPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {
  persona: Persona;
  resultado ="";


  constructor(private personaServices : PersonaService) { }

  ngOnInit(): void {
  this.persona = new Persona();
  }

  registrarPersona(){
    this.calcularPulsacion();
    this.resultado = "su pulsacion es :"+ this.persona.pulsacion;
    this.personaServices.post(this.persona).subscribe(p => {
      if(p != null){
        alert("Se registro con exito su pulsacion");
        this.persona = p;        
      }
    });
  }

  calcularPulsacion(){
      if(this.persona.sexo =='M'){
          this.persona.pulsacion = (210-this.persona.edad)/10
      }  
       this.persona.pulsacion = (220-this.persona.edad)/10
  }
}
