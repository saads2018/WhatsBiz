using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WASender.Model;
using WASender.Models;

namespace WASender
{
    public class Strings
    {
        private static string languageJson = "";

        public readonly static string AppName = "WaSender";
        public static string selectedLanguage = getLanguage(LanguagesEnum.English);
        public static bool Allow_Users_to_Change_Language = true;



        public readonly static string SoftwareVersion = "3.0.0";
        public readonly static string Column1 = GetValue("Column1");
        public readonly static string Number = GetValue("Number");
        public readonly static string Column2 = GetValue("Column2");
        public readonly static string DownloadSample = GetValue("DownloadSample");
        public readonly static string UploadSampleExcel = GetValue("UploadSampleExcel");
        public readonly static string ContectSender = GetValue("ContectSender");
        public readonly static string GroupSender = GetValue("GroupSender");
        public readonly static string Tools = GetValue("Tools");
        public readonly static string Filedownloadedsuccessfully = GetValue("Filedownloadedsuccessfully");
        public readonly static string WABulkSender = GetValue("WABulkSender");
        public readonly static string SelectExcel = GetValue("SelectExcel");
        public readonly static string PleaseselectExcelfilesformatonly = GetValue("PleaseselectExcelfilesformatonly");
        public readonly static string AddNew = GetValue("AddNew");
        public readonly static string KeyMarkers = GetValue("KeyMarkers");
        public readonly static string AddKeyMarker = GetValue("AddKeyMarker");
        public readonly static string SaveNClose = GetValue("SaveNClose");
        public readonly static string KeyMarkerFormatinIncorrect = GetValue("KeyMarkerFormatinIncorrect");
        public readonly static string OK = GetValue("OK");
        public readonly static string SelectedKeyMarkeralreadyExist = GetValue("SelectedKeyMarkeralreadyExist");
        public readonly static string Delete = GetValue("Delete");
        public readonly static string WrongKey = GetValue("WrongKey");
        public readonly static string Target = GetValue("Target");
        public readonly static string Messages = GetValue("Messages");
        public readonly static string MessageOne = GetValue("MessageOne");
        public readonly static string MessageTwo = GetValue("MessageTwo");
        public readonly static string MessageThree = GetValue("MessageThree");
        public readonly static string MessageFour = GetValue("MessageFour");
        public readonly static string MessageFive = GetValue("MessageFive");
        public readonly static string Attachments = GetValue("Attachments");
        public readonly static string Addfile = GetValue("Addfile");
        public readonly static string Yourfirstmessage = GetValue("Yourfirstmessage");
        public readonly static string YourSecondmessage = GetValue("YourSecondmessage");
        public readonly static string YourThirdmessage = GetValue("YourThirdmessage");
        public readonly static string YourFourthmessage = GetValue("YourFourthmessage");
        public readonly static string YourFifthmessage = GetValue("YourFifthmessage");
        public readonly static string DelaySettings = GetValue("DelaySettings");
        public readonly static string Wait = GetValue("Wait");
        public readonly static string secondsafterevery = GetValue("secondsafterevery");
        public readonly static string to = GetValue("to");
        public readonly static string Clear = GetValue("Clear");
        public readonly static string StartCampaign = GetValue("StartCampaign");
        public readonly static string secondsbeforeeverymessage = GetValue("secondsbeforeeverymessage");
        public readonly static string AddKeyMarkers = GetValue("AddKeyMarkers");
        public readonly static string RandomNumber = GetValue("RandomNumber");
        public readonly static string PleaseEnterCampaignName = GetValue("PleaseEnterCampaignName");
        public readonly static string CampaignName = GetValue("CampaignName");
        public readonly static string UntitledGroupCampaign = GetValue("UntitledGroupCampaign");
        public readonly static string UntitledCampaign = GetValue("UntitledCampaign");
        public readonly static string RowNo = GetValue("RowNo");
        public readonly static string Errors = GetValue("Errors");
        public readonly static string WhatsAppBot = GetValue("WhatsAppBot");
        public readonly static string Rules = GetValue("Rules");
        public readonly static string AddRule = GetValue("AddRule");
        public readonly static string Log = GetValue("Log");
        public readonly static string Status = GetValue("Status");
        public readonly static string Start = GetValue("Start");
        public readonly static string Stop = GetValue("Stop");
        public readonly static string IsActive = GetValue("IsActive");
        public readonly static string UserInput = GetValue("UserInput");
        public readonly static string Type = GetValue("Type");
        public readonly static string Match = GetValue("Match");
        public readonly static string ReplySend = GetValue("ReplySend");
        public readonly static string NotMatch = GetValue("NotMatch");
        public readonly static string Fallback = GetValue("Fallback");
        public readonly static string PleaseaddRules = GetValue("PleaseaddRules");
        public readonly static string Run = GetValue("Run");
        public readonly static string InitiateWhatsAppScaneQRCodefromyourrmobile = GetValue("InitiateWhatsAppScaneQRCodefromyourrmobile");
        public readonly static string ClicktoInitiate = GetValue("ClicktoInitiate");
        public readonly static string ChatName = GetValue("ChatName");
        public readonly static string ImportentNotes = GetValue("ImportentNotes");
        public readonly static string Keepapplicationopenwhilesendingmessagesanduntilallmessagesaresentfromyourmobile = GetValue("Keepapplicationopenwhilesendingmessagesanduntilallmessagesaresentfromyourmobile");
        public readonly static string ClearWhatsAppchathistoryafter5001000150020000messagesasperyourphoneconfiguration = GetValue("ClearWhatsAppchathistoryafter5001000150020000messagesasperyourphoneconfiguration");
        public readonly static string WaSendertendstosubmitmessagestoyourphoneisnotresponsiblefordeliveryofthemessage = GetValue("WaSendertendstosubmitmessagestoyourphoneisnotresponsiblefordeliveryofthemessage");
        public readonly static string Completed = GetValue("Completed");
        public readonly static string PleasefollowStepNo1FirstInitialiseWhatsapp = GetValue("PleasefollowStepNo1FirstInitialiseWhatsapp");
        public readonly static string Processisalreadyrunning = GetValue("Processisalreadyrunning");
        public readonly static string RunGroup = GetValue("RunGroup");
        public readonly static string KeyMarker = GetValue("KeyMarker");
        public readonly static string Select = GetValue("Select");
        public readonly static string GroupsJoiner = GetValue("GroupsJoiner");
        public readonly static string GroupJoin = GetValue("GroupJoin");
        public readonly static string secondsbeforeeveryGroupJoin = GetValue("secondsbeforeeveryGroupJoin");
        public readonly static string StartJoining = GetValue("StartJoining");
        public readonly static string GroupLink = GetValue("GroupLink");
        public readonly static string PleaseFollowStepnoThree = GetValue("PleaseFollowStepnoThree");
        public readonly static string GrabGroupLinks = GetValue("GrabGroupLinks");
        public readonly static string OpenBrowser = GetValue("OpenBrowser");
        public readonly static string Clickbellowbuttontoopenbrowser = GetValue("Clickbellowbuttontoopenbrowser");
        public readonly static string Navigatetoanywebsitewherelistedgrouplinkstheclickbellowbellowbuton = GetValue("Navigatetoanywebsitewherelistedgrouplinkstheclickbellowbellowbuton");
        public readonly static string StartGrabbing = GetValue("StartGrabbing");
        public readonly static string NoGroupLinkfoundincurrentPage = GetValue("NoGroupLinkfoundincurrentPage");
        public readonly static string GrabChatList = GetValue("GrabChatList");
        public readonly static string InitiateWhatsAppScaneQRCodefromyourmobile = GetValue("InitiateWhatsAppScaneQRCodefromyourmobile");
        public readonly static string GetGroupMember = GetValue("GetGroupMember");
        public readonly static string OpenanyGroupchatClickbuttonbellow = GetValue("OpenanyGroupchatClickbuttonbellow");
        public readonly static string PleaseGotoanygroupchat = GetValue("PleaseGotoanygroupchat");
        public readonly static string fallback = GetValue("fallback");
        public readonly static string Usefallback = GetValue("Usefallback");
        public readonly static string If = GetValue("If");
        public readonly static string UserSend = GetValue("UserSend");
        public readonly static string Condition = GetValue("Condition");
        public readonly static string Which = GetValue("Which");
        public readonly static string ThenReplywith = GetValue("ThenReplywith");
        public readonly static string AddMessage = GetValue("AddMessage");
        public readonly static string Message = GetValue("Message");
        public readonly static string Cancel = GetValue("Cancel");
        public readonly static string Save = GetValue("Save");
        public readonly static string Confirm = GetValue("Confirm");
        public readonly static string AreyousuretodeletethisRule = GetValue("AreyousuretodeletethisRule");
        public readonly static string ReplyMessage = GetValue("ReplyMessage");
        public readonly static string TypeYourMessagehere = GetValue("TypeYourMessagehere");
        public readonly static string Files = GetValue("Files");
        public readonly static string Add = GetValue("Add");
        public readonly static string GroupNames = GetValue("GroupNames");
        public readonly static string PleaseCheckMobileNumberyouhaveadded = GetValue("PleaseCheckMobileNumberyouhaveadded");
        public readonly static string ShouldNotbeempty = GetValue("ShouldNotbeempty");
        public readonly static string ContactNumberShouldNotbeEmpty = GetValue("ContactNumberShouldNotbeEmpty");
        public readonly static string MessageShouldNotbeEmpty = GetValue("MessageShouldNotbeEmpty");
        public readonly static string delayAfterMessagesShouldNotbeEmpty = GetValue("delayAfterMessagesShouldNotbeEmpty");
        public readonly static string delayAfterMessagesFromShouldNotbeEmpty = GetValue("delayAfterMessagesFromShouldNotbeEmpty");
        public readonly static string delayAfterMessagesTOShouldNotbeEmpty = GetValue("delayAfterMessagesTOShouldNotbeEmpty");
        public readonly static string delayAfterEveryMessageFromShouldNotbeEmpty = GetValue("delayAfterEveryMessageFromShouldNotbeEmpty");
        public readonly static string delayAfterEveryMessageToShouldNotbeEmpty = GetValue("delayAfterEveryMessageToShouldNotbeEmpty");
        public readonly static string ShouldGraterthenoero = GetValue("ShouldGraterthenoero");
        public readonly static string delayAfterMessages_ShouldGraterthenoero = GetValue("delayAfterMessages_ShouldGraterthenoero");
        public readonly static string delayAfterMessagesFrom_ShouldGraterthenoero = GetValue("delayAfterMessagesFrom_ShouldGraterthenoero");
        public readonly static string delayAfterMessagesTo_ShouldGraterthenoero = GetValue("delayAfterMessagesTo_ShouldGraterthenoero");
        public readonly static string delayAfterEveryMessageFrom_ShouldGraterthenoero = GetValue("delayAfterEveryMessageFrom_ShouldGraterthenoero");
        public readonly static string delayAfterEveryMessageTo_ShouldGraterthenoero = GetValue("delayAfterEveryMessageTo_ShouldGraterthenoero");
        public readonly static string thetoamountismustbegraterthenstartingamount = GetValue("thetoamountismustbegraterthenstartingamount");
        public readonly static string UsermessageMustEmptyincaseoffallback = GetValue("UsermessageMustEmptyincaseoffallback");
        public readonly static string PleaseAddatleastoneMessage = GetValue("PleaseAddatleastoneMessage");
        public readonly static string PleaseEnterAmessage = GetValue("PleaseEnterAmessage");
        public readonly static string PleaseaddatleastoneGroupinlist = GetValue("PleaseaddatleastoneGroupinlist");
        public readonly static string PleaseaddatleastoneContactinlist = GetValue("PleaseaddatleastoneContactinlist");
        public readonly static string ClickbellowButton = GetValue("ClickbellowButton");
        public readonly static string ScanQRCode = GetValue("ScanQRCode");
        public readonly static string WaitfortheExcel = GetValue("WaitfortheExcel");
        public readonly static string Now = GetValue("Now");
        public readonly static string GrabNow = GetValue("GrabNow");
        public readonly static string GrabGroupMembers = GetValue("GrabGroupMembers");
        public readonly static string ClickbellowButtonScanQRCode = GetValue("ClickbellowButtonScanQRCode");
        public readonly static string OpenAnyGroup = GetValue("OpenAnyGroup");
        public readonly static string GrabWhatsAppGroupLinksfromwebpage = GetValue("GrabWhatsAppGroupLinksfromwebpage");
        public readonly static string OpenAnywebpagewheregivengrouplinks = GetValue("OpenAnywebpagewheregivengrouplinks");
        public readonly static string ThenClickonSTARTButton = GetValue("ThenClickonSTARTButton");
        public readonly static string AutoGroupJoiner = GetValue("AutoGroupJoiner");
        public readonly static string AddUploadGroupLinks = GetValue("AddUploadGroupLinks");
        public readonly static string ScanWAQRCode = GetValue("ScanWAQRCode");
        public readonly static string StartNow = GetValue("StartNow");
        public readonly static string WhatsAppAutoResponderBot = GetValue("WhatsAppAutoResponderBot");
        public readonly static string SetRules = GetValue("SetRules");
        public readonly static string AddReplyMessages = GetValue("AddReplyMessages");
        public readonly static string GeneralSettings = GetValue("GeneralSettings");
        public readonly static string ChromeProfilePath = GetValue("ChromeProfilePath");
        public readonly static string InputPathisnotCorrectfolderpath = GetValue("InputPathisnotCorrectfolderpath");
        public readonly static string SettingsSavedSuccessfully = GetValue("SettingsSavedSuccessfully");
        public readonly static string MessageSendingType = GetValue("MessageSendingType");
        public readonly static string CopyPaste = GetValue("CopyPaste");
        public readonly static string Typeamessage = GetValue("Typeamessage");
        public readonly static string Activate = GetValue("Activate");
        public readonly static string ActivateAppName = GetValue("ActivateAppName");
        public readonly static string YourActivationCodeis = GetValue("YourActivationCodeis");
        public readonly static string ProvideYourActivationKeyHere = GetValue("ProvideYourActivationKeyHere");
        public readonly static string ActivateNow = GetValue("ActivateNow");
        public readonly static string Exit = GetValue("Exit");
        public readonly static string ActivationSuccessfull = GetValue("ActivationSuccessfull");
        public readonly static string InvalidActivationKey = GetValue("InvalidActivationKey");
        public readonly static string LanguageIsSet = GetValue("LanguageIsSet");
        public readonly static string Name = GetValue("Name");
        public readonly static string WhatsAppNumberFilter = GetValue("WhatsAppNumberFilter");
        public readonly static string AddUploadNumbers = GetValue("AddUploadNumbers");
        public readonly static string NumberCheck = GetValue("NumberCheck");
        public readonly static string secondsbeforeeveryNumberCheck = GetValue("secondsbeforeeveryNumberCheck");
        public readonly static string StartChecking = GetValue("StartChecking");
        public readonly static string ContactListGrabber = GetValue("ContactListGrabber");
        public readonly static string HitGrabNowButton = GetValue("HitGrabNowButton");
        public readonly static string GrabActiveGroupMembers = GetValue("GrabActiveGroupMembers");
        public readonly static string TotalFound = GetValue("TotalFound");
        public readonly static string Export = GetValue("Export");
        public readonly static string Nothingtoexport = GetValue("Nothingtoexport");
        public readonly static string GoogleMapDataEExtractor = GetValue("GoogleMapDataEExtractor");
        public readonly static string Usethatwindowtosearchforbusinessesandwhensearchresultsareshown = GetValue("Usethatwindowtosearchforbusinessesandwhensearchresultsareshown");
        public readonly static string PleaseSearchsomething = GetValue("PleaseSearchsomething");
        public readonly static string ImportInWaSender = GetValue("ImportInWaSender");
        public readonly static string EnterCountryCode = GetValue("EnterCountryCode");
        public readonly static string SearchYourQUeryonGMap = GetValue("SearchYourQUeryonGMap");
        public readonly static string HitStart = GetValue("HitStart");
        public readonly static string Count = GetValue("Count");
        public readonly static string ReviewCount = GetValue("ReviewCount");
        public readonly static string Catagory = GetValue("Catagory");
        public readonly static string MobileNumber = GetValue("MobileNumber");
        public readonly static string Address = GetValue("Address");
        public readonly static string Website = GetValue("Website");
        public readonly static string PlusCode = GetValue("PlusCode");
        public readonly static string AddCountryCode = GetValue("AddCountryCode");
        public readonly static string One = GetValue("One");
        public readonly static string Two = GetValue("Two");
        public readonly static string Three = GetValue("Three");
        public readonly static string AddButtons = GetValue("AddButtons");
        public readonly static string Buttons = GetValue("Buttons");
        public readonly static string ButtonMessage = GetValue("ButtonMessage");
        public readonly static string ButtonText = GetValue("ButtonText");
        public readonly static string ButtonType = GetValue("ButtonType");
        public readonly static string NormalButton = GetValue("NormalButton");
        public readonly static string Link = GetValue("Link");
        public readonly static string PhoneNumber = GetValue("PhoneNumber");
        public readonly static string EnterURL = GetValue("EnterURL");
        public readonly static string EnterPhoneNumber = GetValue("EnterPhoneNumber");
        public readonly static string AddButton = GetValue("AddButton");
        public readonly static string GrabAllSavedContacts = GetValue("GrabAllSavedContacts");
        public readonly static string GrabAllGroups = GetValue("GrabAllGroups");
        public readonly static string ChooseGroup = GetValue("GrabAllGroups");
        public readonly static string PleaseSelectGroup = GetValue("PleaseSelectGroup");
        public readonly static string CopyPasteNumber = GetValue("CopyPasteNumber");
        public readonly static string Import = GetValue("Import");
        public readonly static string YourSearchterm = GetValue("YourSearchterm");
        public readonly static string Softwarecompaniesintexas = "Software companies in texas";
        public readonly static string AddCaption = GetValue("AddCaption");
        public readonly static string Caption = GetValue("Caption");
        public readonly static string _File = GetValue("File");
        public readonly static string BulkAddGroupMembers = GetValue("BulkAddGroupMembers");
        public readonly static string NumberAdd = GetValue("NumberAdd");
        public readonly static string secondsbeforeeveryNumberAdd = GetValue("secondsbeforeeveryNumberAdd");
        public readonly static string StartAdding = GetValue("StartAdding");
        public readonly static string ClickButtonbellow = GetValue("ClickButtonbellow");
        public readonly static string UploadNumbersExcel = GetValue("UploadNumbersExcel");
        public readonly static string SelectGroupandGo = GetValue("SelectGroupandGo");
        public readonly static string GroupFinder = GetValue("GroupFinder");
        public readonly static string GroupSubject = GetValue("GroupSubject");
        public readonly static string Search = GetValue("Search");
        public readonly static string ImportInGroupJoiner = GetValue("ImportInGroupJoiner");
        public readonly static string EnterYourSubject = GetValue("EnterYourSubject");
        public readonly static string StartFinding = GetValue("StartFinding");
        public readonly static string GroupName = GetValue("GroupName");
        public readonly static string Pause = GetValue("Pause");
        public readonly static string RatingCount = GetValue("RatingCount");
        public readonly static string AttachWithMainMessage = GetValue("AttachWithMainMessage");
        public readonly static string clossinghour = GetValue("clossinghour");
        public readonly static string latitude = GetValue("latitude");
        public readonly static string longitude = GetValue("longitude");
        public readonly static string instagramprofile = GetValue("instagramprofile");
        public readonly static string facebookprofile = GetValue("facebookprofile");
        public readonly static string linkedinprofile = GetValue("linkedinprofile");
        public readonly static string twitterprofile = GetValue("twitterprofile");
        public readonly static string EmailId = GetValue("EmailId");
        public readonly static string GenerateNumbers = GetValue("GenerateNumbers");
        public readonly static string Increment = GetValue("Increment");
        public readonly static string Quentity = GetValue("Quentity");
        public readonly static string Generate = GetValue("Generate");
        public readonly static string CountryCode = GetValue("CountryCode");
        public readonly static string BulkGroupGenerator = GetValue("BulkGroupGenerator");
        public readonly static string GroupNameSettings = GetValue("GroupNameSettings");
        public readonly static string GroupNamePrefix = GetValue("GroupNamePrefix");
        public readonly static string GroupNameSuffix = GetValue("GroupNameSuffix");
        public readonly static string DefaultNumberAdd = GetValue("DefaultNumberAdd");
        public readonly static string GenerateTotalGroups = GetValue("GenerateTotalGroups");
        public readonly static string Validate = GetValue("Validate");
        public readonly static string GroupCreate = GetValue("GroupCreate");
        public readonly static string secondsbeforeeveryGroupCreate = GetValue("secondsbeforeeveryGroupCreate");
        public readonly static string IsNotValid = GetValue("IsNotValid");
        public readonly static string DontCheckNumberStatusBeforeSendingMessage = GetValue("DontCheckNumberStatusBeforeSendingMessage");
        public readonly static string ProvideInputs = GetValue("ProvideInputs");
        public readonly static string StartGenerating = GetValue("StartGenerating");
        public readonly static string ChromeEXEpath = GetValue("ChromeEXEpath");
        public readonly static string CheckforInternalUpdate = GetValue("CheckforInternalUpdate");
        public readonly static string UpdateChromeDriver = GetValue("UpdateChromeDriver");
        public readonly static string clearsessions = GetValue("clearsessions");
        public readonly static string ClearProfileCache = GetValue("ClearProfileCache");
        public readonly static string ClearBOTCache = GetValue("ClearBOTCache");
        public readonly static string About = GetValue("About");
        public readonly static string UpdateCHromeDriverMethodOne = GetValue("UpdateCHromeDriverMethodOne");
        public readonly static string UpdateCHromeDriverMethodTwo = GetValue("UpdateCHromeDriverMethodTwo");
        public readonly static string SendGroupInvitationcodeiffail = GetValue("SendGroupInvitationcodeiffail");
        public readonly static string GrabImages = GetValue("GrabImages");
        public readonly static string ImagesFolder = GetValue("ImagesFolder");
        public readonly static string GrabEmailId = GetValue("GrabEmailId");
        public readonly static string GoogleContactsCSVGenerator = GetValue("GoogleContactsCSVGenerator");
        public readonly static string GenrateRandomName = GetValue("GenrateRandomName");
        public readonly static string NamePrefix = GetValue("NamePrefix");
        public readonly static string NameSufix = GetValue("NameSufix");
        public readonly static string GenerateNow = GetValue("GenerateNow");
        public readonly static string ExportasGoogleContactCSV = GetValue("ExportasGoogleContactCSV");


        public readonly static string Loding = GetValue("Loding");
        public readonly static string DeActivateLicence = GetValue("DeActivateLicence");
        public readonly static string AreyouSure = GetValue("AreyouSure");
        public readonly static string Yes = GetValue("Yes");
        public readonly static string ManageAccounts = GetValue("ManageAccounts");
        public readonly static string AccountName = GetValue("AccountName");
        public readonly static string AreYouSuretodeletethisAccount = GetValue("AreYouSuretodeletethisAccount");
        public readonly static string AccountDeleted = GetValue("AccountDeleted");
        public readonly static string AddNewAccount = GetValue("AddNewAccount");
        public readonly static string SameNameAlreadyExists = GetValue("SameNameAlreadyExists");
        public readonly static string AccountAddedSuccessfully = GetValue("AccountAddedSuccessfully");
        public readonly static string CantDeleteDefaultAccount = GetValue("CantDeleteDefaultAccount");
        public readonly static string SetasDefaultAccount = GetValue("SetasDefaultAccount");
        public readonly static string Accounts = GetValue("Accounts");
        public readonly static string Load = GetValue("Load");
        public readonly static string Primary = GetValue("Primary");
        public readonly static string Launch = GetValue("Launch");
        public readonly static string SwipeAccountaftermessages = GetValue("SwipeAccountaftermessages");
        public readonly static string YouhaventaddedanyaccountyetToaddnewaccountpleaseuseACCOUNTSbutton = GetValue("YouhaventaddedanyaccountyetToaddnewaccountpleaseuseACCOUNTSbutton");
        public readonly static string Pleaseselectatleastoneaccount = GetValue("Pleaseselectatleastoneaccount");
        public readonly static string InvalidPurchaseCode = GetValue("InvalidPurchaseCode");

        //------------END  Do not Trancelate ----------------------
        public static string PurchaseCode = "";
        //------------END  Do not Trancelate ----------------------


        //public readonly static string _About = "About";
        //public readonly static string _About = "About";
        //public readonly static string _About = "About";
        //public readonly static string _About = "About";
        //public readonly static string _About = "About";
        //public readonly static string _About = "About";
        //public readonly static string _About = "About";
        //public readonly static string _About = "About";

        //About
        //materialButton6

        public static List<WASender.Models.LanguageModel> dict;


        public static string getLanguage(LanguagesEnum enumLang)
        {
            if (enumLang == LanguagesEnum.Arabic)
            {
                return "Arabic";
            }
            else if (enumLang == LanguagesEnum.Chinese)
            {
                return "Chinese";
            }
            else if (enumLang == LanguagesEnum.Dutch)
            {
                return "Dutch";
            }
            else if (enumLang == LanguagesEnum.English)
            {
                return "English";
            }
            else if (enumLang == LanguagesEnum.French)
            {
                return "French";
            }
            else if (enumLang == LanguagesEnum.German)
            {
                return "German";
            }
            else if (enumLang == LanguagesEnum.Greek)
            {
                return "Greek";
            }
            else if (enumLang == LanguagesEnum.Gujarati)
            {
                return "Gujarati";
            }
            else if (enumLang == LanguagesEnum.Hebrew)
            {
                return "Hebrew";
            }
            else if (enumLang == LanguagesEnum.Hindi)
            {
                return "Hindi";
            }
            else if (enumLang == LanguagesEnum.Indonesian)
            {
                return "Indonesian";
            }
            else if (enumLang == LanguagesEnum.Italian)
            {
                return "Italian";
            }
            else if (enumLang == LanguagesEnum.Japanese)
            {
                return "Japanese";
            }
            else if (enumLang == LanguagesEnum.Laos)
            {
                return "Laos";
            }
            else if (enumLang == LanguagesEnum.Portuguese)
            {
                return "Portuguese";
            }
            else if (enumLang == LanguagesEnum.Russian)
            {
                return "Russian";
            }
            else if (enumLang == LanguagesEnum.Spanish)
            {
                return "Spanish";
            }
            else if (enumLang == LanguagesEnum.Turkish)
            {
                return "Turkish";
            }
            else if (enumLang == LanguagesEnum.Urdu)
            {
                return "Urdu";
            }
            return "English";
        }
        private static string GetValue(string name)
        {
            if (languageJson == "")
            {
                LoadLanguageJson();
            }
            if (dict == null)
            {
                dict = JsonConvert.DeserializeObject<List<WASender.Models.LanguageModel>>(languageJson);
            }



            try
            {
                return dict.Where(x => x.name.Trim() == name.Trim()).FirstOrDefault().value;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private static void LoadLanguageJson()
        {
            string fileName = "English.json";

            if (selectedLanguage != "" && selectedLanguage != null)
            {
                fileName = selectedLanguage;
            }
            try
            {
                string settingPath = Config.GetGeneralSettingsFilePath();

                if (!File.Exists(settingPath))
                {
                    File.Create(settingPath).Close();
                }
                GeneralSettingsModel generalSettingsModel = new GeneralSettingsModel();
                generalSettingsModel.selectedLanguage = selectedLanguage;
                string GeneralSettingJson = "";
                using (StreamReader r = new StreamReader(settingPath))
                {
                    GeneralSettingJson = r.ReadToEnd();
                }
                var dict = JsonConvert.DeserializeObject<GeneralSettingsModel>(GeneralSettingJson);
                if (dict != null)
                {
                    generalSettingsModel = dict;
                }
                if (generalSettingsModel.selectedLanguage == null || generalSettingsModel.selectedLanguage == "")
                {
                    generalSettingsModel.selectedLanguage = selectedLanguage;
                }
                selectedLanguage = generalSettingsModel.selectedLanguage;
            }
            catch (Exception ex)
            {

            }

            if (selectedLanguage != "")
            {
                fileName = selectedLanguage + ".json";
            }

            using (StreamReader r = new StreamReader("languages\\" + fileName))
            {
                languageJson = r.ReadToEnd();
            }
        }


        //public readonly static string AppName = "Wa Sender 1.0";




    }
}


