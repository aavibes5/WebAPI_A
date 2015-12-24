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
    public class DeviceManageController : ApiController
    {
        // GET api/devicemanage
        public List<MVCAPIProject.Models.PlanetBooking> Get()
        {
            List<MVCAPIProject.Models.PlanetBooking> apj = new List<MVCAPIProject.Models.PlanetBooking>();
            DataAccessLayer.HardwareManagement cv = new DataAccessLayer.HardwareManagement();
            DataSet ds = cv.GetDetails();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                MVCAPIProject.Models.PlanetBooking obj = new Models.PlanetBooking()
                {
                    PlanetID = int.Parse(item["PlanetID"].ToString()),
                    HumanName = item["HumanName"].ToString(),
                    EID = int.Parse(item["E-ID"].ToString()),
                    Gender = item["Gender"].ToString(),
                    FamilySize = int.Parse(item["FamilySize"].ToString())

                };
                apj.Add(obj);
            }
            return apj;
        } 
        // GET api/devicemanage/5
        public List<MVCAPIProject.Models.PlanetBooking> Get(int id)
        {
            List<MVCAPIProject.Models.PlanetBooking> ap = new List<MVCAPIProject.Models.PlanetBooking>();
            DataAccessLayer.HardwareManagement gh = new DataAccessLayer.HardwareManagement();
            Models.PlanetBooking dv = new Models.PlanetBooking();
            dv.EID = id;
            DataSet ds = gh.getCategoryGV(dv.EID);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                MVCAPIProject.Models.PlanetBooking obj = new Models.PlanetBooking()
                {
                    PlanetID = int.Parse(item["PlanetID"].ToString()),
                    HumanName = item["HumanName"].ToString(),
                    EID = int.Parse(item["E-ID"].ToString()),
                    Gender = item["Gender"].ToString(),
                    FamilySize = int.Parse(item["FamilySize"].ToString())

                };
                ap.Add(obj);
            }
            return ap;

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
