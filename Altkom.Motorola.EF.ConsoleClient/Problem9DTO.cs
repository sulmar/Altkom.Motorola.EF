using Altkom.Motorola.EF.DbServices;
using Altkom.Motorola.EF.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.ConsoleClient
{
    public partial class DataLayer
    {
        public void Example9()
        {
            string country = "Poland";

            using (var context = new RadioContext())
            {
                List<UserDTO> users = context.Contacts
                    .OfType<User>()
                    .Where(u => u.Country == country)
                    .Select(u => new UserDTO
                    {
                        FirstName = u.FirstName,
                        Surname = u.LastName
                    })
                    .ToList();
            }
        }

        // PM> Install-Package AutoMapper
        public void Solution9A()
        {
            string country = "Poland";

            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<User, UserDTO>()
                        .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.LastName)));

            var mapper = config.CreateMapper();

            using (var context = new RadioContext())
            {
                IQueryable<User> users = context.Contacts
                    .OfType<User>()
                    .Where(u => u.Country == country);

                List<UserDTO> userDTOs = mapper.Map<List<UserDTO>>(users);
            }
        }


        public void Solution9B()
        {
            string country = "Poland";

            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<User, UserDTO>()
                        .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.LastName)));

            var mapper = config.CreateMapper();

            using (var context = new RadioContext())
            {
                IQueryable<UserDTO> users = context.Contacts
                    .OfType<User>()
                    .Where(u => u.Country == country)
                    .ProjectTo<UserDTO>(config)
                    .OrderBy(u=>u.Surname);

                List<UserDTO> userDTOs = users.ToList();

                var userDTO = userDTOs.First();

                WriteOutput(context.Entry(userDTO).State.ToString());

            }
        }


        public void Solution9C()
        {
            string model = "DP2000e";

            var config = new MapperConfiguration(
              cfg => cfg.CreateMap<Device, DeviceDTO>()
                      .ForMember(dest => dest.FullName, 
                                  opt => opt.MapFrom(src => src.Model + " " + src.Firmware))
                      .ForMember(dest => dest.CallCount, 
                                  opt => opt.MapFrom(src => src.Calls.Count))
                      );

            var mapper = config.CreateMapper();


            using (var context = new RadioContext())
            {
                IQueryable<DeviceDTO> deviceDTOs = context.Devices
                    .Where(d => d.Model == model)
                    .ProjectTo<DeviceDTO>(config)
                    .OrderBy(d=>d.CallCount);

                List<DeviceDTO> devices = deviceDTOs.ToList();
            }

        }
    }

    public class UserDTO
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }


    public class DeviceDTO
    {
        public string FullName { get; set; }
        public int CallCount { get; set; }
    }
}
