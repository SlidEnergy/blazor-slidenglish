using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;

namespace SlidEnglish.Server
{
	public class Startup
	{
		private string ConnectionString
		{
			get
			{
				if (CurrentEnvironment.IsProduction())
					return Environment.GetEnvironmentVariable("CONNECTION_STRING");

				return Configuration.GetConnectionString(Environment.MachineName) ??
					Configuration.GetConnectionString("DefaultConnection");
			}
		}

		public IConfiguration Configuration { get; }
		private IWebHostEnvironment CurrentEnvironment { get; }

		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			Configuration = configuration;
			CurrentEnvironment = env;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
            // AutoMapper
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile(provider.GetService<SlidEnglishContext>()));
            }).CreateMapper());

            services.AddCors();
			services.AddMvc().AddNewtonsoftJson();
			services.AddResponseCompression(opts =>
			{
				opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
					new[] { "application/octet-stream" });
			});

			services.AddEntityFrameworkNpgsql()
				.AddDbContext<SlidEnglishContext>(options => options
					.UseLazyLoadingProxies()
					.UseNpgsql(ConnectionString))
				.BuildServiceProvider();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseResponseCompression();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBlazorDebugging();
			}

			app.UseStaticFiles();
			app.UseClientSideBlazorFiles<Client.Startup>();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
				endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
			});
		}
	}
}
