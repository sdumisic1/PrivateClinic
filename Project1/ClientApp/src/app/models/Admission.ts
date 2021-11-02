export class Admission {
  AdmissionId: number;
  DateAndTime: Date;
  IsEmergency: boolean;
  PatientId: number;
  NameSurname: string;
  StaffId: number;
  StaffName: string;
  StaffSurname: string;
  StaffCode: string;
  ReportId: number;
}

export class AdmissionToCreate {
  AdmissionId: number;
  DateAndTime: Date;
  IsEmergency: boolean;
  PatientId: number;
  StaffId: number;
  ReportId: number;
}
