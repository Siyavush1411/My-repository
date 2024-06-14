using MediatR;

namespace Application.Commands.Students.Delete
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public DeleteStudentCommand(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
