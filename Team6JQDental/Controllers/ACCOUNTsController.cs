﻿using System;
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

        //PUT api/ACCOUNT/Payment
        [ResponseType(typeof(String))]
        public async Task<IHttpActionResult> PutACCOUNTPayment(Payment payment)
        {
            String paymentStatus = "fail";

            if (!ModelState.IsValid)
            {
                paymentStatus = "fail";
                return Ok(paymentStatus);
            }

            PAYMENT paymentObj = new PAYMENT();
            paymentObj.Account_ID = payment.Account_ID;
            paymentObj.Payment_Amount = payment.Payment_Amount;
            paymentObj.Payment_Date = payment.Payment_Date;

            db.PAYMENTs.Add(paymentObj);

            await db.SaveChangesAsync();

            paymentStatus = "good";
            return Ok(paymentStatus);
        }

        // PUT: api/ACCOUNTs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutACCOUNT(Account account, Patient patient)
        {
            String addStatus = "fail";
            return Ok(addStatus);
        }

        // POST: api/ACCOUNTs
        [ResponseType(typeof(ACCOUNT))]
        public async Task<IHttpActionResult> PostACCOUNT(Account account)
        {
            String addStatus = "fail";
            ACCOUNT aCCOUNT = new ACCOUNT();
            account.Password = account.Password;

            if (!(account.Account_ID > 0))
            {
                db.ACCOUNTs.Add(aCCOUNT);
                aCCOUNT.Account_Balance = 0;
                await db.SaveChangesAsync();
            }
            else 
            {
                var accExists = db.ACCOUNTs.First(a => a.Account_ID == account.Account_ID);
                if(accExists != null && accExists.Account_ID > 0)
                {
                    aCCOUNT.Account_ID = account.Account_ID;
                }
                else
                {
                    return Ok(addStatus);
                }
            }

            PATIENT pATIENT = new PATIENT();
            pATIENT.Account_ID = aCCOUNT.Account_ID;
            pATIENT.Patient_DOB = account.patient.Patient_DOB;
            pATIENT.Patient_First_Name = account.patient.Patient_First_Name;
            pATIENT.Patient_Last_Name = account.patient.Patient_Last_Name;
            pATIENT.Patient_Phone_Primary = account.patient.Patient_Phone_Primary;
            pATIENT.Patient_Street = account.patient.Patient_Street;
            pATIENT.Patient_SSN = account.patient.Patient_SSN;
            pATIENT.Patient_Phone_Secondary = account.patient.Patient_Phone_Secondary;
            pATIENT.Patient_Allergies = account.patient.Patient_Allergies;

            db.PATIENTs.Add(pATIENT);
            await db.SaveChangesAsync();

            addStatus = "good";

            return Ok(addStatus);
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