using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export
{
    public interface IFormatBuilder
    {
        void Export<T>(T item) where T : Person;

        void Export2<T>(T item) where T : IEnumerable<Person>;

        //Stream ToStream(T item);
    }
}
