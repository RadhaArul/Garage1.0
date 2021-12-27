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
        int AskForIntInput(string prompt);
        void PrintString(string message);
        int AskForIntInputWithLimit(string prompt, int min, int max);
        void Rkey();
    }
}
