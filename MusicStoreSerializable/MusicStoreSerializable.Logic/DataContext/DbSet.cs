using MusicStoreSerializable.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSerializable.Logic.DataContext
{
        public class DbSet<T> : List<T> where T : IdentityObject
        {
                new public void Add( T entity )
                {
                        int maxId = 1;

                        if(this.Count > 0)
                                maxId = this.Max( e => e.Id ) + 1;
                        entity.Id = maxId;
                        base.Add( entity );
                }
        }
}
