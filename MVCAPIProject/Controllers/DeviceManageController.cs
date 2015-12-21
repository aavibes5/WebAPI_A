using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Security.Principal;

namespace MVCAPIProject.Controllers
{
    [Authorize]
    public class DeviceManageController : ApiController
    {
        // GET api/devicemanage
        public DataSet Get()
        {
            DataAccessLayer.HardwareManagement cv = new DataAccessLayer.HardwareManagement();
            return cv.GetDetails();
        }
        // GET api/devicemanage/5
        public DataSet Get(int id)
        {
            DataAccessLayer.HardwareManagement gh = new DataAccessLayer.HardwareManagement();
            Models.Planets dv = new Models.Planets();
            dv.PlanetID = id;
            return gh.getCategoryGV(dv.PlanetID);
        }

        // POST api/devicemanage
        public async Task<int> Post([FromBody]Models.PlanetBooking book)
        {
            DataAccessLayer.HardwareManagement tb = new DataAccessLayer.HardwareManagement();
            return await tb.InsertToTemp(book);
        }

        // PUT api/devicemanage/5
        public async Task<int> Put(int id,[FromBody]Models.PlanetBooking deb)
        {
            DataAccessLayer.HardwareManagement tb = new DataAccessLayer.HardwareManagement();
            
            return await tb.UpdateToTemp(id,deb);
        }

        // DELETE api/devicemanage/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            DataAccessLayer.HardwareManagement tb = new DataAccessLayer.HardwareManagement();
            int res = await tb.DeleteRec(id);
            if (res > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
