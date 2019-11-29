using System.Threading.Tasks;
using CheckSpammyEmailAddresses.Services.EmailReputation;
using Microsoft.AspNetCore.Identity;

namespace CheckSpammyEmailAddresses
{
    public class SpammyAddressUserValidator<TUser> : UserValidator<TUser> where TUser : class
    {
        private readonly EmailReputationService _emailReputationService;

        public SpammyAddressUserValidator(EmailReputationService emailReputationService)
        {
            _emailReputationService = emailReputationService;
        }

        public override async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {
            // Run the base validator and return the result if validation failed
            var result = await base.ValidateAsync(manager, user);
            if (!result.Succeeded)
                return result;

            // Check the email address reputation
            var emailAddress = await manager.GetEmailAsync(user);
            var reputation = await _emailReputationService.GetEmailReputation(emailAddress);

            // Fail validation if the email address is suspicious
            if (reputation.Suspicious)
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "SuspiciousEmail",
                    Description = "The email address supplied appears to be one associated with spamming activity."
                });

            return IdentityResult.Success;
        }
    }
}