using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;

namespace ma.Areas.Account.Models
{
    public class Base
    {
        public ObjectId Id { get; set; }
    }

    public class WebpagesMembership
    {
        [BsonId]
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string ConfirmationToken { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.Boolean> IsConfirmed { get; set; }
        public Nullable<System.DateTime> LastPasswordFailureDate { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> PasswordChangedDate { get; set; }
        public Int32 PasswordFailuresSinceLastSuccess { get; set; }
        public System.String PasswordSalt { get; set; }
        public System.String PasswordVerificationToken { get; set; }
        public Nullable<System.DateTime> PasswordVerificationTokenExpirationDate { get; set; }
    }

    public class UserProfile
    {
        [BsonId]
        public int UserId { get; set; }
        public string UserName { get; set; }

        //FB Login Result Properties
        [BsonIgnoreIfNull]
        public string FbUsername { get; set; }
        [BsonIgnoreIfNull]
        public string FbUserId { get; set; }
        [BsonIgnoreIfNull]
        public string FullName { get; set; }
        [BsonIgnoreIfNull]
        public string Link { get; set; }
        [BsonIgnoreIfNull]
        public string Mobile { get; set; }

        public bool Verified { get; set; }

        [BsonIgnore]
        public string FbPictureLink
        {
            get
            {
                return String.Format("http://graph.facebook.com/{0}/picture", FbUserId);
            }
        }
    }

    public class WebpagesOauthToken : Base
    {
        public string Token { get; set; }
        public string Secret { get; set; }
    }

    public class WebpagesOauthMembership : Base
    {
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        //FK
        public int UserId { get; set; }
    }

    public class WebpagesRole
    {
        [BsonId]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class WebpagesUsersInRole : Base
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Personal page link")]
        public string Link { get; set; }

        [Display(Name = "Facebook Username")]
        public string FbUsername { get; set; }

        [Display(Name = "Facebook UserId")]
        public string FbUserId { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}