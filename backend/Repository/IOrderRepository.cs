﻿namespace backend;

public interface IOrderRepository : IRepository<Order>
{
    Task<List<Order>> GetOrderByUsername(string username);
    Task<IEnumerable<Order>> GetAllOrder();
}
