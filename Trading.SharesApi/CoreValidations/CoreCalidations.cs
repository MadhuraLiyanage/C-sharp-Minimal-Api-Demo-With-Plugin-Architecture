using Trading.BusinessModels;

namespace Trading.SharesApi.CoreValidations
{
    public static class CoreCalidations
    {
        public static (bool, string) Validate(SharesModel share)
        {
            var isValid = true;
            var message = string.Empty;

            if (share.Id == Guid.Empty)
            {
                isValid = false;
                message += "Id should not be empty.";
            }
            return (isValid, message);
        }
    }
}
