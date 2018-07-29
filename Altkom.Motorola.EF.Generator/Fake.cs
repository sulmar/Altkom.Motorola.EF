using Altkom.Motorola.EF.Models;
using Bogus;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Altkom.Motorola.EF.Generator
{

    // Install-Package Bogus

    public class Fake
    {
        public static Faker<Contact> Contacts => new Faker<Contact>()
                            .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                            .RuleFor(p => p.LastName, f => f.Person.LastName)
                            .RuleFor(p => p.Country, f => f.Address.Country())
                            .RuleFor(p => p.CompanyName, f => f.Company.CompanyName())
                            .RuleFor(p => p.IsRemoved, f => f.PickRandomParam(new bool[] { true, true, false }))
                            .FinishWith((f, contact) => Debug.WriteLine($"Contact was created. Id = {contact.Id} {contact.FullName}"));

        public static Faker<Call> Calls(List<Device> devices, List<Contact> contacts)
        {
            return new Faker<Call>()
                            .RuleFor(p => p.BeginCallDate, f => f.Date.Past())
                            .RuleFor(p => p.EndCallDate, (f, p) => p.BeginCallDate.AddMinutes(f.Random.Double(1, 3)))
                            .RuleFor(p => p.Status, f => f.PickRandom<CallStatus>())
                            .RuleFor(p => p.Source, f => f.PickRandom(devices))
                            .RuleFor(p => p.Sender, f => f.PickRandom(contacts))
                            .RuleFor(p => p.Target, (f, p) => f.PickRandom(devices.Except(new List<Device>() { p.Source })))
                            .RuleFor(p => p.IsAnswered, f => f.Random.Bool(0.8f))
                            .RuleFor(p => p.ChannelId, f => f.Random.Number(255))
                            .FinishWith((f, call) => Debug.WriteLine($"Call was created. Id = {call.Id} {call.Source.Name} -> {call.Target.Name}"));
        }

        public static Faker<Device> Devices => new Faker<Device>()
                           .RuleFor(p => p.Name, f => $"Radio {f.UniqueIndex}")
                           .RuleFor(p => p.Firmware, f => f.System.Version().ToString())
                           .RuleFor(p => p.Description, f => f.Lorem.Paragraph(1))
                           .FinishWith((f, device) => Debug.WriteLine($"Device was created. Id = {device.Id} {device.Name}"));
    }
}
