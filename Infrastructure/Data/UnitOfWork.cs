using Domain.Entities.Bonuses;
using Domain.Entities.Distributors;
using Domain.Entities.Mapping;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private Hashtable _repositories;
        public IRepository<Distributor> Distributor { get; }
        public IRepository<AddressInfo> AddressInfo { get; }
        public IRepository<ContactInfo> ContactInfo { get; }
        public IRepository<DocumentInfo> DocumentInfo { get; }
        public IRepository<Photo> Photo { get; }
        public IRepository<Referals> Referals { get; }
        public IRepository<Product> Product { get; }
        public IRepository<Order> Order { get; }
        public IRepository<OrderItem> OrderItem { get; }
        public IRepository<Bonus> Bonus { get; }

        public UnitOfWork(DataContext context,
            IRepository<Distributor> distributor,
        IRepository<AddressInfo> addressInfo,
        IRepository<ContactInfo> contactInfo,
        IRepository<DocumentInfo> documentInfo,
        IRepository<Photo> photo,
        IRepository<Referals> referals,
        IRepository<Product> product,
        IRepository<Order> order,
        IRepository<OrderItem> orderItem,
        IRepository<Bonus> bonus)
        {
            _context = context;
            Distributor = distributor;
            AddressInfo = addressInfo;
            ContactInfo = contactInfo;
            DocumentInfo = documentInfo;
            Photo = photo;
            Referals = referals;
            Product = product;
            Order = order;
            OrderItem = orderItem;
            Bonus = bonus;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }

}
