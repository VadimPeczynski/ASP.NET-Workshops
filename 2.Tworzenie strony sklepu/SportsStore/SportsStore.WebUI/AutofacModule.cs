using System.Collections.Generic;
using Autofac;
using NSubstitute;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var repository = Substitute.For<IProductRepository>();
            repository.Products.Returns(new List<Product>
                {
                    new Product{ Name="Pi³ka no¿na", Price = 25},
                    new Product{ Name="Deska surfingowa", Price = 179},
                    new Product{ Name="Buty do biegania", Price = 95}
                }
            );
            builder.RegisterInstance(repository).As<IProductRepository>();
        }
    }
}