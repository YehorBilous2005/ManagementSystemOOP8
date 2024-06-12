using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public interface IManipulation<T>
    {
        void Add(T obj);
        void Remove(T obj);
    }
}
