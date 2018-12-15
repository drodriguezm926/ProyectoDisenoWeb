using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WSCard.App_Data;

namespace WSCard.Controllers
{
    public class TarjetasController : ApiController
    {
        private wscardsDB db = new wscardsDB();

        // GET: api/Tarjetas
        public IQueryable<Tarjeta> GetTarjeta()
        {
            return db.Tarjeta;
        }

        // GET: api/Tarjetas/5
        [ResponseType(typeof(Tarjeta))]
        public IHttpActionResult GetTarjeta(int id)
        {
            Tarjeta tarjeta = db.Tarjeta.Find(id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            return Ok(tarjeta);
        }

        // PUT: api/Tarjetas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTarjeta(Tarjeta tarjeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*if (id != tarjeta.codTarjeta)
            {
                return BadRequest();
            }*/

            var data = (from info in db.Tarjeta
                        where info.numeroTarjeta.Equals(tarjeta.numeroTarjeta)
                        select info).SingleOrDefault();

            if (data == null)
            {
                //La tarjeta no fue encontrada
                return BadRequest("Tarjeta no encontrada");
            }
            else
            {
                if (!data.cvv.Equals(tarjeta.cvv))
                {
                    //CVV incorrecto
                    return BadRequest("Código cvv incorrecto");
                }
                else
                {
                    if (tarjeta.fechaExpiracion < DateTime.Now)
                    {
                        return BadRequest("Verifica la fecha de expiración");
                    }
                    else
                    {
                        //Si es debito
                        if (data.tipoTarjeta.Equals("Debito"))
                        {
                            //Si el saldo actual cubre los boletod a comprar
                            if (data.saldo_disponible > tarjeta.saldo_disponible)
                            {
                                //Resta a los ahorros 
                                data.saldo_disponible = data.saldo_disponible - tarjeta.saldo_disponible;
                                db.Entry(data).State = EntityState.Modified;
                            }
                            else
                            {
                                return BadRequest("Fondos insuficientes");
                            }
                        }
                        //Si es credito
                        else
                        {
                            //Si el saldo a credito ya supero su limite
                            if (data.saldo_disponible < data.limite_credito)
                            {
                                //Suma el credito
                                data.saldo_disponible = data.saldo_disponible + tarjeta.saldo_disponible;
                                db.Entry(data).State = EntityState.Modified;
                            }
                            else
                            {
                                return BadRequest("Límite de crédito superado");
                            }
                        }
                    }
                }
            }
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tarjetas
        [ResponseType(typeof(Tarjeta))]
        public IHttpActionResult PostTarjeta(Tarjeta tarjeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tarjeta.Add(tarjeta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TarjetaExists(tarjeta.codTarjeta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tarjeta.codTarjeta }, tarjeta);
        }

        // DELETE: api/Tarjetas/5
        [ResponseType(typeof(Tarjeta))]
        public IHttpActionResult DeleteTarjeta(int id)
        {
            Tarjeta tarjeta = db.Tarjeta.Find(id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            db.Tarjeta.Remove(tarjeta);
            db.SaveChanges();

            return Ok(tarjeta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TarjetaExists(int id)
        {
            return db.Tarjeta.Count(e => e.codTarjeta == id) > 0;
        }
    }
}