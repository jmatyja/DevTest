import { CustomerType } from './customerType';

export interface Customer {
    id: number;
    name: string;
    type: CustomerType;
}
