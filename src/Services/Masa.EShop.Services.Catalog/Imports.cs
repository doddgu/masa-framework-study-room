global using FluentValidation;
global using Masa.BuildingBlocks.Dispatcher.Events;
global using Masa.BuildingBlocks.Dispatcher.IntegrationEvents;
global using Masa.BuildingBlocks.ReadWriteSplitting.Cqrs.Commands;
global using Masa.BuildingBlocks.ReadWriteSplitting.Cqrs.Queries;
global using Masa.Contrib.Data.UoW.EFCore;
global using Masa.Contrib.Dispatcher.Events;
global using Masa.Contrib.Dispatcher.IntegrationEvents.Dapr;
global using Masa.EShop.Contracts.Catalog.Dto;
global using Masa.EShop.Contracts.Catalog.IntegrationEvents;
global using Masa.EShop.Contracts.Ordering.IntegrationEvents;
global using Masa.EShop.Services.Catalog.Application.CatalogBrands.Queries;
global using Masa.EShop.Services.Catalog.Application.Catalogs.Commands;
global using Masa.EShop.Services.Catalog.Application.Catalogs.Queries;
global using Masa.EShop.Services.Catalog.Application.CatalogTypes.Commands.CreateCatalogType;
global using Masa.EShop.Services.Catalog.Application.CatalogTypes.Queries;
global using Masa.EShop.Services.Catalog.Application.Middleware;
global using Masa.EShop.Services.Catalog.Domain.Entities;
global using Masa.EShop.Services.Catalog.Domain.Repositories;
global using Masa.EShop.Services.Catalog.Infrastructure;
global using Masa.EShop.Services.Catalog.Infrastructure.EntityConfigurations;
global using Masa.EShop.Services.Catalog.Infrastructure.Extensions;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;
global using System.Globalization;
global using System.IO.Compression;
global using System.Linq.Expressions;
global using System.Reflection;
global using System.Text.RegularExpressions;
