using Fribergs_rentals_2.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fribergs_rentals_2
{
    /// <summary>
    /// Custom validation attribute to make a null Administrator valid when evaluating modelstate of a Booking
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AllowNullAdministratorAttribute : ValidationAttribute
    {
        IAdministrator adminRepo;
        public AllowNullAdministratorAttribute(IAdministrator adminRepo) : this()
        {
            this.adminRepo = adminRepo;
        }

        public AllowNullAdministratorAttribute()
        {

        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            // Allow null values for AdministratorId
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else if (value is int administratorId)
            {
                if (adminRepo.GetAdminById(administratorId) == null)
                {
                    return new ValidationResult("Administrator doesn't exist.");
                }
                else if (adminRepo.GetAdminById(administratorId) != null)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Administrator doesn't exist.");
        }
    }
}
