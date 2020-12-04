using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMA.Sop.ApplicationServices.Convertors;
using PMA.Sop.ApplicationServices.User.Command;
using PMA.Sop.Core.Convertors.Interfaces;
using PMA.Sop.Core.Services;
using PMA.Sop.Core.Services.Interface;
using PMA.Sop.DAL.Context;
using PMA.Sop.DAL.Context.UOW;
using PMA.Sop.Domain.SeedWork;
using PMA.Sop.Domain.User.Commands;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Commands;
using PMA.Sop.Framework.Queries;
using PMA.Sop.Framework.Resources;
using PMA.Sop.Framework.Resources.Interface;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.Web.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIoc(this IServiceCollection services,
            IConfiguration configuration)
        {
            var mailAddress = configuration.GetValue<string>("EmailInfo:MailAddress");
            var mailPassword = configuration.GetValue<string>("EmailInfo:MailPassword");

            services.AddTransient<CommandDispatcher>();
            services.AddTransient<QueryDispatcher>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityDefaultCnn"),
                    builder => builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddTransient<IEmailService>(provider => new EmailService(mailAddress, mailPassword));

            services.AddTransient<IResourceManager, ResourceManager<SharedResource>>();
            services.AddTransient<IViewRenderService, RenderViewToString>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region MediatR
            services.AddTransient<IRequestHandler<AddApplicationUserInfoCommand, int>, UserInfoCommandHandler>();
            services.AddMediatR(typeof(Startup));
            #endregion

            #region Identity

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<CustomIdentityError>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(7200);

                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.AccessDeniedPath = "/AccessDenied";
                options.SlidingExpiration = true;
            });
            #endregion

            return services;
        }
    }
}
