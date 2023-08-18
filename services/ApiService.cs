using Newtonsoft.Json;
using UsersAssessment.Models;

namespace UsersAssessment.services
{
    internal class ApiService : IApiService
    {
        private readonly HttpClient client = new HttpClient();
        public async Task<List<UserDTO>> GetUsersAsync()
        {
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<UserDTO> users = JsonConvert.DeserializeObject<List<UserDTO>>(responseBody);
                return users;
            }
            else
            {
                throw new Exception($"Error getting users: {response.StatusCode}");
            }
            
        }

        public async Task<List<PostDTO>> GetPostsAsync(int userId)
        {
            HttpResponseMessage response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts?userId={userId}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<PostDTO> posts = JsonConvert.DeserializeObject<List<PostDTO>>(responseBody);
                return posts;
            }
            else
            {
                throw new Exception($"Error getting post of that user: {response.StatusCode}");
            }
            
        }

        public async Task<List<CommentsDTO>> GetCommentsAsync(int postId)
        {
            HttpResponseMessage response = await client.GetAsync($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<CommentsDTO> comments = JsonConvert.DeserializeObject<List<CommentsDTO>>(responseBody);
                return comments;
            }
           else {
                throw new Exception($"Error getting comments of that post: {response.StatusCode}");
            }
           
        }
    }

}
