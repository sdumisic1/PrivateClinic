import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44325/api/Patients/'

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public getPatients() {
    return this.http.get<any[]>(this.accessPointUrl , {});
  }
}
