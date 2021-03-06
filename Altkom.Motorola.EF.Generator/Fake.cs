﻿using Altkom.Motorola.EF.Models;
using Bogus;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Altkom.Motorola.EF.Generator
{

    // PM> Install-Package Bogus

    public class Fake
    {
        public static Faker<User> Users => new Faker<User>()
                            .StrictMode(true)
                            .RuleFor(p => p.Id, f => f.IndexFaker)
                            .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                            .RuleFor(p => p.LastName, f => f.Person.LastName)
                            .RuleFor(p => p.Country, f => f.Address.Country())
                            .RuleFor(p => p.CompanyName, f => f.Company.CompanyName())
                            .RuleFor(p => p.IsRemoved, f => f.PickRandomParam(new bool[] { true, true, false }))
                            .Ignore(p => p.Calls)
                            .FinishWith((f, user) => Debug.WriteLine($"User was created. Id = {user.Id} {user.FullName}"));

        public static Faker<Group> Groups => new Faker<Group>()
                            .StrictMode(true)
                            .RuleFor(p => p.Id, f => f.IndexFaker)
                            .RuleFor(p => p.Name, f => f.Company.CompanyName())
                            .RuleFor(p => p.Country, f => f.Address.Country())
                            .RuleFor(p => p.CompanyName, f => f.Company.CompanyName())
                            .RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.9f))
                            .Ignore(p => p.Calls)
                            .FinishWith((f, group) => Debug.WriteLine($"Group was created. Id= {group.Id} {group.FullName}"));


        public static Faker<Call> Calls(List<Device> devices, List<Contact> contacts)
        {
            return new Faker<Call>()
                            .StrictMode(true)
                            .RuleFor(p => p.Id, f => f.IndexFaker)
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

        public static string[] Models = new string[]
        {
            "SL4000e", "DP4000e", "DP3000e", "DP4000EX", "SL2600", "DP2000e", "SL1600", "DP1400"
        };

        public static Faker<Device> Devices => new Faker<Device>()
                           .StrictMode(true)
                           .RuleFor(p => p.Id, f => f.IndexFaker)
                           .RuleFor(p => p.Name, f => $"Radio {f.UniqueIndex}")
                           .RuleFor(p => p.Model, f => f.PickRandom(Models))
                           .RuleFor(p => p.Firmware, f => f.System.Version().ToString())
                           .RuleFor(p => p.Description, f => f.Lorem.Paragraph(1))
                           .Ignore(p => p.Calls)
                           .FinishWith((f, device) => Debug.WriteLine($"Device was created. Id = {device.Id} {device.Name}"));
    }
}
