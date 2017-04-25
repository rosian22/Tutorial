
namespace SitulClasei.Common
{
	[Foundation.Preserve(AllMembers = true)]
    public class StatusContants
    {
	    public const string SUCCESS_PROFILE_UPDATED = "Your profile was successfully updated";
        public const string SUCCESSS_SHIFT_OFFER_ACCEPTED = "Shift was successfully accepted";
        public const string SUCCESS_SIGN_UP = "You have successfully signed up";
        public const string SUCCESS_SIGN_IN = "You have successfully signed in";
        public const string SUCCESS_SIGN_OUT = "You have successfully signed out";
        public const string SUCCESS_YOUR_PASSWORD_WAS_RESET = "The request was sent to your email";
        public const string SUCCESSS_SHIFT_OFFER_CANCELLED = "Shift was cancelled";
        public const string SUCCESSS_SHIFT_OFFER_DECLINED = "Shift was declined";
        public const string SUCCESSS_SHIFT_OFFER_CHECKED_IN = "You have successfully checked in";
        public const string SUCCESSS_SHIFT_OFFER_CHECKED_OUT = "You have successfully checked out";
        public const string SUCCESSS_SHIFT_OFFER_CONFIRMED = "Shift was successfully confirmed";
        public const string SUCCESSS_SHIFT_CREATED = "Shift was successfully created";
        public const string SUCCESSS_SHIFT_CANCELLED = "Shift was cancelled";
        public const string SUCCESSS_SHIFT_READVERTISED = "Shift was successfully readvertised";
		public const string SUCCESS_FEEDBACK_SENT = "Feedback was successfully sent";

        public const string ERROR_NO_INTERNET = "Please check your internet connectivity";
        public const string ERROR_USERNAME_TAKEN = "This email is already taken";
        public const string ERROR_AN_ERROR_OCCURRED = "An error occured. Please try again";
        public const string ERROR_SIGN_IN_FAIL = "There was an error while signing in";
        public const string ERROR_INVALID_USERNAME_OR_PASSWORD = "The user name or password is incorrect";
        public const string ERROR_SIGN_UP_FAIL = "There was an error while signing up";
        public const string ERROR_FAILED_TO_SEND_EMAIL = "Failed to send the email";
        public const string ERROR_FAILED_TO_UPLOAD_YOUR_VIDEO = "Failed to upload video";
        public const string ERROR_FAILED_TO_UPLOAD_YOUR_PROFILE_PICTURE = "Failed to upload your profile picture";

        public const string ERROR_FAILED_TO_RETRIEVE_SHIFT_INFORMATION = "Failed to retrieve shift info";
        public const string ERROR_NO_AVAILABLE_SLOTS = "You are too slow. The shift was already occupied";
        public const string ERROR_CANNOT_CANCEL_SHIFT_WITHIN_TIME_LIMIT = "You cannot cancel a shift within 15 minutes";

        public const string ERROR_CANNOT_CHECKIN_BEFORE_TIME_LIMIT = "Check in is available only within 1 hour of shift start time";

        public const string ERROR_SHIFT_WAS_CANCELLED = "This shift was already cancelled";
        public const string ERROR_SHIFT_HAS_ALREADY_STARTED = "This shift has already started";
        public const string ERROR_SHIFT_WAS_ALREADY_ACCEPTED = "You have already accepted this shift";
        public const string ERROR_YOU_ARE_UNAVAILABLE = "You are unavailable. Check your schedule";
	    public const string ERROR_PENDING_APPROVAL = "Your account is being reviewed. Stay tuned";
    }
}
