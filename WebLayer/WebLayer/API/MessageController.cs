using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    public class MessageController : ApiController
    {
        // GET: api/Message
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        // GET: api/Message/5
        public IEnumerable<Message> GetMessageByID(int id)
        {
            Message ST = new Message();
            Message ST1 = new Message();
            List<Message> li = new List<Message>();
            if (id == 1)
            {

                ST.PostMessage = "Hej min fina vän";
                ST.UserID = 1;
                ST.MessageID = 1;
                ST.PostUserID = 2;
                li.Add(ST);
            }
            else {
                ST1.PostMessage = "Hej min finaare vän";
                ST1.UserID = 2;
                ST1.MessageID = 1;
                ST1.PostUserID = 1;

                
                li.Add(ST1);
            }
            return li;
        }
        [HttpGet]
        public IEnumerable<Message> GetAllMessageDetails()
        {
            Message ST = new Message();
            Message ST1 = new Message();
            List<Message> li = new List<Message>();

            ST.PostMessage= "Hej min fina vän";
            ST.UserID = 1;
            ST.MessageID = 1;
            ST.PostUserID = 2;

            ST1.PostMessage = "Hej min finaare vän";
            ST1.UserID = 2;
            ST1.MessageID = 1;
            ST1.PostUserID = 1;

            li.Add(ST);
            li.Add(ST1);
            return li;
        }
        [HttpPost]
        // POST: api/Message
        public void Post([FromBody]Message ms)
        {
        }
        [HttpPut]
        // PUT: api/Message/5
        public void Put(int id, [FromBody]Message ms)
        {
        }
        [HttpDelete]
        // DELETE: api/Message/5
        public void DeleteMessage(int id)
        {
        }
    }
}
