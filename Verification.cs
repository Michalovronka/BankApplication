using System;

namespace BankApplication
{
    class Verification
    {
        public string Verifier { get; set; }
        private DateTime VerificationDate { get; set; }
        public VerificationResults VerificationResult { get; set; }
        public string FurtherInfo  { get; set; }

        public Verification(string verifier, DateTime verificationDate, VerificationResults verificationResult, string furtherInfo)
        {
            Verifier = verifier;
            VerificationDate = verificationDate;
            VerificationResult = verificationResult;

            if(VerificationResult == VerificationResults.Denied || VerificationResult == VerificationResults.FurtherVerificationNeeded)
            {
                FurtherInfo = furtherInfo;
            }
            else
            {
                FurtherInfo = "no";
            }
        }

    }
    enum VerificationResults
    {
        Unknown,
        Verified,
        Denied,
        FurtherVerificationNeeded
    }
}
