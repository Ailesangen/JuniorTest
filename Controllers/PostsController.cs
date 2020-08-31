using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmplDBA.API.Data;
using EmplDBA.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmplDBA.API.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        DataContext db;
        public PostsController(DataContext context)
        {
            db = context;
            if (!db.Posts.Any())
            {
                db.Posts.Add(new Post { PostName = "Director"});
                db.Posts.Add(new Post { PostName = "Junior" });
                db.SaveChanges();
            }
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            return await db.Posts.ToListAsync();
        }
 
        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            Post post = await db.Posts.FirstOrDefaultAsync(x => x.PostID == id);
            if (post == null)
                return NotFound();
            return new ObjectResult(post);
        }
 
        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Post>> Post(Post user)
        {
            if (user == null)
            {
                return BadRequest();
            }
 
            db.Posts.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
 
        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Post>> Put(Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }
            if (!db.Posts.Any(x => x.PostID == post.PostID))
            {
                return NotFound();
            }
 
            db.Update(post);
            await db.SaveChangesAsync();
            return Ok(post);
        }
 
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> Delete(int id)
        {
            Post post = db.Posts.FirstOrDefault(x => x.PostID == id);
            if (post == null)
            {
                return NotFound();
            }
            db.Posts.Remove(post);
            await db.SaveChangesAsync();
            return Ok(post);
        }
    }
}