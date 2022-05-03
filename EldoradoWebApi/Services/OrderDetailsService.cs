using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Entities;
using EldoradoWebApi.Models.OrderDetails;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {

        private readonly SqlContext _context;

        public OrderDetailsService(SqlContext context)
        {
            _context = context;
        }

        public async Task CreateDetails(OrderDetailsCreate model)
        {
           var orders = await _context.Orders.OrderByDescending(x=> x.Id).FirstOrDefaultAsync();
           var product = await _context.Products.Where(y=> y.Id == model.ProductId).FirstOrDefaultAsync();
           double prodPrice = product.Price;
            
            var detailsEntity = new OrderDetailsEntity(orders.Id,model.ProductId,product.Name,prodPrice,model.Quantity);

             _context.OrderDetails.Add(detailsEntity);
            await _context.SaveChangesAsync();
            

        }

        public async Task<IEnumerable<OrderDetailsObject>> GetDetails(int id)
        {
           var detailsRow = await _context.OrderDetails.Include(x=> x.Product).Include(x => x.Order).Where(x=> x.OrderId == id).ToListAsync();
            var detailsRowList = new List<OrderDetailsObject>();
            foreach(var item in detailsRow)
            {
                detailsRowList.Add(new OrderDetailsObject(
                    item.OrderId,
                    item.Product.Name,
                    item.Price,
                    item.Quantity));
            }

            return detailsRowList;
        }

        public async Task<OrderDetailsObject> UpdateDetails(int id, OrderDetailsUpdate model)
        {
            var detailsRow = await _context.OrderDetails.FindAsync(id);

            detailsRow.OrderId = model.OrderId;
            detailsRow.Quantity = model.Quantity;
            detailsRow.Price = model.Price;
            _context.Entry(detailsRow).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new OrderDetailsObject(detailsRow.OrderId, detailsRow.Price, detailsRow.Quantity);

        }
    }
}


