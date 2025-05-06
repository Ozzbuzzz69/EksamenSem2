using EksamenProjekt2Sem.Models;

namespace EksamenProjekt2Sem.Services
{
    public class OrderService : GenericDbService<Order>
    {
        private List<Order> _orders; // Overskud fra domain model
        private GenericDbService<Order> _dbService; // Overskud fra domain model

        public OrderService(GenericDbService<Order> dbService)
        {
            _dbService = dbService;
            _orders = _dbService.GetObjectsAsync().Result.ToList();
        }
        public OrderService()
        {
            _orders = new List<Order>();
            _dbService = new GenericDbService<Order>();
        }
        /// <summary>
        /// Adds the order object from argument to the database, and the _orders list.
        /// </summary>
        /// <param name="order"></param>
        public void CreateOrder(Order order)
        {
            _orders.Add(order);
            _dbService.AddObjectAsync(order);
        }
        public Order? ReadOrder(int id)
        {
            foreach (Order order in _orders)
            {
                if (order.Id == id)
                {
                    return order;
                }
            }
            return null;
        }
        /// <summary>
        /// Reads all order objects from the database.
        /// </summary>
        /// <returns></returns>
        public List<Order> ReadAllOrders()
        {
            return _orders;
        }
        /// <summary>
        /// Updates the order object from argument to the database, and the _orders list.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        public void UpdateOrder(int id, Order order)
        {
            if (order != null)
            {
                foreach (Order o in _orders)
                {
                    if (o.Id == id)
                    {
                        o.User = order.User;
                        o.PickupTime = order.PickupTime;
                        o.OrderLines = order.OrderLines;
                    }
                }
                _dbService.UpdateObjectAsync(order);
            }
        }
        /// <summary>
        /// Deletes the order object from argument to the database, and the _orders list. Returns the deleted order.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The deleted Order/null</returns>
        public Order? DeleteOrder(int id)
        {
            Order? ToBeDeleted = null;
            foreach (Order order in _orders)
            {
                if (order.Id == id)
                {
                    ToBeDeleted = order;
                    break;
                }
            }
            if (ToBeDeleted != null)
            {
                _orders.Remove(ToBeDeleted);
                _dbService.DeleteObjectAsync(ToBeDeleted);
            }
            return ToBeDeleted; // Return the deleted order
        }
        /// <summary>
        /// Calculates the total price of the order by going through each orderline in the list to calculate the total price.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Total price for all orderlines</returns>
        /// <exception cref="Exception"></exception>
        //public double CalculateTotalPrice(int id)
        //{
        //    Order? order = ReadOrder(id);
        //    if (order != null)
        //    {
        //        return order.GetTotalPrice(); // Use the method from the Order class to calculate total price
        //    }
        //    else
        //    {
        //        throw new Exception("Order not found");
        //    }
        //}
    #region Sorting functions
        /// <summary>
        /// Sorts the orderlines in a given order by price in ascending order.
        /// </summary>
        /// <param name="order"></param>
        public void SortOrderlinesByPrice(Order order)
        {
            order.OrderLines = order.OrderLines.OrderBy(ol => ol.Price).ToList();
        }
        /// <summary>
        /// Sorts the orderlines in a given order by price in descending order.
        /// </summary>
        /// <param name="order"></param>
        public void SortOrderlinesByPriceDescending(Order order)
        {
            order.OrderLines = order.OrderLines.OrderByDescending(ol => ol.Price).ToList();
        }
        /// <summary>
        /// Sorts the orderlines in a given order by quantity in ascending order.
        /// </summary>
        /// <param name="order"></param>
        public void SortOrderlinesByQuantity(Order order)
        {
            order.OrderLines = order.OrderLines.OrderBy(ol => ol.Quantity).ToList();
        }
        /// <summary>
        /// Sorts the orderlines in a given order by quantity in descending order.
        /// </summary>
        /// <param name="order"></param>
        public void SortOrderlinesByQuantityDescending(Order order)
        {
            order.OrderLines = order.OrderLines.OrderByDescending(ol => ol.Quantity).ToList();
        }
        /// <summary>
        /// Sorts the orderlines in a given order by id in ascending order.
        /// </summary>
        /// <param name="order"></param>
        public void SortOrderlinesById(Order order)
        {
            order.OrderLines = order.OrderLines.OrderBy(ol => ol.Id).ToList();
        }
        /// <summary>
        /// Sorts the orderlines in a given order by id in descending order.
        /// </summary>
        /// <param name="order"></param>
        public void SortOrderlinesByIdDescending(Order order)
        {
            order.OrderLines = order.OrderLines.OrderByDescending(ol => ol.Id).ToList();
        }
    #endregion

    #region Orderline manipulation
        /// <summary>
        /// Adds the orderline object from argument to the order object given by Id
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderLine"></param>
        //public void AddOrderLine(int orderId, OrderLine orderLine)
        //{
        //    Order? order = ReadOrder(orderId);
        //    if (order != null)
        //    {
        //        order.AddOrderLine(orderLine);
        //        _dbService.UpdateObjectAsync(order);
        //    }
        //}
        /// <summary>
        /// Gets the orderlines for an Order object from the id in argument
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Orderline</returns>
        //public List<OrderLine>? GetOrderLines(int orderId)
        //{
        //    Order? order = ReadOrder(orderId);
        //    if (order != null)
        //    {
        //        return order.GetOrderLines();
        //    }
        //    return null;
        //}
        /// <summary>
        /// Updates the orderline from ids in argument to the orderline given in argument
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderLineId"></param>
        /// <param name="orderLine"></param>
        //public void UpdateOrderLine(int orderId, int orderLineId, OrderLine orderLine)
        //{
        //    Order? order = ReadOrder(orderId);
        //    if (order != null)
        //    {
        //        order.UpdateOrderLine(orderLineId, orderLine);
        //        _dbService.UpdateObjectAsync(order);
        //    }
        //}
        /// <summary>
        /// Removes the orderline object from argument to the order object given by Id
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderLineId"></param>
        //public void RemoveOrderLine(int orderId, int orderLineId) //Maybe needs to have a return value like the other remove
        //{
        //    Order? order = ReadOrder(orderId);
        //    if (order != null)
        //    {
        //        order.RemoveOrderLine(orderLineId);
        //        _dbService.UpdateObjectAsync(order);
        //    }
        //}
    #endregion

    }
}
