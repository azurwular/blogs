using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;
using CBA.AP.Blog.Domain.Models;
using CBA.AP.Blog.Domain.Repositories;
using Dapper;

namespace CBA.AP.Blog.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DbContext dbContext;
        
        public PostRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Post> GetAsync(int id)
        {
            const string query = "SELECT p.id, p.title, p.content, p.created, p.lastModified, c.id, c.commenter, c.created,  " +
                                 "FROM posts p " +
                                 "LEFT JOIN comments c ON p.id = c.postId " +
                                 "WHERE p.Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            
            using (var connection = this.dbContext.GetConnection())
            {
                Post result = null;
                
                await connection.QueryAsync<Post, Comment, Post>(
                    query,
                    (p, c) =>
                    {
                        if (result == null)
                        {
                            result = new Post
                            {
                                Id = p.Id,
                                Created = p.Created,
                                Title = p.Title,
                                Content = p.Content,
                                LastModified = p.LastModified,
                                Comments = new List<Comment>()
                            };
                        }

                        if (c != null)
                        {
                            result.Comments.Add(c);
                        }

                        return result;
                    },
                    parameters);

                return result;
            }
        }

        public async Task<IEnumerable<Post>> GetAsync(int count, int page)
        {
            const string query = "SELECT id, title, content, created, lastModified " +
                                 "FROM posts " +
                                 "ORDER BY created DESC " +
                                 "LIMIT @Count OFFSET @Offset";

            var offset = (page - 1) * count;
            var parameters = new DynamicParameters();
            parameters.Add("@Count", count);
            parameters.Add("@Offset", offset);
            
            using (var connection = this.dbContext.GetConnection())
            {
                return await connection.QueryAsync<Post>(query, parameters);
            }
        }

        public async Task CreateAsync(Post post)
        {
            const string query = "INSERT INTO posts (title, content, created) " +
                                 "VALUES (@dbtitle, @dbcontent, @dbcreated)";

            var parameters = new DynamicParameters();
            parameters.Add("@dbtitle", post.Title);
            parameters.Add("@dbcontent", post.Content);
            parameters.Add("@dbcreated", DateTime.UtcNow);
            
            using (var connection = this.dbContext.GetConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateAsync(Post post)
        {
            const string query = "UPDATE posts " +
                                 "SET title = @dbtitle, content = @dbcontent, lastModified = @lastModified" +
                                 "WHERE id = @dbid";
            
            var parameters = new DynamicParameters();
            parameters.Add("@dbtitle", post.Title);
            parameters.Add("@dbcontent", post.Content);
            parameters.Add("@dblastModified", DateTime.UtcNow);
            parameters.Add("@dbid", post.Id);
            
            using (var connection = this.dbContext.GetConnection())
            {
                 await connection.ExecuteAsync(query, parameters);
            }
        }
        
        public async Task<Post> GetByIdAsync(int postId)
        {
            const string query = "SELECT id, title, content " +
                                 // kane join me comments table gia na pareis kai ta comments
                                 "FROM posts where Id = @Id";
            
            // const string commentsQuery = ..
            
            var parameters = new DynamicParameters();
            parameters.Add("@Id", postId);
            
            using (var connection = this.dbContext.GetConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Post>(query, parameters);
                // gia polla result await connection.QueryAsync<Post>(query, parameters);

                //gia inserts/updates await connection.ExecuteAsync(query)
            }
        }
        
        
        
        // Task<IEnumerable<Post>> GetLatestAsync(int count)
        // Task CreatePostAsync(Post post)

//        public async Task CreatePostAsync(Post post)
//        {
//            const string query = "INSERT INTO posts (PostTitle), (PostContent) VALUES (@post.Title , @post.Content)";
//            
//            post.Created = DateTime.UtcNow;
//            var parameters = new DynamicParameters();
//            parameters.Add("@Id", postId);
//            parameters.Add()
//
//        }
        // Task UpdatePostAsync(Post post)
//        public async Task UpdatePostAsync(Post post)
//        {
//            const string query = "UPDATE posts set content = @content where Id = @Id", new {post.Content, post.Id}
//        }
        
        // Task DeletePostAsync(int postId)
//        public async Task DeletePostAsync(int postId)
//        {
//            const string query = "DELETE * FROM posts WHERE Id = @Id";
//            
//            var parameters = new DynamicParameters();
//            parameters.Add("@Id", postId);
//
//            using (var connection = this.dbContext.GetConnection())
//            {
//                return await connection.(query, parameters);
//            }
//        }
    }
}