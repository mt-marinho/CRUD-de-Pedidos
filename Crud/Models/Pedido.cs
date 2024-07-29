using System.ComponentModel.DataAnnotations;

namespace Crud1.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal? Desconto { get; set; }
        public decimal ValorFinal => Valor - Desconto.GetValueOrDefault();

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Vencimento { get; set; }
        public int PedidoStatus()
        {
            TimeSpan IntervaloDias = Vencimento.Subtract(DateTime.Now);
            int Cod = 2;
            if (IntervaloDias.Days <= 0)
            {
                Cod = 0;
            }
            else if (IntervaloDias.Days < 3)
            {
                Cod = 1;
            }

            return Cod;
        }

        public int ValorDesconto()
        {
            int Cod = 1;

            if (PedidoStatus() == 0)
            {
                Desconto = 0;
                Cod = 0;
            }
            return Cod;
        }
    }
}
