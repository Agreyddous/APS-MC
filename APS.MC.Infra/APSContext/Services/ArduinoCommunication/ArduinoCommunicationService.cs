using System;
using System.Net.Http;
using APS.MC.Domain.APSContext.Services.ArduinoCommunication;
using APS.MC.Domain.APSContext.Services.ArduinoCommunication.Controllers;
using APS.MC.Infra.APSContext.Services.ArduinoCommunicationService.Controllers;
using APS.MC.Shared.APSShared;
using APS.MC.Shared.APSShared.Enums;
using APS.MC.Shared.APSShared.Notifications;
using APS.MC.Shared.APSShared.Services;

namespace APS.MC.Infra.APSContext.Services.ArduinoCommunicationService
{
	public class ArduinoCommunicationService : Notifiable, IArduinoCommunicationService
	{
		public ArduinoCommunicationService(ILoggingService loggingService)
		{
			try
			{
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri(Settings.ArduinoAddress);

				Sensors = new SensorController(client);
				Lights = new LightController(client);
				Buzzers = new BuzzerController(client);
			}
			catch (Exception e)
			{
				loggingService.Log(ELogType.Neutral, ELogLevel.Error, e, Settings.ArduinoAddress);
			}
		}

		public ISensorController Sensors { get; private set; }
		public ILightController Lights { get; private set; }
		public IBuzzerController Buzzers { get; private set; }
	}
}