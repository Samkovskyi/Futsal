using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Core
{
    public abstract class ObjectBase
    {
        public static IContainer Container { get; set; }
    }
}
