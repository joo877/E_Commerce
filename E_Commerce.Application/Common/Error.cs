using System.Text.Json.Serialization;

namespace E_Commerce.Application.Common
{
    public sealed record Error(string Code, string Description, ErrorType ErrorType = ErrorType.Failure)
    {
        public static Error Failure(string code = "General.Failer", string description = "Generate Failure Has Occord")
       => new(code, description, ErrorType.Failure);
        public static Error Validation(string code = "General.Validation", string description = "Generate Validation Error Has Occord")
       => new(code, description, ErrorType.Validation);
        public static Error NotFound(string code = "General.NotFound", string description = "Generate NotFound Has Occord")
       => new(code, description, ErrorType.NotFound);
        public static Error Conflict(string code = "General.Conflict", string description = "Generate Conflict Has Occord")
       => new(code, description, ErrorType.Conflict);
        public static Error Unauthorized(string code = "General.Unauthorized", string description = "Access Is Denied   ")
       => new(code, description, ErrorType.Unauthorized);
        public static Error ForPiddin(string code = "General.ForPiddin", string description = "This Operation is ForPiddin  ")
       => new(code, description, ErrorType.ForPiddin);
        public static Error InvildCredentials(string code = "General.InvildCredentials", string description = "Provided Credentails  Are Invild")
       => new(code, description, ErrorType.InvildCredentials);


    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ErrorType
    { 
      Failure=0,
      Validation,
      NotFound,
      Conflict,
      Unauthorized,
      ForPiddin,
      InvildCredentials
        
        
     }

}