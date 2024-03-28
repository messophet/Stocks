using StockServiceShared.Models;

namespace StockServiceShared.Interfaces
{
    public interface IStockClient
    {
        void UpdatePrice(StockModel updatedStock);
    }
}