﻿using System;
using System.Collections.Generic;

namespace PostMicroservice.Core.Interface.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        T Save(T obj);

        T Edit(T obj);

        T Delete(T obj);
    }
}