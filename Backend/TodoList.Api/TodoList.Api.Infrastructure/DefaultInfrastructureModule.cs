using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using TodoList.Api.Core.Interfaces;
using TodoList.Api.Infrastructure.Repositories;
using TodoList.Api.Shared.Entities;
using Module = Autofac.Module;

namespace TodoList.Api.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TodoItemsRepository>()
                .As<ITodoItemsRepository>().InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var bd = new DbContextOptionsBuilder<TodoContext>();
                var config = context.Resolve<IConfiguration>();
                var connectionString = config.GetConnectionString("dbConnection");

                var postgresSqlBuilder = new NpgsqlConnectionStringBuilder(connectionString);
                bd.UseNpgsql(postgresSqlBuilder.ConnectionString);
                return new TodoContext(bd.Options);
            }).As<TodoContext>();


            builder.Register<AutoMapper.IConfigurationProvider>(ctx => new MapperConfiguration(cfg =>
            {
                //model vs entities mappings and other 
            }));
        }
    }


}
