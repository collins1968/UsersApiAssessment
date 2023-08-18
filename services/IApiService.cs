using UsersAssessment.Models;

namespace UsersAssessment.services
{
    public interface IApiService
    {
        Task<List<UserDTO>> GetUsersAsync();
        Task<List<PostDTO>> GetPostsAsync(int userId);
        Task<List<CommentsDTO>> GetCommentsAsync(int postId);
    }
}
