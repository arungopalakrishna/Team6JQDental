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
    public class ACCOUNTsController : ApiController
    {
        private jqdentaldbEntities db = new jqdentaldbEntities();

        // GET: api/ACCOUNTs
        /*public IQueryable<Account> GetACCOUNTs()
        {
            return db.ACCOUNTs;
        }*/

        // GET: api/ACCOUNTs
        [ResponseType(typeof(String))]
        public async Task<IHttpActionResult> GetACCOUNTRegistrationStatus(int id)
        {
            String regStatus = "unregistered";
            ACCOUNT aCCOUNT = await db.ACCOUNTs.FindAsync(id);
            if(aCCOUNT.Password != String.Empty && aCCOUNT.Password != null && aCCOUNT.Password.Length >= 6)
            {
                regStatus = "registered";
            }

            return Ok(regStatus);
        }

        // GET: api/ACCOUNTs
        [ResponseType(typeof(String))]
        public async Task<IHttpActionResult> GetACCOUNTAuthentication(int accountID, string password)
        {
            String status = "bad";
            ACCOUNT aCCOUNT = await db.ACCOUNTs.FindAsync(accountID);
            if(aCCOUNT.Password == password)
            {
                status = "good";
            }
            return Ok(status);
        }


        // GET: api/ACCOUNTs
        [ResponseType(typeof(String))]
        public async Task<IHttpActionResult> GetACCOUNTAdminCheck(int id, string password)
        {
            String regStatus = "fail";
            ACCOUNT aCCOUNT = await db.ACCOUNTs.FindAsync(id);
            if (aCCOUNT.Password != String.Empty && aCCOUNT.Password != null && aCCOUNT.Password.Length >= 6)
            {
                regStatus = "success";
            }

            return Ok(regStatus);
        }



        // GET: api/ACCOUNTs/5
        [ResponseType(typeof(ACCOUNT))]
        public async Task<IHttpActionResult> GetACCOUNT(int id)
        {
            ACCOUNT aCCOUNT = await db.ACCOUNTs.FindAsync(id);
            if (aCCOUNT == null)
            {
                return NotFound();
            }

            return Ok(aCCOUNT);
        }

        // PUT: api/ACCOUNTs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutACCOUNT(int id, ACCOUNT aCCOUNT, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aCCOUNT.Account_ID)
            {
                return BadRequest();
            }

            db.Entry(aCCOUNT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ACCOUNTExists(id))
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

        // POST: api/ACCOUNTs
        [ResponseType(typeof(ACCOUNT))]
        public async Task<IHttpActionResult> PostACCOUNT(ACCOUNT aCCOUNT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ACCOUNTs.Add(aCCOUNT);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aCCOUNT.Account_ID }, aCCOUNT);
        }

        // DELETE: api/ACCOUNTs/5
        [ResponseType(typeof(ACCOUNT))]
        public async Task<IHttpActionResult> DeleteACCOUNT(int id)
        {
            ACCOUNT aCCOUNT = await db.ACCOUNTs.FindAsync(id);
            if (aCCOUNT == null)
            {
                return NotFound();
            }

            db.ACCOUNTs.Remove(aCCOUNT);
            await db.SaveChangesAsync();

            return Ok(aCCOUNT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ACCOUNTExists(int id)
        {
            return db.ACCOUNTs.Count(e => e.Account_ID == id) > 0;
        }
    }
}