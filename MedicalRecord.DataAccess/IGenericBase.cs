using MedicalRecord.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecord.DataAccess
{
    public interface IGenericBase<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> ById(int id);
        Task<Result> Insert(T data);
        Task<Result> Update(T data);
        Task<Result> Delete(T data);
    }
}
