import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Staff } from './models/Staff';


@Injectable({
  providedIn: 'root'
})
export class StaffService {

  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44325/api/MedicalStaffs/'

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public getDoctors() {
    return this.http.get<Staff[]>(this.accessPointUrl + 'doctors', {});
  }

  public getAllStaff() {
    return this.http.get<Staff>(this.accessPointUrl, {});
  }
}
