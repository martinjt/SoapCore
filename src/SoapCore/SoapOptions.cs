using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace SoapCore
{
	public class SoapOptions
	{
		public Type ServiceType { get; set; }
		public string Path { get; set; }
		public MessageEncoder[] MessageEncoders { get; set; }
		public SoapSerializer SoapSerializer { get; set; }
		public bool CaseInsensitivePath { get; set; }
		public ISoapModelBounder SoapModelBounder { get; set; }
		public Binding Binding { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether publication of service metadata on HTTP GET request is activated
		/// <para>Defaults to true</para>
		/// </summary>
		public bool HttpGetEnabled { get; set; } = true;

		/// <summary>
		/// Gets or sets a value indicating whether publication of service metadata on HTTPS GET request is activated
		/// <para>Defaults to true</para>
		/// </summary>
		public bool HttpsGetEnabled { get; set; } = true;
	}
}
