import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdmissionService } from '../admission.service';
import { ReportService } from '../report.service';
import { StaffService } from '../staff.service';

@Component({
  selector: 'app-update-report',
  templateUrl: './update-report.component.html',
  styleUrls: ['./update-report.component.css']
})
export class UpdateReportComponent implements OnInit {
  public report: any;
  public id: any;
  constructor(private reportService: ReportService, private admissionService: AdmissionService, private router: Router, private toaster: ToastrService) { }

  ngOnInit() {

    this.reportService.getReport()
      .subscribe(result => {
        this.report = result;
      }, error => console.error(error));
    console.log(this.report);
  }

  public onClickSubmit() {
    this.reportService.updateReport(this.report)
      .subscribe(result => {
        this.toaster.success('Uspjesno azuriran nalaz');
        this.router.navigate(['/admission']);
      }, error => console.error(error));
  }
 
}
