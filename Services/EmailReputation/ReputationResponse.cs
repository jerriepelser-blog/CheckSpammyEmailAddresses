using System.Text.Json.Serialization;

namespace CheckSpammyEmailAddresses.Services.EmailReputation
{
    public class ReputationResponse
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("reputation")]
        public string Reputation { get; set; }

        [JsonPropertyName("suspicious")]
        public bool Suspicious { get; set; }

        [JsonPropertyName("references")]
        public long References { get; set; }

        [JsonPropertyName("details")]
        public ReputationDetails Details { get; set; }

        public class ReputationDetails
        {
            [JsonPropertyName("blacklisted")]
            public bool Blacklisted { get; set; }

            [JsonPropertyName("malicious_activity")]
            public bool MaliciousActivity { get; set; }

            [JsonPropertyName("malicious_activity_recent")]
            public bool MaliciousActivityRecent { get; set; }

            [JsonPropertyName("credentials_leaked")]
            public bool CredentialsLeaked { get; set; }

            [JsonPropertyName("credentials_leaked_recent")]
            public bool CredentialsLeakedRecent { get; set; }

            [JsonPropertyName("data_breach")]
            public bool DataBreach { get; set; }

            [JsonPropertyName("first_seen")]
            public string FirstSeen { get; set; }

            [JsonPropertyName("last_seen")]
            public string LastSeen { get; set; }

            [JsonPropertyName("domain_exists")]
            public bool DomainExists { get; set; }

            [JsonPropertyName("domain_reputation")]
            public string DomainReputation { get; set; }

            [JsonPropertyName("new_domain")]
            public bool NewDomain { get; set; }

            [JsonPropertyName("days_since_domain_creation")]
            public long DaysSinceDomainCreation { get; set; }

            [JsonPropertyName("suspicious_tld")]
            public bool SuspiciousTld { get; set; }

            [JsonPropertyName("spam")]
            public bool Spam { get; set; }

            [JsonPropertyName("free_provider")]
            public bool FreeProvider { get; set; }

            [JsonPropertyName("disposable")]
            public bool Disposable { get; set; }

            [JsonPropertyName("deliverable")]
            public bool Deliverable { get; set; }

            [JsonPropertyName("accept_all")]
            public bool AcceptAll { get; set; }

            [JsonPropertyName("valid_mx")]
            public bool ValidMx { get; set; }

            [JsonPropertyName("spoofable")]
            public bool Spoofable { get; set; }

            [JsonPropertyName("spf_strict")]
            public bool SpfStrict { get; set; }

            [JsonPropertyName("dmarc_enforced")]
            public bool DmarcEnforced { get; set; }

            [JsonPropertyName("profiles")]
            public string[] Profiles { get; set; }
        }
    }
}