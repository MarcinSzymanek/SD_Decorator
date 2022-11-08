using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_DecoratorApp.Attributes.Decorators
{
    internal class DecoratorCrit : IDecorator, Attributes
    {
        private readonly Attributes _attributes;

    }
}
