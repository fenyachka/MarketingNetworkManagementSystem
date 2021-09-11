﻿
using Domain.Entities.Bonuses;
using Domain.Entities.Distributors;
using Domain.Entities.Mapping;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> SaveAsync(CancellationToken cancellationToken);
        IRepository<Distributor> Distributor { get; }
        IRepository<AddressInfo> AddressInfo { get; }
        IRepository<ContactInfo> ContactInfo { get; }
        IRepository<DocumentInfo> DocumentInfo { get; }
        IRepository<Photo> Photo { get; }
        IRepository<Referals> Referals { get; }
        IRepository<Product> Product { get; }
        IRepository<Order> Order { get; }
        IRepository<OrderItem> OrderItem { get; }
        IRepository<Bonus> Bonus { get; }



    }
}
