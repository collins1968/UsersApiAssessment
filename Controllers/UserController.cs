using System;
using System.ComponentModel.Design;
using UsersAssessment.Models;
using UsersAssessment.services;

namespace UsersAssessment.Controllers
{
    public class UserController
    { 
    IApiService apiService = new ApiService();
    
        public async Task UsersMenu()
        {
            Console.WriteLine("Welcome to the Users App!");
            Console.WriteLine("Please select an option");
            Console.WriteLine("1. Get all users");
            Console.WriteLine("2. Get all posts by user ID");
            Console.WriteLine("3. Get all comments by post ID");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your selection: ");
            var selection = Console.ReadLine();
          if (!string.IsNullOrEmpty(selection))
            {
                switch (selection)
                {
                    case "1":
                        await GetAllUsers();
                        break;
                    case "2":
                        await GetAllPostsByUserId();
                        break;
                    case "3":
                        await GetAllCommentsByPostId();
                        break;
                    case "4":
                        await Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }   
            }
          else
            {
                Console.WriteLine("Invalid selection. Please try again.");
                await UsersMenu();
            }
            }
        private async Task GetAllUsers()
        {
            List<UserDTO> users = await apiService.GetUsersAsync();
            await Console.Out.WriteLineAsync("These are all the users");
            foreach (var user in users)
            {
                Console.WriteLine($"User ID: {user.id}, Username: {user.username}");
            }
            await UsersMenu();
        }

        private async Task GetAllPostsByUserId()
        {
            Console.Write("Enter a user ID: ");
            int userId = int.Parse(Console.ReadLine());
            List<PostDTO> posts = await apiService.GetPostsAsync(userId);

            foreach (var post in posts)
            {
                Console.WriteLine($"Post ID: {post.id}, Title: {post.title} Body: {post.body}");
            }
            await UsersMenu();
        }

        private async Task GetAllCommentsByPostId()
        {
            Console.Write("Enter a post ID: ");
            int postId = int.Parse(Console.ReadLine());
            List<CommentsDTO> comments = await apiService.GetCommentsAsync(postId);

            foreach (var comment in comments)
            {
                Console.WriteLine($"Comment ID: {comment.id}, Name: {comment.name},\nEmail: {comment.email}, Body: {comment.body}");
            }
            await UsersMenu();
        }

        private async Task Exit()
        {
            Console.WriteLine("Goodbye!");
            //await UsersMenu();
        }
    }
}
