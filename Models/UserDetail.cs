using System;
using System.ComponentModel.DataAnnotations;

namespace SpacenditureAuthentication.Models
{
  public class UserDetail
  {
    [Required()]
    public string Id { get; set; }

    [Required()]
    public string Name { get; set; }

    [Required()]
    [EmailAddress()]
    public string EmailId { get; set; }

    [Required()]
    [MinLength(6)]
    public string UserName { get; set; }

    [Required()]
    [MinLength(8)]
    public string Password { get; set; }

    public DateTime Dob { get; set; }

    [Url()]
    public string AvatarUrl { get; set; }

    [EnumDataType(typeof(Gender))]
    public string Gender { get; set; }

    [MaxLength(250)]
    public string Bio { get; set; }
    public string Company { get; set; }

    [Phone()]
    public string PhoneNumber { get; set; }
  }

  public enum Gender
  {
    Male = 0,
    Female = 1,
    Other = 2
  }
}