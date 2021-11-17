using BLL.BEnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsPortal.Controllers
{
    public class CatagoryController : ApiController
    {

        [Route("api/Catagory")]
        [HttpGet]
        public List<CatagoryModel> GetAll()
        {
            return CatagoryService.Get();
        }

        [Route("api/Catagory/Create")]
        [HttpPost]
        public void Add(CatagoryModel n)
        {
            CatagoryService.Add(n);
        }
        [Route("api/Catagory/Edit/{id}")]
        [HttpPost]
        public void Edit(CatagoryModel n)
        {
            CatagoryService.Edit(n);
        }
        [Route("api/Catagory/Delete/{id}")]
        public void Delete([FromUri] int id)
        {
            CatagoryService.Delete(id);
            //return id;
        }

    }
}
