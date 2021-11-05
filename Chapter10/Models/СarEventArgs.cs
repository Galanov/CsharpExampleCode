using System;
namespace Chapter10.Models
{
    public class CarEventArgs: EventArgs
    {
        public readonly string msg;

        public CarEventArgs(string message)
        {
            msg = message;
        }
    }
}
