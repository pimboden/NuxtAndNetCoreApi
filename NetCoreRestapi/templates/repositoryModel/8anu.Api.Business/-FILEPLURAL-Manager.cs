using System;
using System.Collections.Generic;
using System.Linq;
using _8anu.Api.Common;
using _8anu.Api.Data;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Managers
{
    public class [PLURAL]Manager: BaseManager<[SINGULAR]>, I[PLURAL]Manager
    {

        private readonly I[PLURAL]Repository _[L-PLURAL]Repository;
        public [PLURAL]Manager(I[PLURAL]Repository [L-PLURAL]Repository):base([L-PLURAL]Repository)
        {
            _[L-PLURAL]Repository = [L-PLURAL]Repository;
        }
    }
}