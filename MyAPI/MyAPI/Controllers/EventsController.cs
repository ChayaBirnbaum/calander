using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        static private List<Event> events = new List<Event> { new Event { id = 1, title = "the first event",start=DateTime.Now } };
        int cnt = 2;
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

       

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event e)
        {
            events.Add(new Event {id=cnt,title=e.title,start=e.start });
            cnt++;
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event eve)
        {
            foreach (Event e in events)
            {
                if(e.id == id)
                {
                    e.title = eve.title;
                    e.start = eve.start;
                }
            }
            
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(e => e.id == id);
            events.Remove(eve);
        }
    }
}
