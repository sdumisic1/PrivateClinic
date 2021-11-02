import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  public reportId: any;
  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44325/api/reports/'

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }


  public setReportId(id: number) {
    this.reportId = id;
  }

  public getReportId() {
    return this.reportId;
  }


  public getReport() {
    return this.http.get<any>(this.accessPointUrl + this.reportId, {});
  }

  public updateReport(report) {
    return this.http.put<any>(this.accessPointUrl + this.reportId, report);
  }
}
