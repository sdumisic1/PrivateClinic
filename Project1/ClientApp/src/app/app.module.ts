import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DatePipe } from '@angular/common';
import { AgGridModule } from 'ag-grid-angular';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AdmissionComponent } from './admissions/admission.component';
import { AdmissionDetailsComponent } from './admission-details/admission-details.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { UpdateReportComponent } from './update-report/update-report.component';
import { UpdateAdmissionDetailsComponent } from './update-admission-details/update-admission-details.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AdmissionComponent,
    FetchDataComponent,
    AdmissionDetailsComponent,
    UpdateReportComponent,
    UpdateAdmissionDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AgGridModule.withComponents([]),
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'admission', component: AdmissionComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'admission-details', component: AdmissionDetailsComponent },
      { path: 'update-admission-details', component: UpdateAdmissionDetailsComponent },
      { path: 'update-report', component: UpdateReportComponent }
    ]),
   
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
