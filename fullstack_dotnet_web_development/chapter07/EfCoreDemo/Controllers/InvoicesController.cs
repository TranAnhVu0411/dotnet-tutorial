using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EfCoreDemo.Models;
using EfCoreDemo.Data;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace EfCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController(InvoiceDbContext _context, ILogger<InvoicesController> logger) : ControllerBase
    {
        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices(InvoiceStatus? status, int page=1, int pageSize=10)
        {
            // Use IQueryable
            logger.LogInformation($"Creating the IQueryable...");
            var list1 = _context.Invoices.Where(x => status == null || x.Status == status);
            logger.LogInformation("IQueryable created");
            var query1 = list1.OrderByDescending(x => x.InvoiceDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
            logger.LogInformation("Execute the query using IQueryable");
            var result1 = await query1.ToListAsync();
            logger.LogInformation("Result created using IQueryable");
            return result1;

            // // Use IEnumerable
            // logger.LogInformation($"Creating the IEnumerable...");
            // var list2 = _context.Invoices.Where(x => status == null || x.Status == status).AsEnumerable();
            // logger.LogInformation("IEnumerable created");
            // logger.LogInformation("Query the result using IEnumerable");
            // var query2 = list2.OrderByDescending(x => x.InvoiceDate)
            // .Skip((page - 1) * pageSize)
            // .Take(pageSize);
            // logger.LogInformation("Execute the query using IEnumerable");
            // var result2 = query2.ToList();
            // logger.LogInformation("Result created using IEnumerable");
            // return result2;

            // // Use Raw SQL Query
            // // Advoid SQL Injection Attack
            // // (FromSql() parameterized every variable inside (status))
            // // Note: Get status value using status.ToString()
            // // (Answer from https://stackoverflow.com/a/16084582)
            // var list = await _context.Invoices
            //     .FromSql($"SELECT * FROM Invoices WHERE Status={status.ToString()}")
            //     .ToListAsync();
            // return list;
        }

        [HttpGet]
        [Route("free-search")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices(string propertyName, string propertyValue)
        {
            // Input Example: propertyName = "Status", propertyValue = "Draft"/"Paid"/"AwaitPayment"
            if (_context.Invoices == null)
            {
                return NotFound("Invoices not found");
            }
            // Do something to sanitize the property name value
            // Eg: Check if value contain special characters (such as "--")
            // If so, throw exception or remove that special characters
            var value = new MySqlParameter("value", propertyValue); // Use MySqlParameter for MySql
            // // Warning: SQL Injection Attack 
            // // (FromSqlRaw() not parameterized every variable inside (propertyName)
            var list = await _context.Invoices
                .FromSqlRaw($"SELECT * FROM Invoices WHERE {propertyName}=@value", value)
                .ToListAsync();
            return list;
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<Invoice>>> SearchInvoices(string search)
        {
            if (_context.Invoices == null)
            {
                return NotFound();
            }
            var list = await _context.Invoices
            // // The below code will throw an exception if the CalculatedTax method is not static
            // .Where(x => (x.ContactName.Contains(search) || x.InvoiceNumber.Contains(search)) && CalculateTax(x.Amount) > 10)
            .Where(x => (x.ContactName.Contains(search) || x.InvoiceNumber.Contains(search)))
            .Select(x => new Invoice
            {
                Id = x.Id,
                InvoiceNumber = x.InvoiceNumber,
                ContactName = x.ContactName,
                Description = $"Tax: ${CalculateTax(x.Amount)}. {x.Description}",
                Amount = x.Amount,
                InvoiceDate = x.InvoiceDate,
                DueDate = x.DueDate,
                Status = x.Status
            }).ToListAsync();
            return list;
        }

        private static decimal CalculateTax(decimal amount)
        {
            return amount * 0.15m;
        }

        [HttpGet]
        [Route("ids")]
        public ActionResult<IEnumerable<Guid>> GetInvoiceIds(string status)
        {
            var result = _context.Database.SqlQuery<Guid>($"SELECT Id FROM Invoices WHERE Status={status}").ToList();
            return result;
        }
        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(Guid id)
        {
            // var invoice = await _context.Invoices.FindAsync(id);
            var invoice = await _context.Invoices.SingleAsync(i => i.Id == id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(Guid id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut]
        [Route("status/overdue")]
        public async Task<ActionResult> UpdateInvoiceStatusAsOverdue(DateTime dueDate)
        {
            // Bulk update 
            // (if dueDate is after InvoiceDate or Status == AwaitPayment)
            var result = await _context.Invoices
                .Where(i => i.InvoiceDate < dueDate || i.Status == InvoiceStatus.AwaitPayment)
                .ExecuteUpdateAsync(
                    s => s.SetProperty(x => x.Status, InvoiceStatus.Overdue)
                        .SetProperty(x => x.Amount, 0)
                );
            return Ok();
        }

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = invoice.Id }, invoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("status")]
        public async Task<ActionResult> Delete(string status)
        {
            // // Delete Invoice directly 
            // (Without loading all invoice with specific status and removing one by one)
            var result = await _context.Database.ExecuteSqlAsync($"DELETE FROM Invoices WHERE Status={status}");
            return Ok(); 
        }

        private bool InvoiceExists(Guid id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
