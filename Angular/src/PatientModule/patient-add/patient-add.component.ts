import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-patient-add',
  templateUrl: './patient-add.component.html',
  styleUrls: ['./patient-add.component.css'],
})

export class PatientAddComponent implements OnInit {

  ngOnInit(): void {
  }

  Patients : Array<Patient> = new Array<Patient>()
  cPatient : Patient = new Patient()
  cProblem : Problem = new Problem()
  cTreatment : Treatment = new Treatment()
  list : any;

  formGroup: FormGroup = null;
  formGroup2: FormGroup = null;
  formGroup3: FormGroup = null;

  constructor(private http: HttpClient)
  { 
    var builder = new FormBuilder();
    this.formGroup = builder.group({});
    this.formGroup.addControl("PName", new FormControl("", Validators.required));
    var valarr = [];
    valarr.push(Validators.required);
    valarr.push(Validators.pattern("^[0-9]{10}$"));
    this.formGroup.addControl("PPhone", new FormControl("", valarr));
    
    var builder2 = new FormBuilder();
    this.formGroup2 = builder2.group({});
    this.formGroup2.addControl("PrName", new FormControl("", Validators.required));

    var builder3 = new FormBuilder();
    this.formGroup3 = builder3.group({});
    this.formGroup3.addControl("TName", new FormControl("", Validators.required));
    var valarr2 = [];
    valarr2.push(Validators.required);
    valarr2.push(Validators.pattern("^([0-1][-]){2,3}[0-1]$"));
    this.formGroup3.addControl("TDosage", new FormControl("", valarr2));
  }
  
  AddPatient()
  {
    const obj : Patient = this.cPatient;
    this.Patients.push(obj);
    this.cPatient = new Patient();
    this.cProblem = new Problem();
    this.cTreatment = new Treatment();
  }

  AddProblem()
  {
    const obj : Problem = this.cProblem;
    this.cPatient.Problems.push(obj); 
  }

  AddTreatment()
  {
    const obj : Treatment = this.cTreatment;
    this.cProblem.Treatments.push(this.cTreatment);
  }

  AddToDatabase() : void
  {
    var observable = this.http.post("https://localhost:44330/api/PatientAPI/", this.Patients);
    observable.subscribe(res => this.success(res), res => this.error(res));
  }

  error(res: any)
  {
    console.log(res);
  }

  success(res: any)
  {
    console.log(res);
  }
}

export class Patient
{
  Name : string 
  Phone : string
  Address : string 
  Problems : Array<Problem> = new Array<Problem>()

  constructor() { }
}

export class Problem
{
  Name : string
  Description : string
  Treatments : Array<Treatment> = new Array<Treatment>();
  formGroup2: FormGroup = null;

  constructor() { }
}

export class Treatment
{
  Name : string
  Dosage : string
  formGroup3: FormGroup = null;

  constructor() { }
}
