using System;
using System.Collections.Generic;
using System.Linq;
using _8anu.Api.Common;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories
{
    public class [PLURAL]Repository:Repository<[SINGULAR]>, I[PLURAL]Repository
    {
        public [PLURAL]Repository(DomainModelMySqlContext context) : base(context)
        {
        }
    }
}