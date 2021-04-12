import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { CustomerModel } from 'src/app/Models/customer.model';
import { CustomerDataService } from 'src/app/services/customer-data.service';
import { CustomerPage } from '../customer/customer.page';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.page.html',
  styleUrls: ['./customer-list.page.scss'],
})
export class CustomerListPage implements OnInit {
customers: CustomerModel[] = [];
  filteredCustomers: CustomerModel[] = [];
  busqueda: string = '';
  
  constructor(private modalCtrl: ModalController, private _customerDataService : CustomerDataService, private router: Router) { }

ngOnInit() {
    this.getAllCustomer();
  }

  getAllCustomer(){
      this._customerDataService.GetAllCustomers().subscribe(resp => {
        this.customers = resp;
        this.filteredCustomers = resp;
    });
  }

  async create(){
    var customer = new CustomerModel();
    
    const modal = await this.modalCtrl.create({
      component: CustomerPage,
      componentProps: { 
         customer 
       }
    });

    await modal.present();
  }

  search(ev){
   var name = String(ev.detail.value).toLowerCase();   
   this.filteredCustomers = [];

   this.customers.forEach(element => {
     if (element.name.toLowerCase().includes(name)){
       this.filteredCustomers.push(element);
     }
   });

      if (name.length == 0){
     this.filteredCustomers = this.customers;
   }
  }

  async edit(customer: CustomerModel){

  const modal = await this.modalCtrl.create({
      component: CustomerPage,
      componentProps: { 
         customer 
       }
    });

    await modal.present();

    const { data } = await modal.onWillDismiss();

    if ((data) && (data.accion=='modificar')){
      var index = this.customers.findIndex(p => p.id == data.id);
      this.customers[index] = data;
    } else {
      this.customers = data.customers;
      this.filteredCustomers = data.customers;
    }


  }

}
