using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppMallas.Model
{
    public class MallasRepository
    {
        public IList<Malla> Mallas { get; set; }
        public MallasRepository()
        {
            Task.Run(async () => Mallas = await App.Database.GetMallasAsync()).Wait();
        }
        public IList<Malla> GetAll()
        {
            return Mallas;
        }
    }
}
