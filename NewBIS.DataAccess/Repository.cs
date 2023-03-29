using DataAccessUtility;
using ITUtility;
using NewBIS.DataContract;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBIS.DataAccess
{
    public class Repository : RepositoryBaseManagedCore
    {

        public Repository(OracleConnection connection) : base(connection)
        {

        }
        public Repository(string ConnectionString, ConnectionClientDetail ClientDetail = null)
        : base(ConnectionString, ClientDetail)
        {

        }

        private OracleConnection isisViewConnection;
        protected OracleConnection IsisViewConnection
        {
            get { return isisViewConnection; }
            set { isisViewConnection = value; }
        }
        public void OpenIsisViewConnection()
        {
            isisViewConnection.Open();
        }

        public void CloseIsisViewConnection()
        {
            isisViewConnection.Close();
        }

        #region    "Get User from Ztb_User"
        public async Task<ZTB_USER> Get_ZTB_USER(string nUserId)
        {
            ZTB_USER returnValue = null;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT * FROM CENTER.ZTB_USER WHERE TERMINATE_DT IS NULL ");
            OracleCommand oCmd = new OracleCommand();
            oCmd.BindByName = true;
            oCmd.Connection = connection;
            oCmd.CommandType = CommandType.Text;
            if (!string.IsNullOrEmpty(nUserId))
            {
                sql.Append(@" AND N_USERID = :IN_N_USERID");
                oCmd.Parameters.Add(new OracleParameter("IN_N_USERID", nUserId));
            }

            oCmd.CommandText = sql.ToString();
            DataTable dt = await Utility.FillDataTableAsync(oCmd);

            if (dt.Rows.Count > 0)
            {
                returnValue = dt.AsEnumerable<ZTB_USER>().FirstOrDefault();
            }

            oCmd.Dispose();
            return returnValue;
        }
        #endregion "Get User from Ztb_User"

        #region    "Get User from AUTB_CHANNE"

        public async Task<List<AUTB_CHANNEL>> GetAUTB_CHANNEL()
        {
            List<AUTB_CHANNEL> returnValue = null;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT CHANNEL_TYPE ,DESCRIPTION , POLICY_TYPE FROM POLICY.AUTB_CHANNEL ");
            OracleCommand oCmd = new OracleCommand();
            oCmd.BindByName = true;
            oCmd.Connection = connection;
            oCmd.CommandType = CommandType.Text;

            oCmd.CommandText = sql.ToString();
            DataTable dt = await Utility.FillDataTableAsync(oCmd);

            if (dt.Rows.Count > 0)
            {
                returnValue = dt.AsEnumerable<AUTB_CHANNEL>().ToList();
            }

            oCmd.Dispose();
            return returnValue;
        }
        #endregion "Get User from AUTB_CHANNE"

        #region "Get GetReasonCode From CANCEL_BILL_REASON_CODE "
        public async Task<List<CANCEL_BILL_REASON_CODE>> GetReasonCode()
        {
            List<CANCEL_BILL_REASON_CODE> returnValue = null;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT CODE AS TCT_CODE2 ,DESCRIPTION AS TCT_DESC FROM policy.cstb_receipt_tmn_cause order by PROCESS_TYPE,CODE ");
            OracleCommand oCmd = new OracleCommand();
            oCmd.BindByName = true;
            oCmd.Connection = connection;
            oCmd.CommandType = CommandType.Text;

            oCmd.CommandText = sql.ToString();
            DataTable dt = await Utility.FillDataTableAsync(oCmd);

            if (dt.Rows.Count > 0)
            {
                returnValue = dt.AsEnumerable<CANCEL_BILL_REASON_CODE>().ToList();
            }

            oCmd.Dispose();
            return returnValue;
        }
        #endregion""Get GetReasonCode From CANCEL_BILL_REASON_CODE ""

        #region"Cancel Bill"
        public string isRenewalByPolicy(string policy, string cert, string channelType, string typeOfCh, out long? policyId)
        {

            string sqlStr = "";
            policyId = 0;
            string chk = "";

            if (typeOfCh == "P")
            {
                sqlStr = " SELECT DECODE(COUNT(*),0,'N','Y') AS CHK  \n" +
                    " FROM POLICY.U_APP_RENEWAL UAR,POLICY.U_APPLICATION_ID UAPPID,POLICY.U_APPLICATION UAPP, POLICY.P_APPL_ID APL, POLICY.P_POLICY_ID PID  \n" +
                    " WHERE UAPPID.APP_ID=UAPP.APP_ID AND UAPP.UAPP_ID=UAR.UAPP_ID AND UAPPID.APP_NO=APL.APP_NO   \n" +
                    " AND pid.POLICY = " + Utility.SQLValueString(policy) +
                    " AND PID.POLICY_ID=APL.POLICY_ID AND PID.CHANNEL_TYPE = " + Utility.SQLValueString(channelType);
            }
            else if (typeOfCh == "C")
            {
                sqlStr = " SELECT DECODE(COUNT(*),0,'N','Y') AS CHK   \n" +
                 " FROM POLICY.U_APP_RENEWAL UAR,POLICY.U_APPLICATION_ID UAPPID,POLICY.U_APPLICATION UAPP, POLICY.P_APPL_ID APL, POLICY.P_POLICY_ID PID, POLICY.P_POLICYHOLDING HOL \n" +
                 " WHERE UAPPID.APP_ID=UAPP.APP_ID AND UAPP.UAPP_ID=UAR.UAPP_ID AND UAPPID.APP_NO=APL.APP_NO   \n" +
                 " AND PID.POLICY_ID=HOL.POLICY_ID \n " +
                 " AND pid.POLICY = " + Utility.SQLValueString(cert) +
                 " AND hol.POLICY_HOLDING = " + Utility.SQLValueString(policy) +
                 " AND PID.POLICY_ID=APL.POLICY_ID AND PID.CHANNEL_TYPE = " + Utility.SQLValueString(channelType);
            }

            DataTable dt = Utility.FillDataTable(sqlStr, connection);
            if (dt != null && dt.Rows.Count > 0)
            {
                //  policyId = Utility.GetDBInt64Value(dt.Rows[0], "POLICY_ID");
                chk = Utility.GetDBStringValue(dt.Rows[0], "CHK");
            }

            //getpolicyid 
            if (typeOfCh == "P")
            {
                sqlStr = "   SELECT APL.POLICY_ID  \n" +
                    " FROM POLICY.U_APPLICATION_ID UAPPID, POLICY.U_APPLICATION UAPP, POLICY.P_APPL_ID APL, POLICY.P_POLICY_ID PID \n" +
                    "  WHERE UAPPID.APP_ID = UAPP.APP_ID  AND UAPPID.APP_NO = APL.APP_NO \n" +
                     " AND PID.POLICY =  " + Utility.SQLValueString(policy) +
                     " AND PID.POLICY_ID = APL.POLICY_ID AND PID.CHANNEL_TYPE = " + Utility.SQLValueString(channelType);
            }
            else if (typeOfCh == "C")
            {
                sqlStr = " SELECT APL.POLICY_ID  \n" +
                 " FROM POLICY.U_APPLICATION_ID UAPPID,POLICY.U_APPLICATION UAPP, POLICY.P_APPL_ID APL, POLICY.P_POLICY_ID PID, POLICY.P_POLICYHOLDING HOL \n" +
                 " WHERE UAPPID.APP_ID=UAPP.APP_ID AND UAPPID.APP_NO=APL.APP_NO   \n" +
                 " AND PID.POLICY_ID=HOL.POLICY_ID \n " +
                 " AND pid.POLICY = " + Utility.SQLValueString(cert) +
                 " AND hol.POLICY_HOLDING = " + Utility.SQLValueString(policy) +
                 " AND PID.POLICY_ID=APL.POLICY_ID AND PID.CHANNEL_TYPE = " + Utility.SQLValueString(channelType);
            }

            DataTable dt2 = Utility.FillDataTable(sqlStr, connection);
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                policyId = Utility.GetDBInt64Value(dt2.Rows[0], "POLICY_ID");
            }

            return chk;
        }

        public string isNewBis2018(long? policyId)
        {

            string sqlStr = "";
            //   policyId = 0;
            string chk = "";

            sqlStr = @"select decode(count(*),0,'N','Y')  AS CNT
                From p_appl_id apl,u_application_id uappid, u_App_isis isis
                where apl.app_no=uappid.app_no
                and uappid.app_id=isis.app_id 
                and (isis.guid is null or isis.guid = 'Y' or isis.guid = 'EDM')
                and policy_id = " + Utility.SQLValueString(policyId);

            DataTable dt =  Utility.FillDataTable(sqlStr, connection);
            if (dt != null && dt.Rows.Count > 0)
            {
                chk = Utility.GetDBStringValue(dt.Rows[0], "CNT");
            }

            return chk;
        }

        public async Task<List<DetailCancelBill>> GetDetailCancelBillRenewal(long? policyId, string BILLNO, string CHANNEL_TYPE, string TYPE_OF_CHANNEL)
        {
            string sqlStr;
            OracleCommand oCmd;
            List<DetailCancelBill> returnValue = null;
            long? check_bill_map = null;

            #region "check ว่าใบเสร็จกับเลข กธ math กัน"

            sqlStr = " Select policy_id From CS.CS_RECEIPT \n" +
                " Where policy_id = " + Utility.SQLValueString(policyId) +
                " AND tmn_flg = 'N' ";


            DataTable dt = await Utility.FillDataTableAsync(sqlStr, Connection);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    check_bill_map = Convert.ToInt64(dr["policy_id"].ToString());
                }
            }



            if (check_bill_map == null || check_bill_map == 0)
            {
                throw new Exception("เลขที่ใบเสร็จไม่สอดคล้องกับเลขกรมธรรม์");
            }

            #endregion

            long? P_Mode = null;
            string Custname = "";
            string PolicyType = "";
            string policy = "";
            string policyholding = "";

            if (TYPE_OF_CHANNEL == "P")
            {
                sqlStr =
                       " Select P_Mode,Nm.Prename || Nm.Name || ' ' || Nm.Surname As Customer,AU.POLICY_TYPE as PolicyType, NULL as policy_holding ,PID.POLICY" +
                       " From P_Policy_Id Pid,P_Life_Id Pli,P_Name_Id Nm, P_Pol_Name Ppn,AUTB_CHANNEL AU \n" +
                       " Where Pid.Policy_Id=Pli.Policy_Id And Pid.Policy_Id=Ppn.Policy_Id And Ppn.Name_Id=Nm.Name_Id And Nm.Tmn='N' \n" +
                       " AND PID.CHANNEL_TYPE=AU.CHANNEL_TYPE AND PID.CHANNEL_TYPE = " + Utility.SQLValueString(CHANNEL_TYPE) +
                       " AND pid.policy_id =" + Utility.SQLValueString(policyId);
            }
            else
            {
                sqlStr =
               " Select P_Mode,Nm.Prename || Nm.Name || ' ' || Nm.Surname As Customer,AU.POLICY_TYPE as PolicyType, hol.policy_holding as policy_holding,PID.POLICY \n" +
               " From P_Policy_Id Pid,P_Life_Id Pli,P_Name_Id Nm, P_Pol_Name Ppn,AUTB_CHANNEL AU, p_policyholding hol \n" +
               " Where Pid.Policy_Id=Pli.Policy_Id And Pid.Policy_Id=Ppn.Policy_Id And Ppn.Name_Id=Nm.Name_Id And Nm.Tmn='N' \n" +
               " AND PID.CHANNEL_TYPE=AU.CHANNEL_TYPE and pid.policy_id=hol.policy_id AND PID.CHANNEL_TYPE = " + Utility.SQLValueString(CHANNEL_TYPE) +
               " and pid.policy_id =" + Utility.SQLValueString(policyId);
            }


            DataTable dt2 = await Utility.FillDataTableAsync(sqlStr, Connection);

            if (dt2 != null && dt2.Rows.Count > 0)
            {
                P_Mode = Utility.GetDBInt64Value(dt2.Rows[0], "P_Mode");
                Custname = Utility.GetDBStringValue(dt2.Rows[0], "Customer");
                PolicyType = Utility.GetDBStringValue(dt2.Rows[0], "PolicyType");
                policy = Utility.GetDBStringValue(dt2.Rows[0], "policy");
                policyholding = Utility.GetDBStringValue(dt2.Rows[0], "policyholding");
            }

            sqlStr =
                 " SELECT TO_CHAR(RECEIPT_DT,'dd/MM/RRRR','NLS_CALENDAR = ''Thai Buddha'' NLS_DATE_language= THAI') AS BILLDT,PID.POLICY AS PPOLICY, HOL.POLICY_HOLDING AS CERTNO, PRM.POL_YR AS YR,PRM.POL_LT AS LT,  \n" +
                 " CS.RECEIPT_NO AS BILLNO, CS.AMOUNT AS SUMPREMIUM,LF.P_MODE AS PAY_MODE,  \n" +
                 " (SELECT PNI.PRENAME || PNI.NAME || ' ' || PNI.SURNAME FROM POLICY.P_NAME_ID PNI, POLICY.P_POL_NAME PPN WHERE PNI.TMN = 'N' AND PNI.NAME_ID = PPN.NAME_ID AND PPN.POLICY_ID = PID.POLICY_ID AND ROWNUM = 1) as Customer \n" +
                 " FROM CS.CS_RECEIPT CS, POLICY.P_POLICY_ID PID, POLICY.P_POLICYHOLDING HOL, CS.CS_RECEIPT_PREMIUM PRM, POLICY.P_LIFE_ID LF \n" +
                 " WHERE PID.POLICY_ID = CS.POLICY_ID AND PID.POLICY_ID = HOL.POLICY_ID(+) \n" +
                 " AND CS.RCP_ID = PRM.RCP_ID AND PID.POLICY_ID = LF.POLICY_ID \n" +
                 " AND CS.TMN_FLG = 'N' AND PID.POLICY_ID = " + Utility.SQLValueString(policyId);
            returnValue = (await Utility.FillDataTableAsync<DetailCancelBill>(sqlStr, connection, null))?.ToList();
            //returnValue = DataConvertor.List<DetailCancelBill>(Connection, sqlStr, P_Mode, Customer);


            return returnValue;
        }

        public async Task<List<DetailCancelBill>> GetDetailCancelBillV2(string POLICY, string BILLNO, string CHANNEL_TYPE, string TYPE_OF_CHANNEL, string HOLDING)
        {
            string sqlStr;
            OracleCommand oCmd;
            List<DetailCancelBill> returnValue = new List<DetailCancelBill>();
            string check_bill_map = "";

            #region "check ว่าใบเสร็จกับเลข กธ math กัน"

            try
            {
                isisViewConnection.Open();

                string whereHolding = "";

                if (HOLDING != "" && HOLDING != null)
                {
                    sqlStr = " Select policy_id From Bla_V_Ord_Bill \n" +
                        " Where Policy_Number=" + Utility.SQLValueString(HOLDING) +
                        " AND CERTIFICATE_NUMBER = " + Utility.SQLValueString(POLICY) +
                        " And Bill_Number_Fmt=" + Utility.SQLValueString(BILLNO) +
                        " AND IS_BILL_CANCELLED = 0 ";
                }
                else
                {
                    sqlStr = "Select policy_id From Bla_V_Ord_Bill \n" +
                        " Where Policy_Number=" + Utility.SQLValueString(POLICY) +
                        " AND CERTIFICATE_NUMBER = 0 \n" +
                        " And Bill_Number_Fmt=" + Utility.SQLValueString(BILLNO) +
                        " AND IS_BILL_CANCELLED = 0 ";
                }

                oCmd = new OracleCommand(sqlStr, isisViewConnection);
                check_bill_map = Convert.ToString(oCmd.ExecuteScalar());

                isisViewConnection.Close();
            }
            finally
            {
                isisViewConnection.Close();
            }

            if (check_bill_map == null || check_bill_map == "")
            {
                throw new Exception("เลขที่ใบเสร็จไม่สอดคล้องกับเลขกรมธรรม์");
            }
            #endregion

            long? P_Mode = null;
            string Custname = "";
            string PolicyType = "";
            string policy = "";
            string policyholding = "";

            if (TYPE_OF_CHANNEL == "P")
            {
                sqlStr =
                    " Select P_Mode,Nm.Prename || Nm.Name || ' ' || Nm.Surname As Custname,AU.POLICY_TYPE as PolicyType, NULL as policy_holding ,PID.POLICY" +
                    " From P_Policy_Id Pid,P_Life_Id Pli,P_Name_Id Nm, P_Pol_Name Ppn,AUTB_CHANNEL AU \n" +
                    " Where Pid.Policy_Id=Pli.Policy_Id And Pid.Policy_Id=Ppn.Policy_Id And Ppn.Name_Id=Nm.Name_Id And Nm.Tmn='N' \n" +
                    " AND PID.CHANNEL_TYPE=AU.CHANNEL_TYPE AND PID.CHANNEL_TYPE = " + Utility.SQLValueString(CHANNEL_TYPE) +
                    " AND pid.policy =" + Utility.SQLValueString(POLICY);
            }
            else
            {
                sqlStr =
               " Select P_Mode,Nm.Prename || Nm.Name || ' ' || Nm.Surname As Custname,AU.POLICY_TYPE as PolicyType, hol.policy_holding as policy_holding,PID.POLICY \n" +
               " From P_Policy_Id Pid,P_Life_Id Pli,P_Name_Id Nm, P_Pol_Name Ppn,AUTB_CHANNEL AU, p_policyholding hol \n" +
               " Where Pid.Policy_Id=Pli.Policy_Id And Pid.Policy_Id=Ppn.Policy_Id And Ppn.Name_Id=Nm.Name_Id And Nm.Tmn='N' \n" +
               " AND PID.CHANNEL_TYPE=AU.CHANNEL_TYPE and pid.policy_id=hol.policy_id AND PID.CHANNEL_TYPE = " + Utility.SQLValueString(CHANNEL_TYPE) +
               " and pid.policy =" + Utility.SQLValueString(POLICY) +
               " AND HOL.POLICY_HOLDING = " + Utility.SQLValueString(HOLDING);
            }


            DataTable dt = await Utility.FillDataTableAsync(sqlStr, Connection);

            if (dt != null && dt.Rows.Count > 0)
            {
                P_Mode = Utility.GetDBInt64Value(dt.Rows[0], "P_Mode");
                Custname = Utility.GetDBStringValue(dt.Rows[0], "Custname");
                PolicyType = Utility.GetDBStringValue(dt.Rows[0], "PolicyType");
                policy = Utility.GetDBStringValue(dt.Rows[0], "policy");
                policyholding = Utility.GetDBStringValue(dt.Rows[0], "policyholding");
            }


            try
            {
                isisViewConnection.Open();

                string whereHolding = "";

                if (P_Mode == 12)
                {
                    if (policyholding != "" && policyholding != null)
                    {
                        whereHolding = " AND LIFE.CERTIFICATE_NUMBER = " + Utility.SQLValueString(policy) + " AND LIFE.POLICY_NUMBER = " + Utility.SQLValueString(policyholding);
                    }
                    else
                    {
                        whereHolding = " AND LIFE.CERTIFICATE_NUMBER = '0' AND LIFE.POLICY_NUMBER = " + Utility.SQLValueString(policy);
                    }

                    sqlStr = " SELECT TO_CHAR(LIFE.BILL_DATE,'dd/MM/RRRR','NLS_CALENDAR = ''Thai Buddha'' NLS_DATE_language= THAI') BILLDT,LIFE.POLICY_NUMBER AS PPOLICY,LIFE.CERTIFICATE_NUMBER AS CERTNO,LIFE.POLICY_YEAR AS YR,LIFE.POLICY_LOT AS LT,LIFE.BILL_NUMBER_FMT AS BILLNO, \n" +
                         " (LIFE.PREMIUM+LIFE.EM_PREMIUM+LIFE.EF_PREMIUM+LIFE.XOCP_PREMIUM+LIFE.XTRA_PREMIUM) + SUM(NVL(RIDER.PREMIUM,0)+NVL(RIDER.EF_PREMIUM,0)+NVL(RIDER.EM_PREMIUM,0)+NVL(RIDER.XOCP_PREMIUM,0)+NVL(RIDER.XTRA_PREMIUM,0)) SUMPREMIUM,life.pay_mode,life.pre_name||life.first_name|| ' ' ||life.last_name as custname \n" +
                         " From BLA_V_ORD_BILL LIFE, BLA_V_ORD_BILL_RDR RIDER \n" +
                         " WHERE LIFE.POLICY_YEAR='1' AND (LIFE.POLICY_LOT='1' OR LIFE.POLICY_LOT='2') " +
                         " AND LIFE.IS_BILL_CANCELLED = 0 AND LIFE.BILL_NUMBER_fMT=RIDER.BILL_NUMBER_FMT(+)  \n" + whereHolding +
                         " GROUP BY LIFE.BILL_DATE,LIFE.POLICY_NUMBER,LIFE.CERTIFICATE_NUMBER,LIFE.POLICY_YEAR,LIFE.POLICY_LOT,LIFE.BILL_NUMBER_FMT,LIFE.PREMIUM,LIFE.EM_PREMIUM,LIFE.EF_PREMIUM,LIFE.XOCP_PREMIUM,LIFE.XTRA_PREMIUM,life.pay_mode,life.pre_name,life.first_name,life.last_name \n" +
                         " ORDER BY LIFE.POLICY_YEAR DESC,LIFE.POLICY_LOT DESC ";
                }
                else
                {
                    sqlStr = " SELECT TO_CHAR(LIFE.BILL_DATE,'dd/MM/RRRR','NLS_CALENDAR = ''Thai Buddha'' NLS_DATE_language= THAI') BILLDT,LIFE.POLICY_NUMBER AS PPOLICY,LIFE.CERTIFICATE_NUMBER AS CERTNO,LIFE.POLICY_YEAR AS YR,LIFE.POLICY_LOT AS LT,LIFE.BILL_NUMBER_FMT AS BILLNO, \n" +
                       " (LIFE.PREMIUM+LIFE.EM_PREMIUM+LIFE.EF_PREMIUM+LIFE.XOCP_PREMIUM+LIFE.XTRA_PREMIUM) +  SUM(NVL(RIDER.PREMIUM,0)+NVL(RIDER.EF_PREMIUM,0)+NVL(RIDER.EM_PREMIUM,0)+NVL(RIDER.XOCP_PREMIUM,0)+NVL(RIDER.XTRA_PREMIUM,0)) SUMPREMIUM,life.pay_mode,life.pre_name||life.first_name|| ' ' ||life.last_name as custname \n" +
                       " From BLA_V_ORD_BILL LIFE, BLA_V_ORD_BILL_RDR RIDER \n" +
                       " WHERE LIFE.POLICY_YEAR='1' AND LIFE.POLICY_LOT < 2 AND LIFE.BILL_NUMBER_FMT = " + Utility.SQLValueString(BILLNO) +
                       "  AND LIFE.IS_BILL_CANCELLED = 0 AND LIFE.BILL_NUMBER_fMT=RIDER.BILL_NUMBER_FMT(+)   \n" + whereHolding +
                       " GROUP BY LIFE.BILL_DATE,LIFE.POLICY_NUMBER,LIFE.CERTIFICATE_NUMBER,LIFE.POLICY_YEAR,LIFE.POLICY_LOT,LIFE.BILL_NUMBER_FMT,LIFE.PREMIUM,LIFE.EM_PREMIUM,LIFE.EF_PREMIUM,LIFE.XOCP_PREMIUM,LIFE.XTRA_PREMIUM,life.pay_mode,life.pre_name,life.first_name,life.last_name \n" +
                       " ORDER BY LIFE.POLICY_YEAR DESC,LIFE.POLICY_LOT DESC ";
                }

                returnValue = (await Utility.FillDataTableAsync<DetailCancelBill>(sqlStr, connection, null))?.ToList();

                isisViewConnection.Close();
            }
            finally
            {
                isisViewConnection.Close();
            }

            return returnValue;
        }

        public async Task<string> CheckInforce(string POLICY, string POLICY_HOLDING, string CHANNEL_TYPE)
        {
            string sqlStr = "";

            if (CHANNEL_TYPE == "OD" || CHANNEL_TYPE == "PN" || CHANNEL_TYPE == "PO" || CHANNEL_TYPE == "OM")
            {
                sqlStr = " select policy \n" +
                    " From p_policy_id pid,p_appl_id apl,u_application_id uappid,u_application uapp,u_status_id us \n" +
                    " where pid.policy_id=apl.policy_id and apl.app_no=uappid.app_no and uappid.app_id=uapp.app_id \n" +
                    " and us.uapp_id=uapp.uapp_id and us.status='IF' and rownum='1' and pid.policy=" + Utility.SQLValueString(POLICY);
            }
            else if (CHANNEL_TYPE == "GM" || CHANNEL_TYPE == "HL")
            {
                sqlStr = " select policy \n" +
                    " From p_policy_id pid,p_appl_id apl,u_application_id uappid,u_application uapp  ,p_policyholding hol \n" +
                    " where pid.policy_id=apl.policy_id and apl.app_no=uappid.app_no and uappid.app_id=uapp.app_id  \n" +
                    " and rownum='1' and hol.policy_id=pid.policy_id  and pid.policy=" + Utility.SQLValueString(POLICY) +
                    " and hol.policy_holding=" + Utility.SQLValueString(POLICY_HOLDING);
            }

            string policy = "";
            //policy = DataConvertor.ConvertToString(connection, sqlStr);


            DataTable dt = await Utility.FillDataTableAsync(sqlStr, connection);
            if (dt != null && dt.Rows.Count > 0)
            {
                policy = Utility.GetDBStringValue(dt.Rows[0], "policy");
            }
            return policy;
        }

        public string isRenewalAllChannel(string policy, string holding, out long? POLICY_ID)
        {
            string RENEW_FLG = "";
            POLICY_ID = null;
            string sqlStr = "";
            if (holding != null && holding != "")
            {
                sqlStr = " select DECODE(COUNT(*),0,'N','Y') RENEW_FLG \n" +
                    " from policy.p_policy_id pid,p_policyholding hol, p_appl_id apl,u_application_id uappid, u_application uapp,u_app_renewal ren  \n" +
                    " where pid.policy_id = hol.policy_id and pid.policy_id = apl.policy_id and apl.app_no = uappid.app_no and uappid.app_id = uapp.app_id  \n" +
                    " and uapp.uapp_id = ren.uapp_id  \n" +
                    " AND PID.POLICY = " + Utility.SQLValueString(policy) +
                    " AND hol.POLICY_HOLDING = " + Utility.SQLValueString(holding);
            }
            else
            {
                sqlStr = " select DECODE(COUNT(*),0,'N','Y') RENEW_FLG \n" +
                 " from policy.p_policy_id pid, p_appl_id apl,u_application_id uappid, u_application uapp,u_app_renewal ren  \n" +
                 " where pid.policy_id = apl.policy_id and apl.app_no = uappid.app_no and uappid.app_id = uapp.app_id  \n" +
                 " and uapp.uapp_id = ren.uapp_id  \n" +
                 " AND PID.POLICY = " + Utility.SQLValueString(policy);
            }

            DataTable dt = Utility.FillDataTable(sqlStr, connection);
            if (dt != null && dt.Rows.Count > 0)
            {
                RENEW_FLG = Utility.GetDBStringValue(dt.Rows[0], "RENEW_FLG");
            }

            if (holding != null && holding != "")
            {
                sqlStr = " select PID.POLICY_ID \n" +
                    " from policy.p_policy_id pid,p_policyholding hol, p_appl_id apl,u_application_id uappid, u_application uapp \n" +
                    " where pid.policy_id = hol.policy_id and pid.policy_id = apl.policy_id and apl.app_no = uappid.app_no and uappid.app_id = uapp.app_id  \n" +

                    " AND PID.POLICY = " + Utility.SQLValueString(policy) +
                    " AND hol.POLICY_HOLDING = " + Utility.SQLValueString(holding);
            }
            else
            {
                sqlStr = " select PID.POLICY_ID \n" +
                 " from policy.p_policy_id pid, p_appl_id apl,u_application_id uappid, u_application uapp \n" +
                 " where pid.policy_id = apl.policy_id and apl.app_no = uappid.app_no and uappid.app_id = uapp.app_id  \n" +
                 " AND PID.POLICY = " + Utility.SQLValueString(policy);
            }

            DataTable dt2 = Utility.FillDataTable(sqlStr, connection);
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                POLICY_ID = Utility.GetDBInt64Value(dt2.Rows[0], "POLICY_ID");
            }

            return RENEW_FLG;
        }


        public string CheckBillError(string POLICY)
        {
            string sqlStr = "";
            string policy_plan = "";
            string policy_remark = "";
            string BILLNO = "";
            string ReturnValue = "NOCANCEL";

            sqlStr = " SELECT BILLNO FROM CS_ORD_BILL WHERE ROWNUM=1 AND PPOLICY=" + Utility.SQLValueString(POLICY);
            string sqlStr_plan = "SELECT POLICY From Cs_Ord_Bill_Plan Where Rownum=1 And Policy=" + Utility.SQLValueString(POLICY);
            string sqlStr_remark = "SELECT POLICY From CS_ORD_BILL_REMARK WHERE ROWNUM=1 AND POLICY=" + Utility.SQLValueString(POLICY);

            var dt = Utility.FillDataTable(sqlStr , connection);
            if (dt != null && dt.Rows.Count > 0)
            {
                BILLNO  = Utility.GetDBStringValue(dt.Rows[0], "BILLNO");
            }
            var dt2 = Utility.FillDataTable(sqlStr_plan, connection);
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                policy_plan = Utility.GetDBStringValue(dt2.Rows[0], "POLICY");
            }
            var dt3 = Utility.FillDataTable(sqlStr_remark, connection);
            if (dt3 != null && dt3.Rows.Count > 0)
            {
                policy_remark = Utility.GetDBStringValue(dt3.Rows[0], "POLICY");
            }
            

            //ถ้ามีใบเสร็จ error ตกค้างมา ไล่ลบออก
            if (BILLNO == "" || BILLNO == null)
            {
                if (policy_plan != "" || policy_plan != null)
                {
                    sqlStr = " delete from Cs_Ord_Bill_Plan where policy =" + Utility.SQLValueString(POLICY);
                    OracleCommand oCmd = new OracleCommand(sqlStr, connection);
                    int c = oCmd.ExecuteNonQuery();
                    ReturnValue = "CANCELED";
                }

                if (policy_remark != "" || policy_remark != null)
                {
                    sqlStr = " delete from Cs_Ord_Bill_remark where policy =" + Utility.SQLValueString(POLICY);
                    OracleCommand oCmd = new OracleCommand(sqlStr, connection);
                    int c = oCmd.ExecuteNonQuery();
                    ReturnValue = "CANCELED";
                }
            }

            return ReturnValue;
        }

        public void DEL_ORDBILL_NEW(string INPOLICY, string INCERT, string INBILLNO, string INUSERID, string INCHANNELTYPE, out string MSG)
        {
            try
            {
                //string sqlStr = PKG_CSORDBILL + ".DEL_ORDBILL";
                string sqlStr = "PKG_CSORDBILL" + ".DEL_ORDBILL_NEW";
                OracleCommand oCmd = new OracleCommand(sqlStr, connection);
                oCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter V_INPOLICY = new OracleParameter("V_INPOLICY", OracleDbType.Varchar2, INPOLICY, ParameterDirection.Input);
                oCmd.Parameters.Add(V_INPOLICY);
                OracleParameter V_INCERT = new OracleParameter("V_INCERT", OracleDbType.Varchar2, INCERT, ParameterDirection.Input);
                oCmd.Parameters.Add(V_INCERT);
                OracleParameter V_INBILLNO = new OracleParameter("V_INBILLNO", OracleDbType.Varchar2, INBILLNO, ParameterDirection.Input);
                oCmd.Parameters.Add(V_INBILLNO);
                OracleParameter V_INUSERID = new OracleParameter("V_INUSERID", OracleDbType.Varchar2, INUSERID, ParameterDirection.Input);
                oCmd.Parameters.Add(V_INUSERID);
                OracleParameter V_INCHANNELTYPE = new OracleParameter("V_INCHANNELTYPE", OracleDbType.Varchar2, INCHANNELTYPE, ParameterDirection.Input);
                oCmd.Parameters.Add(V_INCHANNELTYPE);
                OracleParameter V_MSG = new OracleParameter("V_MSG", OracleDbType.Varchar2, ParameterDirection.Output);
                V_MSG.Size = 200;
                oCmd.Parameters.Add(V_MSG);
                oCmd.ExecuteNonQuery();
                MSG = Utility.GetOraParamString(V_MSG);
            }
            catch (Exception ex)
            {
                MSG = null;
            }
        }
        public void DEL_FSDGMPREM(string INPOLICY, string INCERT, string INBILLNO, string INUSERID, string INCHANNELTYPE, out string MSG)
        {
            MSG = null;
            try
            {
                string sqlStr =
                     " UPDATE FSD_GM_PREM \n" +
                     " SET  CANCEL_DT = SYSDATE, \n" +
                     " PTYPE = 'C', \n" +
                     " STATUS = '1'    \n" +
                     " WHERE POLICY = " + Utility.SQLValueString(INPOLICY) +
                     " AND CERT_NO = " + Utility.SQLValueString(INCERT);
                OracleCommand oCmd = new OracleCommand(sqlStr, connection);
                int c = oCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MSG = ex.ToString();
            }
        }

        public void CANCEL_RECEIPT(string IN_RECEIPTNO, string IN_REASONCODE, string IN_REMARK, string IN_USER, out string OUT_MSG)
        {
            OUT_MSG = "N";
            string sqlStr = "POLICY.PKG_RECEIPT.CANCEL_RECEIPT";
            OracleCommand oCmd = new OracleCommand(sqlStr, connection);
            oCmd.CommandType = CommandType.StoredProcedure;

            OracleParameter V_IN_RECEIPTNO = new OracleParameter("IN_RECEIPTNO", OracleDbType.Varchar2, IN_RECEIPTNO, ParameterDirection.Input);
            oCmd.Parameters.Add(V_IN_RECEIPTNO);
            OracleParameter V_IN_REASONCODE = new OracleParameter("IN_REASONCODE", OracleDbType.Varchar2, IN_REASONCODE, ParameterDirection.Input);
            oCmd.Parameters.Add(V_IN_REASONCODE);
            OracleParameter V_IN_REMARK = new OracleParameter("IN_REMARK", OracleDbType.Varchar2, IN_REMARK, ParameterDirection.Input);
            oCmd.Parameters.Add(V_IN_REMARK);
            OracleParameter V_IN_USER = new OracleParameter("IN_USER", OracleDbType.Varchar2, IN_USER, ParameterDirection.Input);
            oCmd.Parameters.Add(V_IN_USER);

            OracleParameter V_OUT_MSG = new OracleParameter("OUT_MSG", OracleDbType.Varchar2, ParameterDirection.Output);
            V_OUT_MSG.Size = 200;
            oCmd.Parameters.Add(V_OUT_MSG);

            oCmd.ExecuteNonQuery();

            OUT_MSG = Utility.GetOraParamString(V_OUT_MSG);
        }
        #endregion"Cancel Bill"

        #region"GetLifeByPolicy from policy service"
        public override long? GetLifeByPolicy(out P_LIFE_ID[] dataObjects, string POLICY)
        {
            long? policy_id = null;

            string sqlStr = " SELECT LIFE.* FROM P_LIFE_ID LIFE ,P_POLICY_ID PID \n" +
                " WHERE LIFE.POLICY_ID = PID.POLICY_ID AND PID.POLICY =" + Utility.SQLValueString(POLICY);

            DataTable dt = Utility.FillDataTable(sqlStr, connection);
            dataObjects = DataConvertor.P_LIFE_ID(dt);

            sqlStr = " SELECT POLICY_ID FROM P_POLICY_ID \n" +
               " WHERE POLICY =" + Utility.SQLValueString(POLICY);

            policy_id = DataConvertor.ConvertToInt64(Connection, sqlStr);
            return policy_id;
        }
        #endregion"GetLifeByPolicy from policy service"
    }
}
