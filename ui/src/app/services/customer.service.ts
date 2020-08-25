import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private httpClient: HttpClient) { }

  public GetCustomers(): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>('http://localhost:63235/customer');
  }

  public GetCustomer(id: number): Observable<Customer> {
    return this.httpClient.get<Customer>(`http://localhost:63235/customer/${id}`);
  }

  public CreateCustomer(customer: Customer): Promise<object> {
    return this.httpClient.post('http://localhost:63235/customer', customer).toPromise();
  }
}
