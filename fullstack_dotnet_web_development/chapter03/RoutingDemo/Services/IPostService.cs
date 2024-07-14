using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoutingDemo.Models;

namespace RoutingDemo.Services
{
    public interface IPostService
    {
        Task CreatePost(Post item);
        Task<Post?> UpdatePost(int id, Post item);
        Task<Post?> GetPost(int id);
        Task<List<Post>> GetAllPosts();
        Task DeletePost(int id);
    }
}