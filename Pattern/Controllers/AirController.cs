using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pattern.Controllers
{
    public class AirController : ApiController
    {
        [HttpGet]
        public IEnumerable<Air> GetValues()
        {
            using (DesignEntities entity = new DesignEntities())
            {
                return entity.Airs.ToList();
            }

        }
        [HttpPost]
        public void PostData([FromBody]Air air)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                entity.Airs.Add(air);
                entity.SaveChanges();
            }
        }

        [HttpPut]
        public void Put(int id, [FromBody]int AirId)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                IEnumerable<Air> airList = entity.Airs.ToList();
                foreach (Air air in airList)
                {
                    if (air.airId == AirId)
                    {
                        if (id == 1)
                            air.IsSaved = true;
                        if (id == 2)
                        {
                            if (air.IsBooked == true)
                            {
                                // error already booked
                                air.IsBooked = false;
                            }
                            else
                            {
                                air.IsBooked = true;
                            }
                        }
                    }
                }
                entity.SaveChanges();
            }

        }
    }
}
