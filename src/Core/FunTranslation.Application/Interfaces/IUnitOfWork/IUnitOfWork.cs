﻿using FunTranslation.Application.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        

        Task CommitAsync();
        void Commit();
    }
}
