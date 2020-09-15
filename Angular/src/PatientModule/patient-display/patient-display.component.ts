import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-patient-display',
  templateUrl: './patient-display.component.html',
  styleUrls: ['./patient-display.component.css']
})
export class PatientDisplayComponent {

  myData : any;

  constructor(private http: HttpClient) 
  { 
    this.http.get("https://localhost:44330/api/PatientAPI/", { responseType: "json"})
    .subscribe(res => {
      this.myData = res;
    });
    var obj = JSON.parse(this.myData);
    console.log(obj);
  }
}