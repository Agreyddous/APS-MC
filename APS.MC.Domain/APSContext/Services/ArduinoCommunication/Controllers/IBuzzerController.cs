using System.Threading.Tasks;
using APS.MC.Domain.APSContext.Services.ArduinoCommunication.Queries.Buzzers;
using APS.MC.Domain.APSContext.ValueObjects;
using APS.MC.Shared.APSShared.Notifications;

namespace APS.MC.Domain.APSContext.Services.ArduinoCommunication.Controllers
{
	public interface IBuzzerController : INotifiable
	{
		Task<bool> Switch(SwitchBuzzerQuery query);
		Task<bool> Read(PinPort pinPort);
	}
}