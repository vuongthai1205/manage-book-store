import { Orderdetail } from "./orderdetail.model";
import { StatusHistory } from "./statusHistory.model";

export class Order {
    id?:number;
    username?: string;
    totalPrice?: number;
    orderDetailRequests?: Orderdetail[];
    orderDetails?: Orderdetail[];
    statusHistoryResponses?: StatusHistory[];
    createAt?:Date;
    updateAt?:Date;
    note?: string;
}
