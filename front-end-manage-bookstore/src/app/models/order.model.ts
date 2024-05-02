import { Orderdetail } from "./orderdetail.model";

export class Order {
    username?: string;
    totalPrice?: number;
    orderDetailRequests?: Orderdetail[];
}
