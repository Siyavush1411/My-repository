using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Students.Update
{
    public class UpdateStudentCommand : IRequest<int>
    {

        public int UserId { get; set; }
        public string Firstame { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public UpdateStudentCommand(int userId, string firstame, string lastname, string phoneNumber, string login, string password)
        {
            UserId = userId;
            Firstame = firstame;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            Login = login;
            Password = password;
        }
    }
}
