using BackendTarjetas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTarjetas
{
    public class conexionDBcontex: DbContext
    {
        public conexionDBcontex(DbContextOptions<conexionDBcontex> options): base(options)
        {

        }
        public DbSet<tarjetaCredito> TarjetaCredito { get; set; }

    }
}
