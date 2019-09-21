using DeviceManagementSystem_Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagementSystem_Infrasture.Database
{
    public class MyContextTest
    {
        public static async Task TestAsync(MyContext myContext,
            ILoggerFactory loggerFactory, int retry = 0)
        {
            int retryForAvailability = retry;
            try
            {
                // TODO: Only run this if using a real database
                // myContext.Database.Migrate();

                if (!myContext.Devices.Any())
                {
                    myContext.Devices.AddRange(
                        new List<Device>{
                            new Device{
                                Name = "RFID 1",
                                Description = "RFID in Mel",
                                Owner = "OC energy",
                                LastMaintain = DateTime.Now
                            },
                            new Device{
                                Name = "RFID 2",
                                Description = "RFID in Syd",
                                Owner = "AC energy",
                                LastMaintain = DateTime.Now
                            },
                            new Device{
                                Name = "RFID 3",
                                Description = "RFID in Bris",
                                Owner = "BC energy",
                                LastMaintain = DateTime.Now
                            },
                            new Device{
                                Name = "RFID 4",
                                Description = "Laptop in Syd",
                                Owner = "DC energy",
                                LastMaintain = DateTime.Now
                            },
                            new Device{
                                Name = "RFID 5",
                                Description = "thermometer in Syd",
                                Owner = "VC energy",
                                LastMaintain = DateTime.Now
                            },
                            new Device{
                                Name = "RFID 6",
                                Description = "thermometer in Mel",
                                Owner = "WE energy",
                                LastMaintain = DateTime.Now
                            },
                            new Device{
                                Name = "RFID 7",
                                Description = "thermometer in Bris",
                                Owner = "PC energy",
                                LastMaintain = DateTime.Now
                            },
                            new Device{
                                Name = "RFID 8",
                                Description = "thermometer in Spr",
                                Owner = "FC energy",
                                LastMaintain = DateTime.Now
                            }
                        }
                    );
                    await myContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<MyContextTest>();
                    logger.LogError(ex.Message);
                    await TestAsync(myContext, loggerFactory, retryForAvailability);
                };
            }


        }     
    }
}
