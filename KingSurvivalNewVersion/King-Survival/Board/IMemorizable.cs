using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Board
{
    public interface IMemorizable
    {
        Memento SaveMemento();

        void RestoreMemento(Memento memento);
    }
}
