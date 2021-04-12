export class CustomerModel {
    id: number;
    rnc: string;
    name: string;
    active: Boolean;
    createdUserid: number;
    created: Date;
    customerAddreses: Array<CustomerAddresModel> = [];

    constructor(){
        this.id = 0;
        this.rnc = '';
        this.name = '';
        this.active = true;
        this.createdUserid = 0;
        this.created = new Date();
        this.customerAddreses = [];
    }
}

export class CustomerAddresModel {
    id: number;
    customerId: number;
    countryId: string;
    zone: string;
    street: string;
    number: string;
    postalCode: string;
    phone: string;
    contact: string;
    createdUserid: number;
    created: Date;

    constructor(){
        this.id = 0;
        this.customerId = 0;
        this.countryId = '';
        this.zone = '';
        this.street = '';
        this.number = '';
        this.postalCode = '';
        this.phone = '';
        this.contact = '';
        this.createdUserid = 0;
        this.created = new Date();
    }
}


    
        