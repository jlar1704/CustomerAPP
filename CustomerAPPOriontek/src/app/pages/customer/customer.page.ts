import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { CustomerModel } from 'src/app/Models/customer.model';
import { CustomerDataService } from 'src/app/services/customer-data.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.page.html',
  styleUrls: ['./customer.page.scss'],
})
export class CustomerPage implements OnInit {
  customerfg: FormGroup;
  @Input() customer: CustomerModel;
  
  constructor(private fb: FormBuilder, private modalCtrl: ModalController, private _customerDataService: CustomerDataService, private router: Router) { }

  ngOnInit() {
    this.InitFormBuildData();    
  }
  
  deleteCustomer(){
    this._customerDataService.DeleteCustomer(this.customer.id).subscribe(resp => {
      this.modalCtrl.dismiss({
        'name': this.customer.name,
        'id': this.customer.id,
        'rnc': this.customer.rnc,
        'customerAddress': this.customerAddreses,
        'accion': 'eliminar',
        'customers': resp
      });
    });

  }

  InitFormBuildData(){
  this.customerfg = this.fb.group({
      id: [this.customer.id],
      rnc: [this.customer.rnc, [Validators.required, Validators.minLength(3)]],
      name: [this.customer.name, [Validators.required, Validators.minLength(4)]],
      active: [this.customer.active, [Validators.required]],
      createdUserid: [this.customer.createdUserid],
      created: [this.customer.created],
      customerAddreses: this.fb.array([  ])
    });

     if (this.customer.customerAddreses){
      
      this.customer.customerAddreses.forEach(element => {
        var adr = this.fb.group({
                      id: [element.id, [Validators.required]],
                      customerId: [this.customer.id, [Validators.required]],
                      countryId: [element.countryId, [Validators.required]],
                      zone: [element.zone, [Validators.required, Validators.minLength(1)]],
                      street: [element.street, [Validators.required, Validators.minLength(5)]],
                      number: [element.number, [Validators.required, Validators.minLength(2)]],
                      postalCode: [element.postalCode, [Validators.required, Validators.minLength(5)]],
                      phone: [element.phone, [Validators.required, Validators.minLength(10)]],
                      contact: [element.contact, [Validators.required, Validators.minLength(3)]]
                  });
      
                  (<FormArray>this.customerfg.get('customerAddreses')).push(adr);
      });
      
     }    
  }

  createAddress(): FormGroup {
    return this.fb.group({
        id: [0],
        customerId: [this.customer.id, [Validators.required]],
        countryId: ["", [Validators.required]],
        zone: ["", [Validators.required, Validators.minLength(1)]],
        street: ["", [Validators.required, Validators.minLength(5)]],
        number: ["", [Validators.required, Validators.minLength(2)]],
        postalCode: ["", [Validators.required, Validators.minLength(5)]],
        phone: ["", [Validators.required, Validators.minLength(10)]],
        contact: ["", [Validators.required, Validators.minLength(3)]]
    });
  }

  addAddress(): void {
    (<FormArray>this.customerfg.get('customerAddreses')).push(this.createAddress());
  }

  save(){
    this._customerDataService.SaveCustomer(this.customerfg.value).subscribe( resp => {
      this.customer = resp.data;
    });
    }

  cancel(){
    this.modalCtrl.dismiss({
        'name': this.customer.name,
        'id': this.customer.id,
        'rnc': this.customer.rnc,
        'customerAddress': this.customerAddreses,
        'accion': 'modificar'
    }
    );
  }

  deleteAddress(id){
    (<FormArray>this.customerfg.get('customerAddreses')).removeAt(id);
    this._customerDataService.DeleteAddressCustomer(id);
  }

  get rnc() {
    return this.customerfg.get('rnc');
  }

  get name() {
    return this.customerfg.get('name');
  }

   get customerAddreses() {
    return this.customerfg.get('customerAddreses') as FormArray;
  } 

}
