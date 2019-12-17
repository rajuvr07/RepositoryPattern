
using MyStudentApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudentApp.DAL
{
    public class UnitOfWork : IDisposable
    {
        private MyStudentDBContext context = new MyStudentDBContext();
        private GenericRepository<StudentModel> studentRepository;
        public GenericRepository<StudentModel> StudentRepository
        {
            get
            {
                return this.studentRepository ?? new GenericRepository<StudentModel>(context);
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
