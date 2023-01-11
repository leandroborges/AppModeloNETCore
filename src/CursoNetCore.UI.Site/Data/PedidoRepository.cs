using CursoNetCore.UI.Site.Models;
using static CursoNetCore.UI.Site.Data.PedidoRepository;

namespace CursoNetCore.UI.Site.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        public Pedido ObterPedido()
        {
            return new Pedido();
        }

        public interface IPedidoRepository
        {
            Pedido ObterPedido();
        }
    }
}
