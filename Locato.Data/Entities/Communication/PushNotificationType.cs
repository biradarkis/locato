﻿using Locato.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Communication
{
    public class PushNotificationType : Entity
    {
        public required string Name { get;set; }
    }
}
