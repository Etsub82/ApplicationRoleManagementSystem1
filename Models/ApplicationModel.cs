using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationRoleManagementSystem1.Models
{
    public enum ApplicationStatus
    {
        PendingApproval,
        Approved,
        Rejected
    }

    public class ApplicationModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Name of the application

        [Required]
        public string AppId { get; set; } // Unique identifier

        [Required]
        public string AppKey { get; set; } // Secret key

        public ApplicationStatus Status { get; set; } = ApplicationStatus.PendingApproval;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
