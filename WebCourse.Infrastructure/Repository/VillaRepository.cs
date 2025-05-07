using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebCourse.Application.Common.Interfaces;
using WebCourse.Domain.Entities;
using WebCourse.Infrastructure.Data;

namespace WebCourse.Infrastructure.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {

        private readonly ApplicationDbContext db_;

        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            db_ = db;
        }

        public void Save()
        {
            db_.SaveChanges();
        }

        public void Update(Villa entity)
        {
            db_.Update(entity);
        }
    }
}
