using CrazyBooks_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyBooks_DataAccess.Repository.IRepository
{
  public interface IAuthorBookRepository:IRepository<AuthorBook>
  {
    void Update(AuthorBook authorBook);
  }
}
