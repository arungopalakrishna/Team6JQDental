using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Team6JQDental;
using Team6JQDental.Models;

namespace Team6JQDental.Controllers
{
    public class VISITsController : ApiController
    {
        private jqdentaldbEntities db = new jqdentaldbEntities();

        // GET: api/VISITs
        public IQueryable<Visit> GetVISITs()
        {
            List<Visit> visitList = new List<Visit>();
            Visit visit;

            foreach (VISIT v in db.VISITs)
            {
                visit = new Visit();
                visit.Visit_ID = v.Visit_ID;
                visit.Patient_ID = v.Patient_ID;
                visit.Dentist_ID = v.Dentist_ID;
                visit.Visit_Date = v.Visit_Date;
                visit.Visit_Time = v.Visit_Time;
                //visit.Dentist    = v.DENTIST;
                //visit.Patient    = v.PATIENT; 
                //visit.ScheduledServiceList = v.COMPLETED_SERVICE;
               
                visitList.Add(visit);
            }

            return visitList.AsQueryable();
        }

        // GET: api/VISITs/5
        [ResponseType(typeof(VISIT))]
        public async Task<IHttpActionResult> GetVISIT(int id)
        {
            VISIT vISIT = await db.VISITs.FindAsync(id);
            if (vISIT == null)
            {
                return NotFound();
            }

            return Ok(vISIT);
        }

        // PUT: api/VISITs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVISIT(int id, VISIT vISIT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vISIT.Visit_ID)
            {
                return BadRequest();
            }

            db.Entry(vISIT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VISITExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VISITs
        [ResponseType(typeof(VISIT))]
        public async Task<IHttpActionResult> PostVISIT(VISIT vISIT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VISITs.Add(vISIT);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vISIT.Visit_ID }, vISIT);
        }

        // DELETE: api/VISITs/5
        [ResponseType(typeof(VISIT))]
        public async Task<IHttpActionResult> DeleteVISIT(int id)
        {
            VISIT vISIT = await db.VISITs.FindAsync(id);
            if (vISIT == null)
            {
                return NotFound();
            }

            db.VISITs.Remove(vISIT);
            await db.SaveChangesAsync();

            return Ok(vISIT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VISITExists(int id)
        {
            return db.VISITs.Count(e => e.Visit_ID == id) > 0;
        }
    }
}