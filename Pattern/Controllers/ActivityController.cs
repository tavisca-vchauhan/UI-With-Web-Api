using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pattern.Controllers
{
    public class ActivityController : ApiController
    {
        [HttpGet]
        public IEnumerable<Activity> GetValues()
        {
            using (DesignEntities entity = new DesignEntities())
            {
                return entity.Activities.ToList();
            }
            
        }
        [HttpPost]
        public void PostData([FromBody]Activity activity)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                entity.Activities.Add(activity);
                entity.SaveChanges();
            }
        }

        [HttpPut]
        public void Put(int id, [FromBody]int ActivityId)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                IEnumerable<Activity> activityList = entity.Activities.ToList();
                foreach (Activity activity in activityList)
                {
                    if (activity.activityID == ActivityId)
                    {
                        if (id == 1)
                            activity.IsSaved = true;
                        if (id == 2)
                        {
                            if (activity.IsBooked == true)
                            {
                                // error already booked
                                activity.IsBooked = false;
                            }
                            else
                            {
                                activity.IsBooked = true;
                            }
                        }
                    }
                }
                entity.SaveChanges();
            }

        }
    }
}
