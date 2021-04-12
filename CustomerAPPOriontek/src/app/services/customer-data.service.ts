import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerDataService {

  constructor(private http: HttpClient) { 
    
  }

  GetCustomerById(id) {
    return this.http.get<any>(`${environment.apiUrl}GetCustomerById/${id}`);
  }

  GetAllCustomers() {
    return this.http.get<any>(`${environment.apiUrl}GetAllCustomers`);
  }

  SaveCustomer(Data){
      return this.http.post<any>(`${environment.apiUrl}SaveCustomer`, Data);
  }

  DeleteCustomer(id){
      return this.http.delete<any>(`${environment.apiUrl}DeleteCustomer/${id}`);
  }
}
