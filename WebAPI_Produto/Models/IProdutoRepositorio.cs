﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_Produto.Models
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> GetAll();
        Produto Get(int id);
        Produto Add(Produto item);
        void Remove(int id);
        bool Update(Produto item);
    }
}
