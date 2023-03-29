using NewBIS.DataAccess;
using NewBIS.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NewBIS.BusinessLogic
{
    public class ServiceAction
    {
        private readonly string connectionString;
        public ServiceAction(string ConnectionName) => this.connectionString = ConnectionName;

        #region    "Get User from Ztb_User"
        public async Task<ZTB_USER> Get_ZTB_USER(string nUserId) => await Get_ZTB_USER(nUserId, null);
        private async Task<ZTB_USER> Get_ZTB_USER(string nUserId, Repository repository)
        {
            ZTB_USER data = null;
            bool internalConnection = false;
            if (repository is null)
            {
                repository = new Repository(connectionString);
                repository.OpenConnection();
                internalConnection = true;
            }

            try
            {
                data = await repository.Get_ZTB_USER(nUserId);
            }
            finally
            {
                if (internalConnection)
                {
                    repository.CloseConnection();
                }
            }
            return data;
        }
        #endregion "Get User from Ztb_User"

        #region    "Get GetAUTB_CHANNEL from GetAUTB_CHANNEL"
        public async Task<List<AUTB_CHANNEL>> GetAUTB_CHANNEL() => await GetAUTB_CHANNEL(null);
        private async Task<List<AUTB_CHANNEL>> GetAUTB_CHANNEL(Repository repository)
        {
            List<AUTB_CHANNEL> data = null;
            bool internalConnection = false;
            if (repository is null)
            {
                repository = new Repository(connectionString);
                repository.OpenConnection();
                internalConnection = true;
            }

            try
            {
                data = await repository.GetAUTB_CHANNEL();
            }
            finally
            {
                if (internalConnection)
                {
                    repository.CloseConnection();
                }
            }
            return data;
        }
        #endregion "Get GetAUTB_CHANNEL from GetAUTB_CHANNEL"

        #region "Get GetReasonCode From CANCEL_BILL_REASON_CODE "
        public async Task<List<CANCEL_BILL_REASON_CODE>> GetReasonCode() => await GetReasonCode(null);
        private async Task<List<CANCEL_BILL_REASON_CODE>> GetReasonCode(Repository repository)
        {
            List<CANCEL_BILL_REASON_CODE> data = null;
            bool internalConnection = false;
            if (repository is null)
            {
                repository = new Repository(connectionString);
                repository.OpenConnection();
                internalConnection = true;
            }

            try
            {
                data = await repository.GetReasonCode();
            }
            finally
            {
                if (internalConnection)
                {
                    repository.CloseConnection();
                }
            }
            return data;
        }
        #endregion "Get GetReasonCode From CANCEL_BILL_REASON_CODE "

        #region "Get Detail Cancel Bill V3 "
        public async Task<List<DetailCancelBill>> GetDetailCancelBillV3(DetailCancelBillRequest request) => await GetDetailCancelBillV3(request, null);
        private async Task<List<DetailCancelBill>> GetDetailCancelBillV3(DetailCancelBillRequest request, Repository repository)
        {
            List<DetailCancelBill> data = null;
            bool internalConnection = false;
            if (repository is null)
            {
                repository = new Repository(connectionString);
                repository.OpenConnection();
                internalConnection = true;
            }

            try
            {
                string isRenewal = "";
                long? policy_id = 0;

                if (request.Holding != null && request.Holding != "")
                {
                    isRenewal = repository.isRenewalByPolicy(request.Holding, request.Policy, request.ChannelType, request.TypeOfChannel, out policy_id);
                }
                else
                {
                    isRenewal = repository.isRenewalByPolicy(request.Policy, "", request.ChannelType, request.TypeOfChannel, out policy_id);
                }

                //if newbis 2018
                string isNewBis2018 = "N";
                if (isRenewal != "Y")
                {
                    isNewBis2018 = repository.isNewBis2018(policy_id);
                }

                if (isRenewal == "Y" || isNewBis2018 == "Y")
                {
                    data = await repository.GetDetailCancelBillRenewal(policy_id, request.BillNo, request.ChannelType, request.TypeOfChannel);
                }
                else
                {
                    data = await repository.GetDetailCancelBillV2(request.Policy, request.BillNo, request.ChannelType, request.TypeOfChannel, request.Holding);
                }
            }
            finally
            {
                if (internalConnection)
                {
                    repository.CloseConnection();
                }
            }
            return data;
        }
        #endregion "Get Detail Cancel Bill V3 "

        #region"CheckIncorece CancelBill"
        public async Task<string> CheckInforce(DetailCancelBillRequest request) => await CheckInforce(request, null);
        private async Task<string> CheckInforce(DetailCancelBillRequest request, Repository repository)
        {
            string inforce = string.Empty;

            bool internalConnection = false;
            if (repository is null)
            {
                repository = new Repository(connectionString);
                repository.OpenConnection();
                internalConnection = true;
            }

            try
            {
                if (request.ChannelType.Equals("OD") || request.ChannelType.Equals("PN") || request.ChannelType.Equals("PO") || request.ChannelType.Equals("OM"))
                {
                    inforce = await repository.CheckInforce(request.Policy.PadLeft(8, '0'), "", request.ChannelType);
                }
                else if (request.ChannelType.Equals("GM") || request.ChannelType.Equals("OM"))
                {
                    inforce = await repository.CheckInforce(request.Policy.PadLeft(8, '0'), request.Holding, "GM");
                }
                else if (request.ChannelType.Equals("HL"))
                {
                    inforce = await repository.CheckInforce(request.Policy.PadLeft(8, '0'), request.Holding, "HL");
                }

            }
            finally
            {
                if (internalConnection)
                {
                    repository.CloseConnection();
                }
            }
            return inforce;
        }
        #endregion"CheckIncorece CancelBill"

        #region "Get isRenewalAllChannel Cancel Bill  "
        public string isRenewalAllChannel(string policy, string holding, out string IsNewbis2018) => isRenewalAllChannel(policy, holding, out IsNewbis2018, null);
        private string isRenewalAllChannel(string policy, string holding, out string IsNewbis2018, Repository repository)
        {

            bool internalConnection = false;
            if (repository is null)
            {
                repository = new Repository(connectionString);
                repository.OpenConnection();
                internalConnection = true;
            }
            string renew_Flg = "";
            IsNewbis2018 = "";
            try
            {
                string newbis2018 = "";
                long? policyId = null;
                renew_Flg = repository.isRenewalAllChannel(policy, holding, out policyId);
                if (renew_Flg == "N")
                {
                    IsNewbis2018 = repository.isNewBis2018(policyId);
                    renew_Flg = IsNewbis2018;
                }
            }
            finally
            {
                if (internalConnection)
                {
                    repository.CloseConnection();
                }
            }
            return renew_Flg;

        }

        #endregion "Get isRenewalAllChannel Cancel Bill  "

        #region"DelNewCS_ORD_BILL : Delete New CS_ORD_Bill"
        public void DelNewCS_ORD_BILL(CS_ORD_BILL req) => DelNewCS_ORD_BILL(req, null);
        private void DelNewCS_ORD_BILL(CS_ORD_BILL req, Repository repository)
        {

            bool internalConnection = false;
            if (repository is null)
            {
                repository = new Repository(connectionString);
                repository.OpenConnection();
                repository.beginTransaction();
                internalConnection = true;
            }
          
            try
            {
                if (!req.ChannelType.Equals("PN") && !req.ChannelType.Equals("PO") && !req.ChannelType.Equals("OM"))
                {
                    if (req.PolicyType.Equals("P"))
                    {
                        string cancelStatus = repository.CheckBillError(req.InPolicy);
                        string processResult = "";
                        repository.DEL_ORDBILL_NEW(req.InPolicy, "", req.InBillNo, req.InUserId, req.ChannelType , out processResult);
                        if (processResult == "N" || processResult == null)
                        {
                            throw new Exception("เกิดความผิดพลาดระหว่างการยกเลิกใบเสร็จ : DEL_ORDBILL");
                        }
                    }
                    else
                    {
                        string processResult = "";
                        repository.DEL_FSDGMPREM(req.InHolding, req.InPolicy, req.InBillNo, req.InUserId, req.ChannelType, out processResult);

                        if (processResult != null && processResult != "")
                        {
                            throw new Exception("เกิดความผิดพลาดระหว่างการยกเลิกใบเสร็จ : DEL_FSDGMPREM : " + processResult);
                        }
                    }
                }
                string OUT_MSG = "";
                repository.CANCEL_RECEIPT(req.InBillNo, req.ReasonCode, req.ReasonDetail, req.InUserId, out OUT_MSG);
                if (OUT_MSG == "N")
                {
                    sendError(req.ChannelType, null, req.InPolicy + " " + req.InHolding + " error in cancel receipt");
                }

                P_LIFE_ID pLifeID = new P_LIFE_ID();
                P_LIFE_ID[] pLifeIDs = null;

                long? policy_id = null;

                repository.commitTransaction();
            }
            catch (Exception ex)
            {
                repository.rollbackTransaction();
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (internalConnection)
                {
                    repository.CloseConnection();
                }
            }
        }

        private void sendError(string CHANNEL_TYPE, long? policy_id, string error_message)
        {
            Mail mail = new Mail();
            mail.From = "system@bangkoklife.com";
            mail.Subject = "error ใบเสร็จโครงสร้างใหม่";
            string[] emails = { "apiwat@bangkoklife.com" };
            mail.IsBodyHtml = true;
            mail.Encoding = MailEncoding.Windows874;
            mail.To = emails;
            mail.Body = policy_id + "(" + CHANNEL_TYPE + ") : " + error_message;
            SendMail(mail);
        }

        public ITUtility.ProcessResult SendMail(Mail mail)
        {
            ITUtility.ProcessResult processResult = new ITUtility.ProcessResult();
            try
            {
                MailMessage mMsg = new MailMessage();
                mMsg.Body = mail.Body;
                switch (mail.Encoding)
                {
                    case MailEncoding.Windows874:
                        mMsg.BodyEncoding = Encoding.GetEncoding("windows-874");
                        break;
                    default:
                        mMsg.BodyEncoding = Encoding.UTF8;
                        break;
                }
                if (mail.From == null || mail.From.Trim() == "")
                    throw new Exception("ไมได้ระบุผู้ส่ง");
                mMsg.From = new MailAddress(mail.From);
                if (mail.To == null || mail.To.Count() == 0)
                    throw new Exception("ไม่ได้ระบุผู้รับ");
                foreach (string to in mail.To)
                {
                    mMsg.To.Add(new MailAddress(to));
                }
                mMsg.IsBodyHtml = mail.IsBodyHtml;
                mMsg.Subject = mail.Subject;
                mMsg.SubjectEncoding = mMsg.BodyEncoding;

                SmtpClient client = new SmtpClient();
                client.Host = "172.16.10.87";  //Utility.AppSettings("smtpServer"); //172.16.10.87
                client.Port = 25; // int.Parse(Utility.AppSettings("smtpPort")); //25
                client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                client.Send(mMsg);

                processResult.ErrorMessage = null;
                processResult.Successed = true;
            }
            catch (Exception ex)
            {
                processResult.ErrorMessage = ex.Message;
                processResult.Successed = false;
            }
            return processResult;
        }

        #endregion"DelNewCS_ORD_BILL : Delete New CS_ORD_Bill"
    }
}
