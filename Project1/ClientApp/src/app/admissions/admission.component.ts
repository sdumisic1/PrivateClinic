import { Component, Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AdmissionService } from '../admission.service';
import { Admission } from '../models/Admission';
import { ColDef } from 'ag-grid-community';
import { ToastrService } from 'ngx-toastr';
import { ReportService } from '../report.service';



@Component({
  selector: 'app-admission-component',
  templateUrl: './admission.component.html'
})
@Injectable({ providedIn: 'root' })
export class AdmissionComponent {
  public admissions: any[];
  public startDate: any;
  public endDate: any;

  constructor(private admissionService: AdmissionService, private reportService: ReportService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.admissionService.getAdmissions()
      .subscribe(result => {
        this.admissions = result;
      }, error => console.error(error));
  }

  public DeleteAdmission(id: number) {
   
    this.admissionService.deleteAdmission(id).subscribe(() => {
      const deletedContrat = this.admissions.findIndex(x => x.admissionId == id);
      this.admissions.splice(deletedContrat, 1);
    });

  }

  public GetAdmissions() {
    this.startDate = "";
    this.endDate = "";
    this.admissionService.getAdmissions()
      .subscribe(result => {
        this.admissions = result;
      }, error => console.error(error));
  }

  public CreateNew() {
     this.router.navigate(['/admission-details']);
  }

  public SetAdmissionDetailsId(id: number) {
    this.admissionService.setAdmissionId(id);
    this.router.navigate(['/update-admission-details']);
  }

  public GetSearchResults() {
    if (this.startDate && this.endDate) {
      this.admissionService.getAdmissionsBySearchQuery(this.startDate, this.endDate).subscribe(result => {
        this.admissions = result;
      }, error => console.error(error));
    }
    else {
      this.toastr.error('Potrebno je selektovati start i end datuma');
    }
   
  }

  public UpdateExistingReport(id: number) {
    this.reportService.setReportId(id);
    this.router.navigate(['/update-report']);
  }
}

