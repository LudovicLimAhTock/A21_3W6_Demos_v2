using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyBooks.Models.Data
{
  public class CrazyBooksDbContext: DbContext
  {
    public CrazyBooksDbContext(DbContextOptions<CrazyBooksDbContext> options) : base(options)
    {

    }

  }
}
