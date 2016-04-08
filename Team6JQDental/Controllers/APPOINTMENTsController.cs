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
    public class APPOINTMENTsController : ApiController
    {
        private jqdentaldbEntities db = new jqdentaldbEntities();

        // GET: api/APPOINTMENTs
        public IQueryable<Appointment> GetAPPOINTMENTs()
        {
            List<Appointment> appointmentList = new List<Appointment>();
            Appointment appointment;
            
            foreach(APPOINTMENT a in db.APPOINTMENTs)
            {
                appointment = new Appointment();
                appointment.Appointment_Date = a.Appointment_Date;
                appointment.Appointment_Time = a.Appointment_Time;
                appointment.Dentist_ID = a.Dentist_ID;
                appointment.Patient_ID = a.Patient_ID;
                //appointment.Scheduled_ServiceID = a.SCHEDULED_SERVICE.s;
                appointmentList.Add(appointment);
            }

            return appointmentList.AsQueryable();
        }

        // GET: api/APPOINTMENTs/5
        [ResponseType(typeof(APPOINTMENT))]
        public async Task<IHttpActionResult> GetAPPOINTMENT(int id)
        {
            APPOINTMENT aPPOINTMENT = await db.APPOINTMENTs.FindAsync(id);
            if (aPPOINTMENT == null)
            {
                return NotFound();
            }

            return Ok(aPPOINTMENT);
        }

        // PUT: api/APPOINTMENTs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAPPOINTMENT(int id, APPOINTMENT aPPOINTMENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPPOINTMENT.Appointment_ID)
            {
                return BadRequest();
            }

            db.Entry(aPPOINTMENT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APPOINTMENTExists(id))
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

        // POST: api/APPOINTMENTs
        [ResponseType(typeof(APPOINTMENT))]
        public async Task<IHttpActionResult> PostAPPOINTMENT(APPOINTMENT aPPOINTMENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APPOINTMENTs.Add(aPPOINTMENT);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aPPOINTMENT.Appointment_ID }, aPPOINTMENT);
        }

        // DELETE: api/APPOINTMENTs/5
        [ResponseType(typeof(APPOINTMENT))]
        public async Task<IHttpActionResult> DeleteAPPOINTMENT(int id)
        {
            APPOINTMENT aPPOINTMENT = await db.APPOINTMENTs.FindAsync(id);
            if (aPPOINTMENT == null)
            {
                return NotFound();
            }

            db.APPOINTMENTs.Remove(aPPOINTMENT);
            await db.SaveChangesAsync();

            return Ok(aPPOINTMENT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APPOINTMENTExists(int id)
        {
            return db.APPOINTMENTs.Count(e => e.Appointment_ID == id) > 0;
        }
    }
}