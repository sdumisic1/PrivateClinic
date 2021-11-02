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
  selector: 'app-admission-details',
  templateUrl: './admission-details.component.html',
  styleUrls: ['./admission-details.component.css']
})
export class AdmissionDetailsComponent implements OnInit {
  public doctors: Staff[];
  public patients: Patients[];
  public newAdmission: any = {};
  public value = moment(new Date()).format('YYYY-MM-DD');

  constructor(private staffService: StaffService, private patientService: PatientService, private admissionService: AdmissionService, private router: Router, private toaster: ToastrService) { }

  ngOnInit() {
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
    this.newAdmission.dateAndTimeForReport = moment(new Date()).format('YYYY-MM-DD');
    console.log(this.newAdmission);
    this.admissionService.postAdmission(this.newAdmission)
      .subscribe(result => {
        this.toaster.success('Uspjesno kreirana evidencija');
        this.router.navigate(['/admission']);
      }, error => console.error(error));
  }

}
