import { Component, OnInit } from '@angular/core';
import { Customer } from '../models/customer.model';
import { CustomerType } from '../models/customerType';
import { CustomerService } from '../services/customer.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  public customers: Customer[];
  public CustomerType = CustomerType;
  public CustomerTypeValues: any = Object.values(CustomerType).filter(
    (type) => !isNaN(type as any) && type !== 'values');

  public newCustomer: Customer = {
    id: null,
    name: null,
    type: null
  };
  constructor(private customerService: CustomerService) {}

  ngOnInit() {
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
  }

  public createCustomer(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.customerService.CreateCustomer(this.newCustomer).then(() => {
        this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
      });
    }
  }

}
