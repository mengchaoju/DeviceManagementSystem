using AutoMapper;
using DeviceManagementSystem_Core.Entities;
using DeviceManagementSystem_Core.Interface;
using DeviceManagementSystem_Infrasture.Database;
using DeviceManagementSystem_Infrasture.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DeviceManagementSystem_Api.Controllers
{
    [Route("api/devices")]
    public class DeviceController: Controller
    {
        private readonly IDeviceRepository deviceRepository1;
        private readonly IUnitOfWork unitOfWork1;
        private readonly ILogger<DeviceController> logger1;
        private readonly IMapper mapper1;
        private readonly IUrlHelper urlHelper1;
        
        public DeviceController(IDeviceRepository deviceRepository, 
            IUnitOfWork unitOfWork,
            ILogger<DeviceController> logger,
            IMapper mapper,
            IUrlHelper urlHelper)
        {
            deviceRepository1 = deviceRepository;
            unitOfWork1 = unitOfWork;
            logger1 = logger;
            mapper1 = mapper;
            urlHelper1 = urlHelper;
        }

        [HttpGet("(id)")]
        public async Task<IActionResult> Get(int id)
        {
            var device = await deviceRepository1.GetDeviceByIdAsync(id);

            if (device == null)
            {
                return NotFound();
            }
            var deviceResources = mapper1.Map<Device, DeviceResource>(device);

            return Ok(deviceResources);
        }

        [HttpGet(Name ="GetDevices")]
        public async Task<IActionResult> Get(DeviceParameters deviceParameters)
        {
            var devices = await deviceRepository1.GetAllDevicesAsync(deviceParameters);

            var deviceResources = mapper1.Map<IEnumerable<Device>, IEnumerable<DeviceResource>>(devices);

            var perivousPageLink = devices.HasPrevious ?
                CreateDeviceUrl(deviceParameters, PaginationResourceUrlType.PreviousPage) : null;
            var nextPageLink = devices.HasNext ?
                CreateDeviceUrl(deviceParameters, PaginationResourceUrlType.NextPage) : null;
            var meta = new
            {
                pageSize = devices.PageSize,
                pageIndex = devices.PageIndex,
                TotalItemsCount = devices.TotalItemsCount,
                PageCount = devices.PageCount,
                perivousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(meta,new JsonSerializerSettings
            {
                //将属性名从Header中改为小写
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
            logger1.LogTrace("Get All Devices");
            return Ok(deviceResources);
        }

        [HttpPost]
        public async Task<IActionResult> Device()
        {
            var newDevice = new Device
            {
                Name = "Device 1",
                Description = "ABC",
                LastMaintain = DateTime.Now,
            };
            deviceRepository1.AddDevice(newDevice);
            await unitOfWork1.SaveAsync();
            return Ok();
        }

        private string CreateDeviceUrl(DeviceParameters parameters, PaginationResourceUrlType urlType)
        {
            switch (urlType)
            {
                case PaginationResourceUrlType.PreviousPage:
                    var previousParameters = new
                    {
                        pageIndex = parameters.PageIndex - 1,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        fields = parameters.Fields
                    };
                    return urlHelper1.Link("GetPosts", previousParameters);
                case PaginationResourceUrlType.NextPage:
                    var nextParameters = new
                    {
                        pageIndex = parameters.PageIndex + 1,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        fields = parameters.Fields
                    };
                    return urlHelper1.Link("GetPosts", nextParameters);
                default:
                    var currentParameters = new
                    {
                        pageIndex = parameters.PageIndex,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        fields = parameters.Fields
                    };
                    return urlHelper1.Link("GetPosts", currentParameters);
            }
        }

    }
}
