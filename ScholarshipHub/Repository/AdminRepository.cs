using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using System.Data.Entity;


namespace ScholarshipHub.Repository
{
    public class AdminRepository : Repository<Models.Admin>, IAdminRepository
    {
        ScholarshipHubDataContext context;
        private int salarystatus;

        public AdminRepository()
        {
             context = new ScholarshipHubDataContext();
        }
        public IEnumerable<Admin> GetAll()
        {
            return context.Set<Admin>().ToList();
        }

        public Admin GetAdminByID(string username)
        {
            return context.Set<Admin>().SingleOrDefault(admin => username == username);
        }

        /*public IEnumerable<Admin> GetAdminByPayment()
        {
            return context.Set<Admin>().ToLookup<Admin>(salarystatus == 0)
        }*/

        public Admin GetAdminByName(string name)
        {
            return context.Set<Admin>().SingleOrDefault(admin => name == name);
        }

        public Admin Get(int id)
        {
            return context.Set<Admin>().Find(id);
        }

        public void Insert(Admin entity)
        {
            context.Set<Admin>().Add(entity);
            context.SaveChanges();
        }

        public void Update(Admin entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<Admin>().Remove(this.Get(id));
            context.SaveChanges();
        }
    }
}