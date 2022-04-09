using System.Collections.Generic;
using System.Linq;

namespace PlakDukkani.UI.MVC.Models.CartItems
{
    public class Cart   //Sepet
    {
        private Dictionary<int, CartItem> sepet = new Dictionary<int, CartItem>();

        public void Add(CartItem item)
        {
            if (sepet.ContainsKey(item.ID))
            {
                sepet[item.ID].Quantity += item.Quantity;
                return;
            }
            sepet.Add(item.ID, item);
        }

        public void Update(int id, short quantity)
        {
            if (sepet.ContainsKey(id))
            {
                sepet[id].Quantity = quantity; 
            }
        }

        public void Delete(int id)
        {
            if (sepet.ContainsKey(id))
            {
                sepet.Remove(id);
            }
        }

        public decimal TotalQuantity => sepet.Values.Sum(a => a.Quantity);
    }
}
    