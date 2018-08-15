using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHRSuite.Objects;

namespace MyHRSuite.Common
{
    public class DataIntegrity
    {
        public static HRCore GetIntegrity()
        {
            String connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            HRCore hRCore = new HRCore();
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("select" +
                " (select(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPCONTA A, [196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA B WHERE A.CODPESOA = B.CODPESOA AND B.CONTRIB = '') + (select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPCONTA A WHERE A.CODPESOA NOT IN(SELECT CODPESOA FROM[196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA WHERE CODPESOA IS NOT NULL))) 'Contacts', " +
                "(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPCONTA A) 'AllContacts'," +
                "(select(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPHABFU A, [196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA B WHERE A.CODPESOA = B.CODPESOA AND B.CONTRIB = '')+ (select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPHABFU A WHERE A.CODPESOA NOT IN(SELECT CODPESOA FROM[196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA WHERE CODPESOA IS NOT NULL)))'Qualifications'," +
                "(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPHABFU A) 'AllQualifications'," +
                "(select(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPADDRE A, [196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA B WHERE A.CODPESOA = B.CODPESOA AND B.CONTRIB = '')+ (select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPADDRE A WHERE A.CODPESOA NOT IN(SELECT CODPESOA FROM[196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA WHERE CODPESOA IS NOT NULL)))'Address'," +
                "(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPADDRE A) 'AllAddress'," +
                "(select(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPEMERC A, [196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA B WHERE A.CODPESOA = B.CODPESOA AND B.CONTRIB = '')+ (select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPEMERC A WHERE A.CODPESOA NOT IN(SELECT CODPESOA FROM[196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA WHERE CODPESOA IS NOT NULL)))'EmergencyContacts'," +
                "(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPEMERC A) 'AllEmergencyContacts'," +
                "(select(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPCCART A, [196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA B WHERE A.CODPESOA = B.CODPESOA AND B.CONTRIB = '')+ (select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPCCART A WHERE A.CODPESOA NOT IN(SELECT CODPESOA FROM[196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA WHERE CODPESOA IS NOT NULL)))'Documents'," +
                "(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPCCART A) 'AllDocuments'," +
                "(select(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPAGREG A, [196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA B WHERE A.CODPESOA = B.CODPESOA AND B.CONTRIB = '')+ (select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPAGREG A WHERE A.CODPESOA NOT IN(SELECT CODPESOA FROM[196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA WHERE CODPESOA IS NOT NULL)))'Dependents'," +
                "(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPAGREG A) 'AllDependents'," +
                "(select(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPPEMEM A, [196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA B WHERE A.CODPESOA = B.CODPESOA AND B.CONTRIB = '')+ (select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPPEMEM A WHERE A.CODPESOA NOT IN(SELECT CODPESOA FROM[196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA WHERE CODPESOA IS NOT NULL)))'Professional Membership'," +
                "(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPPEMEM A) 'AllMemberships'," +
                "(select(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPWORKP A, [196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA B WHERE A.CODPESOA = B.CODPESOA AND B.CONTRIB = '')+ (select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPWORKP A WHERE A.CODPESOA NOT IN(SELECT CODPESOA FROM[196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA WHERE CODPESOA IS NOT NULL)))'Work Permits'," +
                "(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPWORKP A) 'AllPermits'; ", con);
            try
            {
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hRCore.Address = int.Parse(reader["Address"].ToString());
                        hRCore.Contacts = int.Parse(reader["Contacts"].ToString());
                        hRCore.Qualification = int.Parse(reader["Qualifications"].ToString());
                        hRCore.EmergencyContacts = int.Parse(reader["EmergencyContacts"].ToString());
                        hRCore.Documents = int.Parse(reader["Documents"].ToString());
                        hRCore.Dependents = int.Parse(reader["Dependents"].ToString());
                        hRCore.ProfessionalMemberships = int.Parse(reader["Professional Membership"].ToString());
                        hRCore.WorkPermits = int.Parse(reader["Work Permits"].ToString());

                        hRCore.AllAddress = int.Parse(reader["Address"].ToString()) / int.Parse(reader["AllAddress"].ToString());
                        hRCore.AllContacts = int.Parse(reader["AllContacts"].ToString());
                        hRCore.AllDependents = int.Parse(reader["AllDependents"].ToString());
                        hRCore.AllQualifications = int.Parse(reader["AllQualifications"].ToString());
                        hRCore.AllDocuments = int.Parse(reader["AllDocuments"].ToString());
                        hRCore.AllMemberships = int.Parse(reader["AllMemberships"].ToString());
                        hRCore.AllEmergencyContacts = int.Parse(reader["AllEmergencyContacts"].ToString());
                        hRCore.AllPermits = int.Parse(reader["AllPermits"].ToString());
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return hRCore;
        }

        public static Overall GetHR()
        {
            String connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            HRCore hRCore = new HRCore();
            Overall overall = new Overall();
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("select (select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gippromo a where a.codfunci not in (select codfunci from[196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) 'funcisit'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].giprotac a where a.codfunci not in (select codfunci from[196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) 'post'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipcashb a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) 'benefits'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipfalta a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) 'leave'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipemvac a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) 'entitlements'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipmedex a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) 'medicalinfo'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipmedif a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) 'medicaladd'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipbenef a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null))  'beneficiaries'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipmedal a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null))  'awards'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipdisci a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null))  'disciplinary'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipemmem a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null))  'unions'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipanexo a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null))  'attachments'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipaentr a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null))  'allowances'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipdscnt a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null))  'deduction'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipempbk a where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null))  'banks';", con);
            try
            {
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        overall.FuncSit = int.Parse(reader["funcisit"].ToString());
                        overall.Posts = int.Parse(reader["post"].ToString());
                        overall.Benefits = int.Parse(reader["benefits"].ToString());
                        overall.Leave = int.Parse(reader["leave"].ToString());
                        overall.Entitlements = int.Parse(reader["entitlements"].ToString());
                        overall.MedicalInfo = int.Parse(reader["medicalinfo"].ToString());
                        overall.MedicalAdd = int.Parse(reader["medicaladd"].ToString());
                        overall.Beneficiaries = int.Parse(reader["beneficiaries"].ToString());

                        overall.Awards = int.Parse(reader["awards"].ToString());
                        overall.DisciplinaryAction = int.Parse(reader["disciplinary"].ToString());
                        overall.Unions = int.Parse(reader["unions"].ToString());
                        overall.Attachments = int.Parse(reader["attachments"].ToString());
                        overall.Allowances = int.Parse(reader["allowances"].ToString());
                        overall.Deductions = int.Parse(reader["deduction"].ToString());
                        overall.BankAccounts = int.Parse(reader["banks"].ToString());

                        overall.HRCore = GetIntegrity();

                    }
                }

                con.Close();
                return overall;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return overall;
        }



        public static People GetPeople()
        {
            String connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            People people = new People();
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("select(select Count(*) from [196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA where contrib = '') as 'TRN'," +
                "(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA where SEXO ='') as 'Gender'," +
                "(select Count(*) from[196.3.190.28].GIPPREPROD2016.dbo.GIPPESOA where NSOFE = '') as 'NIS'", con);
            try
            {
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        people.Trn = int.Parse(reader["TRN"].ToString());
                        people.Gender = int.Parse(reader["Gender"].ToString());
                        people.Nis = int.Parse(reader["NIS"].ToString());

                    }

                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            return people;
        }

        public static List<User> GetUserInfo()
        {
            String connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            List<User> user = new List<User>();
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("select NOME, (SELECT A.NOME FROM [196.3.190.28].GIPPREPROD2016.dbo.GIPEMPRE WHERE CODEMPRE = B.CODEMPRE ) as 'MDA', A.EMAIL from [196.3.190.28].GIPPREPROD2016.dbo.USERLOGIN A, [196.3.190.28].GIPPREPROD2016.dbo.GIPUSUNI B where A.CODPSW = B.CODPSW AND A.EMAIL  = ''", con);
            try
            {

                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.Add(new User { Username = reader["NOME"].ToString(), MDA = reader["MDA"].ToString(), Email = reader["EMAIL"].ToString() });
                        
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {

            }
            return user;
        }
        public static List<HrSupport> GetSupportInfo()
        {
            String connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
           List<HrSupport> hrSupport = new List<HrSupport>();
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("select NOME, COUNT(*) as 'Count' from [196.3.190.28].GIPPREPROD2016.dbo.USERLOGIN GROUP BY NOME HAVING(Count(*) >1)", con);
            try
            {

                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hrSupport.Add(new HrSupport {  Username = reader["NOME"].ToString(), Occurance = int.Parse(reader["Count"].ToString()) });


                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {

            }
            return hrSupport;
        }
    }
}
