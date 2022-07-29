import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { error } from 'selenium-webdriver';
import { Persona } from '../Pulsacion/models/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  baseUrl: string;
  constructor( 
    private http:HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }
  get():Observable <Persona[]>{
    /*let personas: Persona[] = [];
    personas = JSON.parse(localStorage.getItem('datos'));*/
    return this.http.get<Persona[]>(this.baseUrl +'api/Persona').pipe(
      tap(_ => console.log('Datos registrado')),
      catchError(error =>{
        console.log("error al registrar")
        return of(error as Persona[])
      })
      );
      
  }
  post(persona :Persona): Observable<Persona>{
    return this.http.post<Persona>(this.baseUrl + 'api/Persona', persona)
    .pipe(
      tap(_ => console.log('registrar')),
        catchError(error =>{
          console.log("error al registrar")
          return of(persona)
      })
    );
  }
   /* let personas :Persona[]=[];
    let storageDatos = localStorage.getItem('datos');
    if(this.get() != null){
      personas = JSON.parse(storageDatos);
    }
    personas.push(persona);
    localStorage.setItem('datos',JSON.stringify(personas));
    return of(persona).pipe(
      tap(_ => console.log('Datos Guardados')),
      catchError(error => {
        console.log("error al registrar");
        return of(persona);
      })
    );
  }*/
}
