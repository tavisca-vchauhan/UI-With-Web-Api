using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pattern.Controllers
{
    public class CarController : ApiController
    {
        [HttpGet]
        public IEnumerable<Car> GetValues()
        {
            using (DesignEntities entity = new DesignEntities())
            {
                return entity.Cars.ToList();
            }

        }
        [HttpPost]
        public void PostData([FromBody]Car car)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                entity.Cars.Add(car);
                entity.SaveChanges();
            }
        }

        [HttpPut]
        public void Put(int id, [FromBody]int CarId)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                IEnumerable<Car> carList = entity.Cars.ToList();
                foreach (Car car in carList)
                {
                    if (car.carId == CarId)
                    {
                        if (id == 1)
                            car.IsSaved = true;
                        if (id == 2)
                        {
                            if (car.IsBooked == true)
                            {
                                // error already booked
                                car.IsBooked = false;
                            }
                            else
                            {
                                car.IsBooked = true;
                            }
                        }
                    }
                }
                entity.SaveChanges();
            }

        }
    }
}
