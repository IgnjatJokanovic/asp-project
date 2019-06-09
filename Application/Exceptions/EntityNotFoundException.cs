﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entity) : base($"{entity} not found")
        {

        }

        public EntityNotFoundException()
        {

        }
    }
}
