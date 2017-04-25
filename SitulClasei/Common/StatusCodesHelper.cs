using System.Collections.Generic;
using SitulClasei.Common.Extensions;
using SitulClasei.Common.Response;

namespace SitulClasei.Common
{
	[Foundation.Preserve(AllMembers = true)]
    public static class StatusCodesHelper
    {
        private static readonly Dictionary<int, string> mCodeMessageMappings = new Dictionary<int, string>();

        private const string AN_ERROR_OCCURRED = "An error occurred";

        static StatusCodesHelper()
        {
            mCodeMessageMappings.Add((int)ResponseCode.SuccessProfileUpdated , StatusContants.SUCCESS_PROFILE_UPDATED);
            mCodeMessageMappings.Add((int)ResponseCode.SuccessSignOut , StatusContants.SUCCESS_SIGN_OUT);
            mCodeMessageMappings.Add((int)ResponseCode.SuccessSignIn , StatusContants.SUCCESS_SIGN_IN);
            mCodeMessageMappings.Add((int)ResponseCode.SuccessSignUp , StatusContants.SUCCESS_SIGN_UP);
            mCodeMessageMappings.Add((int)ResponseCode.SuccessYourPasswordWasReset , StatusContants.SUCCESS_YOUR_PASSWORD_WAS_RESET);

            mCodeMessageMappings.Add((int)ResponseCode.SuccessShiftOfferAccepted , StatusContants.SUCCESSS_SHIFT_OFFER_ACCEPTED);
            mCodeMessageMappings.Add((int)ResponseCode.SuccessShiftOfferCancelled , StatusContants.SUCCESSS_SHIFT_OFFER_CANCELLED);
            mCodeMessageMappings.Add((int)ResponseCode.SuccessShiftOfferDeclined , StatusContants.SUCCESSS_SHIFT_OFFER_DECLINED);
            mCodeMessageMappings.Add((int)ResponseCode.SuccessShiftOfferCheckedIn , StatusContants.SUCCESSS_SHIFT_OFFER_CHECKED_IN);
            mCodeMessageMappings.Add((int)ResponseCode.SuccessShiftOfferCheckedOut , StatusContants.SUCCESSS_SHIFT_OFFER_CHECKED_OUT);
            mCodeMessageMappings.Add((int)ResponseCode.SuccessShiftOfferConfirmed , StatusContants.SUCCESSS_SHIFT_OFFER_CONFIRMED);

            mCodeMessageMappings.Add((int)ResponseCode.SuccessShiftCreated , StatusContants.SUCCESSS_SHIFT_CREATED);
            mCodeMessageMappings.Add((int)ResponseCode.SuccessShiftCancelled , StatusContants.SUCCESSS_SHIFT_CANCELLED);
            mCodeMessageMappings.Add((int)ResponseCode.SuccessShiftReadvertised , StatusContants.SUCCESSS_SHIFT_READVERTISED);

			mCodeMessageMappings.Add((int)ResponseCode.SuccessFeedbackSent , StatusContants.SUCCESS_FEEDBACK_SENT);

            mCodeMessageMappings.Add((int)ResponseCode.ErrorAnErrorOccurred , StatusContants.ERROR_AN_ERROR_OCCURRED);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorNoInternet , StatusContants.ERROR_NO_INTERNET);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorSignInFail , StatusContants.ERROR_SIGN_IN_FAIL);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorInvalidUsernameOrPassword , StatusContants.ERROR_INVALID_USERNAME_OR_PASSWORD);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorSignUpFail , StatusContants.ERROR_SIGN_UP_FAIL);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorUsernameTaken , StatusContants.ERROR_USERNAME_TAKEN);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorFailedToSendEmail , StatusContants.ERROR_FAILED_TO_SEND_EMAIL);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorFailedToUploadYourProfilePicture , StatusContants.ERROR_FAILED_TO_UPLOAD_YOUR_PROFILE_PICTURE);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorFailedToUploadYourVideo , StatusContants.ERROR_FAILED_TO_UPLOAD_YOUR_VIDEO);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorNoAvailableSlots , StatusContants.ERROR_NO_AVAILABLE_SLOTS);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorCannotCancelShiftWithinTimeLimit , StatusContants.ERROR_CANNOT_CANCEL_SHIFT_WITHIN_TIME_LIMIT);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorCannotCheckinBeforeTimeLimit , StatusContants.ERROR_CANNOT_CHECKIN_BEFORE_TIME_LIMIT);

            mCodeMessageMappings.Add((int)ResponseCode.ErrorShiftWasCancelled , StatusContants.ERROR_SHIFT_WAS_CANCELLED);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorShiftHasAlreadyStarted , StatusContants.ERROR_SHIFT_HAS_ALREADY_STARTED);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorShiftOfferAlreadyAccepted , StatusContants.ERROR_SHIFT_WAS_ALREADY_ACCEPTED);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorYouAreNotAvailable , StatusContants.ERROR_YOU_ARE_UNAVAILABLE);
            mCodeMessageMappings.Add((int)ResponseCode.ErrorPendingApproval, StatusContants.ERROR_PENDING_APPROVAL);

        }

        public static string GetMessage(int errorCode)
        {
            if (mCodeMessageMappings.ContainsKey(errorCode))
            {
                return mCodeMessageMappings[errorCode];
            }

            return AN_ERROR_OCCURRED;
        }
    }
}