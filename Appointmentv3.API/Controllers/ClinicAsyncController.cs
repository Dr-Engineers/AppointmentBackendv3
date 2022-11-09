﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Appointmentv3.BL;

namespace Appointmentv3.API.Controllers
{
    public class ClinicAsyncController : ApiController
    {
        IBusinessLayerAsync bl = null;
        public ClinicAsyncController(IBusinessLayerAsync bl)
        {
            this.bl = bl;
        }



        public IHttpActionResult GET()
        {
            return Ok(bl.getClinicAsync());
        }
    }
}