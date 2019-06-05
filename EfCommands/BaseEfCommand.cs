using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public abstract class BaseEfCommand
    {
        protected ProjectContext Context { get; set; }

        protected BaseEfCommand(ProjectContext context) => Context = context;
    }
}
