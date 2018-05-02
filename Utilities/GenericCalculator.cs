using System;
namespace Utilities
{
    //https://www.codeproject.com/Articles/8531/Using-generics-for-calculations
    public class GenericCalculator<T> where T : new()
    {
        private Calculator<T> Calculator { get; set; }
        
        public GenericCalculator(Calculator<T> calc)
        {
            this.Calculator = calc;
        }
    }
}