import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Admission } from './models/Admission';

@Injectable({
  providedIn: 'root'
})
export class AdmissionService {

  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44325/api/admissions/'
  private admissionId: number;


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public getAdmissions() {
    return this.http.get<any[]>(this.accessPointUrl + 'details/', {});
  }

  public getAdmissionById(id: number) {
    return this.http.get<Admission>(this.accessPointUrl + id, {});
  }

  public deleteAdmission(id: number) {
    return this.http.delete(this.accessPointUrl +id, {});
  }

  public setAdmissionId(id: number) {
    this.admissionId = id;
  }

  public getAdmissionId() {
    return this.admissionId;
  }


  public getAdmissionDetailsById() {
    return this.http.get<Admission>(this.accessPointUrl + 'details/' + this.admissionId, {});
  }

  public postAdmission(admission) {
    return this.http.post<string>(this.accessPointUrl + 'createAll', admission);
  }

  public getAdmissionsBySearchQuery(start, end) {
    let params1 = new HttpParams();
    params1 = params1.append("startDate", start);
    params1 = params1.append("endDate", end);

    return this.http.get<any[]>(this.accessPointUrl + 'search', { params: params1 });
  }

  public updateAdmission(admission) {
    return this.http.put<any>(this.accessPointUrl + this.admissionId, admission);
  }

}
