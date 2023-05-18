using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace HotelManagement_Customer.Service
{
    public interface IPasswordResetService
    {
        void SendPasswordResetLink(string email);
    }

    public class PasswordResetService : IPasswordResetService
    {
        private readonly IUserAccountRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _resetPasswordLink; // The URL to the password reset page

        public PasswordResetService(IUserAccountRepository userRepository, IUnitOfWork unitOfWork, string resetPasswordLink)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _resetPasswordLink = resetPasswordLink;
        }

        public void SendPasswordResetLink(string email)
        {
            // Get the user by email
            UserAccount user = _userRepository.GetUserByEmail(email);

            if (user != null)
            {
                // Generate a unique password reset token (e.g., using Guid)
                string resetToken = Guid.NewGuid().ToString();

                // Set the password reset token and its expiration time for the user
                user.ResetToken = resetToken;
                user.ResetTokenExpiration = DateTime.Now.AddDays(1); // Token expires in 1 day

                // Update the user in the repository
                _userRepository.Update(user);
                _unitOfWork.Commit();

                // Compose the email body with the reset link
                string emailBody = $"Hello {user.FullName},\n\n" +
                    $"You have requested to reset your password. Please click on the following link to reset your password:\n" +
                    $"{_resetPasswordLink}?token={resetToken}\n\n" +
                    $"If you didn't request a password reset, please ignore this email.\n\n" +
                    $"Best regards,\nThe Hotel Management Team";

                // Send the password reset email to the user
                SendEmail(user.Email, "Password Reset", emailBody);
            }
        }

        private void SendEmail(string recipientEmail, string subject, string body)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string senderEmail = "hotelmanagementtest@gmail.com";
            string senderPassword = "A@1234567";
            bool enableSsl = true;

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = enableSsl;

                using (MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail))
                {
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;

                    smtpClient.Send(mailMessage);
                }
            }
        }
    }
}
