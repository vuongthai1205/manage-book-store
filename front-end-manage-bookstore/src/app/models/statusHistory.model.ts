import { OrderStatus } from './orderStatus.model';

export interface StatusHistory {
  orderId: number; // Corresponds to C#'s OrderId
  orderStatusId: number | string; // Corresponds to C#'s OrderStatusId
  note?: string; // Corresponds to C#'s Note, with optional "?"
  orderStatus?: OrderStatus; // Corresponds to the foreign key relationship with OrderStatus
  createAt?: Date;
  updateAt?: Date;
}
