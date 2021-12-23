using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1._0
{
    interface IUI
    {
        string AskForStrInput(string prompt);
        uint AskForUIntInput(string prompt);
        void PrintString(string message);
        int AskForFuelInput();
        void Rkey();
    }
}
