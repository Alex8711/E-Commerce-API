using System.Collections.Generic;

namespace E_Commerce_API.Models
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }
        
        public CustomerBasket(string id)
        {
            Id = id;
        }

      

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

    }
}