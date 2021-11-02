import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import { AdmissionService } from '../admission.service';
import { Admission, AdmissionToCreate } from '../models/Admission';
import { Patients } from '../models/Patients';
import { Staff } from '../models/Staff';
import { PatientService } from '../patient.service';
import { StaffService } from '../staff.service';

@Component({
  selector: 'app-update-admission-details',
  templateUrl: './update-admission-details.component.html',
  styleUrls: ['./update-admission-details.component.css']
})
export class UpdateAdmissionDetailsComponent implements OnInit {
  public admissions: any;
  public doctors: Staff[];
  public patients: Patients[];
  public value = moment(new Date()).format('YYYY-MM-DD');


  constructor(private staffService: StaffService, private patientService: PatientService, private admissionService: AdmissionService, private router: Router, private toaster: ToastrService) { }

  ngOnInit() {
    this.admissionService.getAdmissionDetailsById()
      .subscribe(result => {
        this.admissions = result;
      }, error => console.error(error));
    console.log(this.admissions);
    this.staffService.getDoctors()
      .subscribe(result => {
        this.doctors = result;
        console.log(result);
      }, error => console.error(error));
    this.patientService.getPatients()
      .subscribe(result => {
        this.patients = result;
      }, error => console.error(error));
  }

  public onClickSubmit() {
    this.admissionService.updateAdmission(this.admissions)
      .subscribe(result => {
        this.toaster.success('Uspjesno azurirana evidencija');
        this.router.navigate(['/admission']);
      }, error => console.error(error));
  }

}
