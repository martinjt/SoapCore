using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using SoapCore.Tests.Model;

namespace SoapCore.Tests.Wsdl
{
	public class Startup
	{
		private readonly Type _serviceType;

		public Startup(IStartupConfiguration configuration)
		{
			_serviceType = configuration.ServiceType;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSoapCore();
			services.TryAddSingleton(_serviceType);
			services.AddMvc(x => x.EnableEndpointRouting = false);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
		{
			app.UseSoapEndpoint(_serviceType, "/Service.svc", new BasicHttpBinding(), SoapSerializer.DataContractSerializer);
			app.UseSoapEndpoint(_serviceType, "/Service.asmx", new BasicHttpBinding(), SoapSerializer.XmlSerializer);

			app.UseMvc();
		}
	}
}
