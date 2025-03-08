using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Contracts
{
    // Esto define un contrato genérico para cualquier tipo de objeto T
    public interface IGenericDao<T>
    {
        void Add(T obj);

        void Update(T obj);

        void Remove(Guid id);

        T GetById(Guid id);

        List<T> GetAll();

    }
}
