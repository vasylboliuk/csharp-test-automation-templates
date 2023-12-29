using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fw_webapi_nunit.test.testmethods
{
    class CarDto
    {
        public string Model { get; set; }
        public int YearReleased { get; set; }

        public CarDto(string model, int yearReleased)
        {
            Model = model;
            YearReleased = yearReleased;

            Log.Debug("Created a car {@model} {@yearReleased} at {now}", this, DateTime.Now);
        }
    }
}
