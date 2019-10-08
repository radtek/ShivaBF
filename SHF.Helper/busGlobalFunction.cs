#region [NameSpaces]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Security.Cryptography;
//using Omu.AwesomeMvc;


#endregion

namespace SHF.Helper
{
    public static class busGlobalFunction
    {
        const string _istrImageTagRegex = "<img ([a-zA-Z0-9_\\-/=;'\"\r\n\t ]+) src=['\"]([a-zA-Z0-9_\\-/=;\r\n\t.'\" ]+)['\"]";
        const string _istrImageTagReconstruct = "<img {0} src=\"cid:{1}\" ";
        const string _istrHtmlTagRegex = "<.*?>|&.*?;";

        private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public static DateTime ApplicationDateTime() => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);

        #region Common Methods

        /// <summary>
        /// Converts string to Proper case
        /// Ex. mcdonald --> McDonald, neil o'brien --> Neil O'Brien       
        /// </summary>
        /// <param name="astrTextToFormat"></param>
        /// <returns></returns>
        public static string ConvertToProperCase(string astrTextToFormat)
        {
            if (astrTextToFormat.IsNullOrEmpty())
                return astrTextToFormat;

            TextInfo lobjTextInfo = new CultureInfo("en-US", false).TextInfo;
            astrTextToFormat = lobjTextInfo.ToTitleCase(astrTextToFormat.ToLower());
            StringBuilder lstrbProperCaseWords = new StringBuilder();
            char[] larrProperWord;
            string lstrWord = "";
            foreach (string lstrText in astrTextToFormat.Split(" "))
            {
                lstrWord = lstrText;
                larrProperWord = lstrText.ToCharArray();
                if (lstrWord.Contains("'") && lstrWord.IndexOf("'") == 1 && lstrWord.Length >= 3)
                {
                    larrProperWord[lstrWord.IndexOf("'") + 1] = Char.ToUpper(larrProperWord[lstrWord.IndexOf("'") + 1]);
                    lstrWord = new string(larrProperWord);
                }
                if (larrProperWord.Length > 3 && (char.ToUpper(larrProperWord[0]) == 'M' && char.ToLower(larrProperWord[1]) == 'c' && !String.IsNullOrEmpty(larrProperWord[2].ToString())))
                {
                    larrProperWord[0] = char.ToUpper(larrProperWord[0]);
                    larrProperWord[1] = char.ToLower(larrProperWord[1]);
                    larrProperWord[2] = char.ToUpper(larrProperWord[2]);
                }

                lstrbProperCaseWords.Append(new string(larrProperWord) + " ");
            }

            return lstrbProperCaseWords.ToString().Substring(0, lstrbProperCaseWords.Length - 1);
        }

        /// <summary>
        /// Checks whether the email address is valid(Should not have white spaces).
        /// </summary>
        /// <param name="astrEmailID">The email address that is to be validated.</param>
        /// <returns>Returns true if the email address is valid.</returns>
        public static bool IsValidateEmail(string astrEmailID)
        {
            string lstrPattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            return astrEmailID.ValidateRegularExpression(lstrPattern);
        }

        /// <summary>
        /// Validates the string with given regular expression.
        /// </summary>
        /// <param name="astrStringValue">The string that is to be validated.</param>
        /// <param name="astrPattern">The regular expression pattern from which the string is to be validated.</param>
        /// <returns>Returns true if the regular expression matches the given pattern, else false.</returns>
        public static bool ValidateRegularExpression(this string astrStringValue, string astrPattern)
        {
            if (string.IsNullOrWhiteSpace(astrStringValue) || astrPattern == null)
            {
                return false;
            }
            return ((new Regex(astrPattern)).IsMatch(astrStringValue));
        }

        /// <summary>
        /// Check whether two date range overlaps each other.
        /// </summary>
        /// <param name="adtStart1"></param>
        /// <param name="adtEnd1"></param>
        /// <param name="adtStart2"></param>
        /// <param name="adtEnd2"></param>
        /// <returns></returns>
        public static bool IsDateRangeOverlaps(DateTime adtStart1, DateTime adtEnd1, DateTime adtStart2, DateTime adtEnd2)
        {
            bool lblnResult = false;
            DateTime ldtStart = adtStart1 > adtStart2 ? adtStart1 : adtStart2; // max of starts 
            DateTime ldtSend = adtEnd1 < adtEnd2 ? adtEnd1 : adtEnd2; // min of ends 
            if (ldtStart <= ldtSend)
            {
                lblnResult = true;
            }
            return lblnResult;
        }

        /// <summary>
        /// Convert string to ProperCase
        /// </summary>
        /// <param name="astrInput">Input String</param>
        /// <returns>Propercase string</returns>
        public static string ToProperCase(this string astrInput)
        {
            if (string.IsNullOrWhiteSpace(astrInput))
                return string.Empty;
            else
            {
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo lobjTextInfo = cultureInfo.TextInfo;
                return lobjTextInfo.ToTitleCase(astrInput.ToLower());
            }
        }

        /// <summary>
        /// Format String input to remove SQL Injection charaacters.
        /// </summary>
        /// <param name="astrInput">Input String</param>
        /// <returns>Safe String</returns>
        public static string FormatStringtoPreventSQLInjection(string astrInput)
        {
            string lstrOutput = astrInput.Trim().Replace("'", "''");
            return lstrOutput;
        }
        /// <summary>
        /// Calculates the Current Age of person.
        /// </summary>
        /// <param name="adtDateOfBirth">Date Of Birth</param>
        /// <param name="adtAgeCalculationDate">Age Calcualtion Date</param>
        /// <returns>DateTime</returns>
        public static int CalculateAge(DateTime adtDateOfBirth, DateTime adtAgeCalculationDate)
        {
            int lintYears = adtAgeCalculationDate.Year - adtDateOfBirth.Year;
            // subtract another year if we're before the
            // birth day in the current year
            if ((adtAgeCalculationDate.Month < adtDateOfBirth.Month) ||
                 (adtAgeCalculationDate.Month == adtDateOfBirth.Month && adtAgeCalculationDate.Day < adtDateOfBirth.Day))
            {
                lintYears--;
            }

            return lintYears;
        }

        /// <summary>
        /// Calculates the current Age of person in year and months
        /// </summary>
        /// <param name="adtDateOfBirth">Person Date Of Birth</param>
        /// <param name="adtAgeCalculationDate">Age Calculation Date</param>
        /// <returns>Age in year and months</returns>
        public static String CalculateAgeInYearAndMonths(DateTime adtDateOfBirth, DateTime adtAgeCalculationDate)
        {
            int lintMonths = 0;
            int lintYears = 0;
            int lintDaysInBdayMonth = DateTime.DaysInMonth(adtDateOfBirth.Year, adtDateOfBirth.Month);
            int lintDaysRemain = adtAgeCalculationDate.Day + (lintDaysInBdayMonth - adtDateOfBirth.Day);
            if (adtAgeCalculationDate.Month > adtDateOfBirth.Month)
            {
                lintYears = adtAgeCalculationDate.Year - adtDateOfBirth.Year;
                lintMonths = adtAgeCalculationDate.Month - (adtDateOfBirth.Month + 1) + Math.Abs(lintDaysRemain / lintDaysInBdayMonth);
            }
            else if (adtAgeCalculationDate.Month == adtDateOfBirth.Month)
            {
                if (adtAgeCalculationDate.Day >= adtDateOfBirth.Day)
                {
                    lintYears = adtAgeCalculationDate.Year - adtDateOfBirth.Year;
                    lintMonths = busConstant.Numbers.Integer.ZERO;
                }
                else
                {
                    lintYears = (adtAgeCalculationDate.Year - 1) - adtDateOfBirth.Year;
                    lintMonths = busConstant.Numbers.Integer.TEN + busConstant.Numbers.Integer.ONE;
                }
            }
            else
            {
                lintYears = (adtAgeCalculationDate.Year - 1) - adtDateOfBirth.Year;
                lintMonths = adtAgeCalculationDate.Month + (11 - adtDateOfBirth.Month) + Math.Abs(lintDaysRemain / lintDaysInBdayMonth);
            }
            return string.Format("{0} Year{1} {2} Month{3} ", lintYears, (lintYears == 1) ? "" : "(s)", lintMonths, (lintMonths == 1) ? "" : "(s)");
        }

        /// <summary>
        /// Calculates the current Age of person in year and months
        /// </summary>
        /// <param name="adtDateOfBirth"></param>
        /// <param name="adtAgeCalculationDate"></param>
        /// <param name="lintYears"></param>
        /// <param name="lintMonths"></param>
        public static void CalculateAgeInYearAndMonths(DateTime adtDateOfBirth, DateTime adtAgeCalculationDate, out int lintYears, out int lintMonths)
        {
            lintMonths = 0;
            lintYears = 0;
            int lintDaysInBdayMonth = DateTime.DaysInMonth(adtDateOfBirth.Year, adtDateOfBirth.Month);
            int lintDaysRemain = adtAgeCalculationDate.Day + (lintDaysInBdayMonth - adtDateOfBirth.Day);
            if (adtAgeCalculationDate.Month > adtDateOfBirth.Month)
            {
                lintYears = adtAgeCalculationDate.Year - adtDateOfBirth.Year;
                lintMonths = adtAgeCalculationDate.Month - (adtDateOfBirth.Month + 1) + Math.Abs(lintDaysRemain / lintDaysInBdayMonth);
            }
            else if (adtAgeCalculationDate.Month == adtDateOfBirth.Month)
            {
                if (adtAgeCalculationDate.Day >= adtDateOfBirth.Day)
                {
                    lintYears = adtAgeCalculationDate.Year - adtDateOfBirth.Year;
                    lintMonths = busConstant.Numbers.Integer.ZERO;
                }
                else
                {
                    lintYears = (adtAgeCalculationDate.Year - 1) - adtDateOfBirth.Year;
                    lintMonths = (busConstant.Numbers.Integer.TEN + busConstant.Numbers.Integer.ONE);
                }
            }
            else
            {
                lintYears = (adtAgeCalculationDate.Year - 1) - adtDateOfBirth.Year;
                lintMonths = adtAgeCalculationDate.Month + (11 - adtDateOfBirth.Month) + Math.Abs(lintDaysRemain / lintDaysInBdayMonth);
            }
        }
        /// <summary>
        /// Append a string with the specified character and string
        /// </summary>
        /// <param name="astrOriginal">Original String</param>
        /// <param name="astrAppendString">String to be appended</param>
        /// <param name="aenmAppendCharacter">Append Character</param>
        /// <returns>Appended String</returns>
        public static string AppendStringWithChar(string astrOriginal, string astrAppendString, enmAppendCharacter aenmAppendCharacter)
        {
            if (string.IsNullOrEmpty(astrOriginal))
                return astrAppendString;
            else if (string.IsNullOrEmpty(astrAppendString))
                return astrOriginal;
            else
            {
                switch (aenmAppendCharacter)
                {
                    case enmAppendCharacter.Comma:
                        return string.Format("{0},{1}", astrOriginal, astrAppendString);
                    case enmAppendCharacter.CommaSpace:
                        return string.Format("{0}, {1}", astrOriginal, astrAppendString);
                    case enmAppendCharacter.Space:
                        return string.Format("{0} {1}", astrOriginal, astrAppendString);
                    case enmAppendCharacter.FullStopSpace:
                        return string.Format("{0}. {1}", astrOriginal, astrAppendString);
                    case enmAppendCharacter.Newline:
                        return string.Format("{0}\n{1}", astrOriginal, astrAppendString);
                    case enmAppendCharacter.Dash:
                        return string.Format("{0}-{1}", astrOriginal, astrAppendString);
                    case enmAppendCharacter.QuestionSpace:
                        return string.Format("{0}? {1}", astrOriginal, astrAppendString);
                    case enmAppendCharacter.ExclamationSpace:
                        return string.Format("{0}! {1}", astrOriginal, astrAppendString);
                    default:
                        return string.Format("{0}{1}", astrOriginal, astrAppendString);
                }
            }
        }

        /// <summary>
        /// Get Working Date
        /// </summary>
        /// <param name="adtDateFrom">From Date</param>
        /// <param name="aintNoOfDays">No of Days afer From Date</param>
        /// <returns>Working Dates</returns>
        public static DateTime AddWorkingDays(this DateTime adtDateFrom, int aintNoOfDays)
        {
            int lintIncrementOrDecrement = aintNoOfDays >= 0 ? 1 : -1;

            while (aintNoOfDays != 0)
            {
                adtDateFrom = adtDateFrom.AddDays(lintIncrementOrDecrement);

                if (busHoliday.IsDateAWeekWorkDay(adtDateFrom))
                    aintNoOfDays -= lintIncrementOrDecrement;
            }

            return adtDateFrom;
        }

        /// <summary>
        /// Checks whether given date is first business day of the month.
        /// </summary>
        /// <param name="adtGivenDate"></param>
        /// <returns></returns>
        public static bool IsFirstBusinessDayOftheMonth(DateTime adtGivenDate)
        {
            return (adtGivenDate.Date == GetFirstBusinessDayOftheMonth(adtGivenDate).Date);
        }

        /// <summary>
        /// This method gets first business day of the month.
        /// </summary>
        /// <param name="adtGivenDate"></param>
        /// <returns></returns>
        public static DateTime GetFirstBusinessDayOftheMonth(DateTime adtGivenDate)
        {
            DateTime ldtDate = new DateTime(adtGivenDate.Year, adtGivenDate.Month, 1);
            DateTime ldtLastDayOfMonth = new DateTime(ldtDate.Year, ldtDate.Month, DateTime.DaysInMonth(ldtDate.Year, ldtDate.Month));
            DateTime ldtFirstBusinessDay = ldtDate;

            do
            {
                if (!IsDateAWeekWorkDay(ldtDate))
                {
                    ldtDate = ldtDate.AddDays(1);
                }
                else
                {
                    ldtFirstBusinessDay = ldtDate;
                    break;
                }

            } while (ldtDate <= ldtLastDayOfMonth);

            return ldtFirstBusinessDay;
        }

        /// <summary>
        /// Get First Day of Month
        /// </summary>
        /// <param name="adtDateInGivenMonth">Date in the Month</param>
        /// <returns>First Day of the Month</returns>
        public static DateTime GetFirstDayOfMonth(this DateTime adtDateInGivenMonth)
        {
            return new DateTime(adtDateInGivenMonth.Year, adtDateInGivenMonth.Month, 1);
        }

        /// <summary>
        /// Get Last Day of Month
        /// </summary>
        /// <param name="adtDateInGivenMonth">Date in the Month</param>
        /// <returns>Last Day of the Month</returns>
        public static DateTime GetLastDayOfMonth(this DateTime adtDateInGivenMonth)
        {
            return (adtDateInGivenMonth.GetFirstDayOfMonth()).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Get First Day of next Month
        /// </summary>
        /// <param name="adtDateInGivenMonth">Date in the Month</param>
        /// <returns>First Day of the Month</returns>
        public static DateTime GetFirstDayOfNextMonth(this DateTime adtDateInGivenMonth)
        {
            return new DateTime(adtDateInGivenMonth.Year, adtDateInGivenMonth.AddMonths(1).Month, 1);
        }

        /// <summary>
        /// Get Last Day of previous Month
        /// </summary>
        /// <param name="adtDateInGivenMonth">Date in the Month</param>
        /// <returns>Last Day of the Month</returns>
        public static DateTime GetLastDayOfPreviousMonth(this DateTime adtDateInGivenMonth)
        {
            return (adtDateInGivenMonth.GetFirstDayOfMonth()).AddDays(-1);
        }

        /// <summary>
        /// Check if the given date is a work date
        /// </summary>
        /// <param name="adtGivenDate">Given Date</param>
        /// <returns>True if work day; False if not</returns>
        public static bool IsDateAWeekWorkDay(this DateTime adtGivenDate)
        {
            return busHoliday.IsDateAWeekWorkDay(adtGivenDate);
        }

        /// <summary>
        /// This method returns true/false if given date is Weekend date.
        /// </summary>
        /// <param name="adtDate">Date</param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime adtDate)
        {
            return busHoliday.IsWeekend(adtDate);
        }

        /// <summary>
        /// This method returns true/false if given date is holiday date
        /// </summary>
        /// <param name="adtDate">Date</param>
        /// <returns></returns>
        public static bool IsHoliday(this DateTime adtDate)
        {
            return busHoliday.IsHoliday(adtDate);
        }

        /// <summary>
        /// Returns the count of working days between two days
        /// </summary>
        /// <param name="adtStartDate">Start Date</param>
        /// <param name="adtEndDate">End Date</param>
        /// <returns>Count of Working Days</returns>
        public static int CountOfWorkingDays(DateTime adtStartDate, DateTime adtEndDate)
        {
            return busHoliday.GetNoOfWorkingDays(adtStartDate, adtEndDate);
        }

        /// <summary>
        /// Check if the Given date is in the current fiscal year
        /// </summary>
        /// <param name="adtGivenDate">Date</param>
        /// <returns>True if is in current fiscal year; False if not</returns>
        public static bool IsDateInCurrentFiscalYear(DateTime adtGivenDate)
        {
            DateTime ldtCurrentFiscalYearStart = DateTime.MinValue;
            DateTime ldtCurrentFiscalYearEnd = DateTime.MinValue;

            // Get current fiscal year range
            GetCurrentFisalYearRange(ref ldtCurrentFiscalYearStart, ref ldtCurrentFiscalYearEnd);

            return (ldtCurrentFiscalYearStart <= adtGivenDate && adtGivenDate <= ldtCurrentFiscalYearEnd);
        }

        /// <summary>
        /// Check if the Given date is Less than current fiscal year
        /// </summary>
        /// <param name="adtGivenDate">Date</param>
        /// <returns>True if Less than current fiscal year; False if not</returns>
        public static bool IsDateLessThanCurrentFiscalYear(DateTime adtGivenDate)
        {
            DateTime ldtCurrentFiscalYearStart = DateTime.MinValue;
            DateTime ldtCurrentFiscalYearEnd = DateTime.MinValue;

            // Get current fiscal year range
            GetCurrentFisalYearRange(ref ldtCurrentFiscalYearStart, ref ldtCurrentFiscalYearEnd);

            return (adtGivenDate < ldtCurrentFiscalYearStart);
        }

        /// <summary>
        /// This method returns the current fiscal year Date Start & End
        /// </summary>
        /// <param name="adtFiscalYearStart">Fiscal Year Start</param>
        /// <param name="adtFiscalYearEnd">Fiscal Year End</param>
        public static void GetCurrentFisalYearRange(ref DateTime adtFiscalYearStart, ref DateTime adtFiscalYearEnd)
        {
            GetFiscalYearRangeForGivenDate(busGlobalFunction.ApplicationDateTime().Date, ref adtFiscalYearStart, ref adtFiscalYearEnd);
        }

        /// <summary>
        /// This method provides Fiscal Year Start & End for given year
        /// Considering Fiscal Year as upper fiscal year i.e. Fiscal year = 2005-2006. In this case passed fiscal year is 2006 & start date would be "1 July 2005".
        /// </summary>
        /// <param name="aintYear"></param>
        /// <param name="adtFiscalYearStart"></param>        
        public static void GetFiscalYearStartDateForGivenYear(int aintYear, ref DateTime adtFiscalYearStart)
        {
            DateTime ldtDate = new DateTime(aintYear - 1, busConstant.Misc.FISCAL_YEAR_START_MONTH, busConstant.Misc.FISCAL_YEAR_START_DATE);
            DateTime ldtFiscalYearEnd = DateTime.MinValue;
            GetFiscalYearRangeForGivenDate(ldtDate, ref adtFiscalYearStart, ref ldtFiscalYearEnd);
        }

        /// <summary>
        /// This method provides Fiscal Year Start & End for given year
        /// Considering Fiscal Year as upper fiscal year i.e. Fiscal year = 2005-2006. In this case passed fiscal year is 2006 & end date would be "30 June 2006".
        /// </summary>
        /// <param name="aintYear"></param>        
        /// <param name="adtFiscalYearEnd"></param>
        public static void GetFiscalYearEndDateForGivenYear(int aintYear, ref DateTime adtFiscalYearEnd)
        {
            DateTime ldtDate = new DateTime(aintYear - 1, busConstant.Misc.FISCAL_YEAR_START_MONTH, busConstant.Misc.FISCAL_YEAR_START_DATE);
            DateTime ldtFiscalYearStart = DateTime.MinValue;
            GetFiscalYearRangeForGivenDate(ldtDate, ref ldtFiscalYearStart, ref adtFiscalYearEnd);
        }

        /// <summary>
        /// This method provides Fiscal Year Start & End for given year
        /// </summary>
        /// <param name="aintYear"></param>
        /// <param name="adtFiscalYearStart"></param>
        /// <param name="adtFiscalYearEnd"></param>
        public static void GetFiscalYearRangeForGivenYear(int aintYear, ref DateTime adtFiscalYearStart, ref DateTime adtFiscalYearEnd)
        {
            DateTime ldtDate = new DateTime(aintYear, 1, 1);
            GetFiscalYearRangeForGivenDate(ldtDate, ref adtFiscalYearStart, ref adtFiscalYearEnd);
        }

        /// <summary>
        /// THis method provides Fiscal Year Start & End for given date
        /// </summary>
        /// <param name="adtGivenDate">Given Date</param>
        /// <param name="adtFiscalYearStart">Fiscal Year Start</param>
        /// <param name="adtFiscalYearEnd">Fiscal Year End</param>
        public static void GetFiscalYearRangeForGivenDate(DateTime adtGivenDate, ref DateTime adtFiscalYearStart, ref DateTime adtFiscalYearEnd)
        {
            // Throw Exception if GivenDate is MinValue of MaxValue
            if (adtGivenDate == DateTime.MinValue || adtGivenDate == DateTime.MaxValue)
                throw new Exception("Invalid Date. Please pass a valid date to determine fiscal year range.");

            // Get First Day of Fiscal Year
            if (adtGivenDate.Month > busConstant.Misc.FISCAL_YEAR_END_MONTH)
            {
                adtFiscalYearStart = new DateTime(adtGivenDate.Year, busConstant.Misc.FISCAL_YEAR_START_MONTH, busConstant.Misc.FISCAL_YEAR_START_DATE);
                adtFiscalYearEnd = new DateTime(adtGivenDate.Year + 1, busConstant.Misc.FISCAL_YEAR_END_MONTH, busConstant.Misc.FISCAL_YEAR_END_DATE);
            }
            else
            {
                adtFiscalYearStart = new DateTime(adtGivenDate.Year - 1, busConstant.Misc.FISCAL_YEAR_START_MONTH, busConstant.Misc.FISCAL_YEAR_START_DATE);
                adtFiscalYearEnd = new DateTime(adtGivenDate.Year, busConstant.Misc.FISCAL_YEAR_END_MONTH, busConstant.Misc.FISCAL_YEAR_END_DATE);
            }
        }

        /// <summary>
        /// Check if the given date is in a future fiscal year.
        /// </summary>
        /// <param name="adtGivenDate">Given Date</param>
        /// <returns>True if it is in the future; False if not.</returns>
        public static bool IsDateInFutureFiscalYear(DateTime adtGivenDate)
        {
            DateTime ldtCurrentFiscalYearStart = DateTime.MinValue;
            DateTime ldtCurrentFiscalYearEnd = DateTime.MinValue;

            // Get current fiscal year range
            GetCurrentFisalYearRange(ref ldtCurrentFiscalYearStart, ref ldtCurrentFiscalYearEnd);

            if (adtGivenDate > ldtCurrentFiscalYearEnd)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Fiscal Year for the DateTime, extension method
        /// </summary>
        /// <param name="adtGivenDate">this; DateTime</param>
        /// <returns>Fiscal Year</returns>
        public static int FiscalYear(this DateTime adtGivenDate)
        {
            if (adtGivenDate.Month > busConstant.Misc.FISCAL_YEAR_END_MONTH)
            {
                return (adtGivenDate.Year + 1);
            }
            else
            {
                return (adtGivenDate.Year);
            }
        }

        /// <summary>
        /// Returns the first date of the month of the given datetime value.
        /// </summary>
        /// <param name="adtDateTime">Datetime value.</param>
        /// <returns>First Day of the given datetime value.</returns>
        public static DateTime FirstDayOfMonthFromDateTime(DateTime adtDateTime)
        {
            return new DateTime(adtDateTime.Year, adtDateTime.Month, 1);
        }

        /// <summary>
        /// Returns the last daty of the month of the given datetime value.
        /// </summary>
        /// <param name="adtDateTime">Datetime value.</param>
        /// <returns>Last Day of the given datetime value.</returns>
        public static DateTime LastDayOfMonthFromDateTime(DateTime adtDateTime)
        {
            DateTime ldtFirstDayOfTheMonth = FirstDayOfMonthFromDateTime(adtDateTime);
            return ldtFirstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Toggle Flag
        /// </summary>
        /// <param name="astrFlag">Flag Value</param>
        /// <returns>Toggled Value</returns>
        public static string ToggleFlag(string astrFlag)
        {
            if (astrFlag == busConstant.Misc.FLAG_YES)
                return busConstant.Misc.FLAG_NO;
            else
                return busConstant.Misc.FLAG_YES;
        }

        /// <summary>
        /// Validate for strong password.        
        /// </summary>
        /// <param name="astrPassword"></param>
        /// <returns></returns>
        public static bool IsStrongPassword(string astrPassword)
        {
            //Changed the Regular Expression for Strong Password.
            //Changed for PIR 864.
            Regex lrexRegex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@'#.$;%^&+=!""()*,-/:<>?]).*$");
            return (lrexRegex.IsMatch(astrPassword));
        }

        /// <summary>
        /// Difference between two days
        /// </summary>
        /// <param name="aenmInterval">The interval.</param>
        /// <param name="adtFirstDate">First Date.</param>
        /// <param name="adtSecondDate">Second Date.</param>
        /// <returns>Difference</returns>
        public static int DateDiff(enmDateInterval aenmInterval, DateTime adtFirstDate, DateTime adtSecondDate)
        {
            int lintDifference = 0;

            bool lblnIsFirstDateGreater = adtFirstDate > adtSecondDate;
            DateTime ldtGreaterDate = lblnIsFirstDateGreater ? adtFirstDate : adtSecondDate;
            DateTime ldtLesserDate = lblnIsFirstDateGreater ? adtSecondDate : adtFirstDate;

            // Calculate difference
            switch (aenmInterval)
            {
                case enmDateInterval.Day:
                    lintDifference = (ldtGreaterDate - ldtLesserDate).Days;
                    break;
                case enmDateInterval.Month:
                    if ((ldtGreaterDate.Day - ldtLesserDate.Day) >= 0)
                    {
                        lintDifference = (ldtGreaterDate.Year - ldtLesserDate.Year) * busConstant.Misc.MONTHS_IN_YEAR + (ldtGreaterDate.Month - ldtLesserDate.Month) + 1;
                    }
                    else
                    {
                        lintDifference = (ldtGreaterDate.Year - ldtLesserDate.Year) * busConstant.Misc.MONTHS_IN_YEAR + (ldtGreaterDate.Month - ldtLesserDate.Month);
                    }
                    break;
                case enmDateInterval.Year:
                    TimeSpan ltsDifference = ldtGreaterDate - ldtLesserDate;
                    DateTime ldtDifferenceInDateTime = DateTime.MinValue.AddDays(ltsDifference.Days);
                    lintDifference = ldtDifferenceInDateTime.Year - 1;
                    break;
            }

            return lintDifference;
        }

        ///<summary>
        ///Returns the number of days for the month value.
        ///</summary>
        ///<param name="adtDate">Date.</param>
        public static int GetNoDaysForMonth(DateTime adtDate)
        {
            int lintMonth = adtDate.Month;
            int lintDaysInMonth = 0;

            switch (lintMonth)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    lintDaysInMonth = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    lintDaysInMonth = 30;
                    break;
                case 2:
                    lintDaysInMonth = DateTime.IsLeapYear(adtDate.Year) ? 29 : 28;
                    break;
            }

            return lintDaysInMonth;
        }

        /// <summary>
        /// Returns First date of calendar year
        /// </summary>
        /// <param name="aintYear"></param> 
        public static DateTime GetCalendarYearFirstDate(int aintYear)
        {
            return new DateTime(aintYear, 1, 1);
        }

        /// <summary>
        /// Returns Last date of calendar year
        /// </summary>
        /// <param name="aintYear"></param>
        /// <returns></returns>
        public static DateTime GetCalendarYearLastDate(int aintYear)
        {
            return new DateTime(aintYear, 12, 31);
        }

        /// <summary>
        /// To Calculate Exact Date Diffrence in Months and days
        /// </summary>
        /// <param name="adtDateValue1"></param>
        /// <param name="adtDateValue2"></param>
        /// <returns></returns>
        public static void DateDiffInMonthsAndDays(DateTime adtDateValue1, DateTime adtDateValue2, out int aintMonths, out int aintDays)
        {
            aintDays = 0;
            aintMonths = 0;
            DateTime adteStartDate, adteEndDate;

            if (adtDateValue1 > adtDateValue2)
            {
                adteEndDate = adtDateValue1;
                adteStartDate = adtDateValue2;
            }
            else if (adtDateValue1 < adtDateValue2)
            {
                adteEndDate = adtDateValue2;
                adteStartDate = adtDateValue1;
            }
            else
            {
                adteEndDate = DateTime.MinValue;
                adteStartDate = DateTime.MinValue;
            }


            int iintStartDay = adteStartDate.Day;
            aintMonths = 0;
            while (true)
            {
                if (adteStartDate.Day < iintStartDay)
                {
                    if (DateTime.DaysInMonth(adteStartDate.Year, adteStartDate.Month) < iintStartDay)
                    {
                        adteStartDate = new DateTime(adteStartDate.Year, adteStartDate.Month, DateTime.DaysInMonth(adteStartDate.Year, adteStartDate.Month));
                    }
                    else if (DateTime.DaysInMonth(adteStartDate.Year, adteStartDate.Month) > iintStartDay)
                    {
                        adteStartDate = new DateTime(adteStartDate.Year, adteStartDate.Month, iintStartDay);
                    }
                }

                if ((adteStartDate = adteStartDate.AddMonths(1)) <= adteEndDate)
                {
                    aintMonths++;
                }

                else
                {
                    adteStartDate = adteStartDate.AddMonths(-1);
                    break;
                }
            }
            aintDays = (adteEndDate - adteStartDate).Days;
        }

        public static void CreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void FileCopy(string sourceFileName, string destFileName, bool overwrite = busConstant.Misc.FALSE)
        {
            try
            {
                File.Copy(sourceFileName, destFileName, overwrite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void FileDelete(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void FileMove(string sourceFileName, string destFileName, bool overwrite = busConstant.Misc.FALSE)
        {
            try
            {
                FileCopy(sourceFileName, destFileName, overwrite);
                FileDelete(sourceFileName);
            }
            catch
            {
                throw;
            }


        }

        public static Int64 GetRandomInteger(int count = 1)
        {
            string digits = string.Empty;

            for (int i = 0; i < count; i++)
            {
                start:
                Random randm = new Random();
                var x = randm.Next(0, 9).ToString();
                if (digits.IsNullOrEmpty())
                {
                    digits = x;
                }
                else if (digits.IsNotNullOrEmpty() && !digits.Contains(x))
                {
                    digits += x;
                }
                else
                {
                    goto start;
                }

            }
            return Convert.ToInt64(digits);
        }


        public static Int64 GetRandomNumber()
        {
            List<int> keys = new List<int>();

            Random ran = new Random(DateTime.Now.Millisecond);

            int key = 0;
            do
            {
                key = ran.Next(1000000000, int.MaxValue);

            } while (keys.Contains(key));

            keys.Add(key);
            return key;

        }


        static Random random = new Random();
        // Note, max is exclusive here!
        public static List<int> GenerateRandom(int count, int min, int max)
        {
           
            //  initialize set S to empty
            //  for J := N-M + 1 to N do
            //    T := RandInt(1, J)
            //    if T is not in S then
            //      insert T in S
            //    else
            //      insert J in S
            //
            // adapted for C# which does not have an inclusive Next(..)
            // and to make it from configurable range not just 1.

            if (max <= min || count < 0 ||
                    // max - min > 0 required to avoid overflow
                    (count > max - min && max - min > 0))
            {
                // need to use 64-bit to support big ranges (negative min, positive max)
                throw new ArgumentOutOfRangeException("Range " + min + " to " + max +
                        " (" + ((Int64)max - (Int64)min) + " values), or count " + count + " is illegal");
            }

            // generate count random values.
            HashSet<int> candidates = new HashSet<int>();

            // start count values before max, and end at max
            for (int top = max - count; top < max; top++)
            {
                // May strike a duplicate.
                // Need to add +1 to make inclusive generator
                // +1 is safe even for MaxVal max value because top < max
                if (!candidates.Add(random.Next(min, top + 1)))
                {
                    // collision, add inclusive max.
                    // which could not possibly have been added before.
                    candidates.Add(top);
                }
            }

            // load them in to a list, to sort
            List<int> result = candidates.ToList();

            // shuffle the results because HashSet has messed
            // with the order, and the algorithm does not produce
            // random-ordered results (e.g. max-1 will never be the first value)
            for (int i = result.Count - 1; i > 0; i--)
            {
                int k = random.Next(i + 1);
                int tmp = result[k];
                result[k] = result[i];
                result[i] = tmp;
            }
            return result;
        }

        public static List<int> GenerateRandom(int count)
        {
            return GenerateRandom(count, 0, Int32.MaxValue);
        }

        #endregion Common Methods

        #region Extension Method



        public static bool CaseInsensitiveContains(this string text, string value, StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            if (text.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                return text.IndexOf(value, stringComparison) >= 0;
            }

        }


        /// <summary>
        /// Determines whether the string is not null or empty.
        /// </summary>
        /// <returns>Boolean indicating whether the string is not null or not empty</returns>
        public static bool IsNotNullOrEmpty(this string astrText)
        {
            return !String.IsNullOrEmpty(astrText);
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }


        /// <summary>
        /// To Remove Html Tags from string.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveHtml(this string source)
        {
            return Regex.Replace(source, "<.*?>|&.*?;", string.Empty);
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> data, string tableName)
        {
            DataTable table = new DataTable(tableName);

            //special handling for value types and string
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {

                DataColumn dc = new DataColumn("Value");
                table.Columns.Add(dc);
                foreach (T item in data)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item;
                    table.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name,
                    Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        try
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch (Exception ex)
                        {
                            row[prop.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        public static DataTable ToDataTable<T>(this Collection<T> data, string tableName)
        {
            DataTable table = new DataTable(tableName);

            //special handling for value types and string
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {

                DataColumn dc = new DataColumn("Value");
                table.Columns.Add(dc);
                foreach (T item in data)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item;
                    table.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name,
                    Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        try
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch (Exception ex)
                        {
                            row[prop.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> GetSlices<T>(this IEnumerable<T> source, int n)
        {
            IEnumerable<T> it = source;
            T[] slice = it.Take(n).ToArray();
            it = it.Skip(n);
            while (slice.Length != 0)
            {
                yield return slice;
                slice = it.Take(n).ToArray();
                it = it.Skip(n);
            }
        }

        /// <summary>
        /// Adding Collection To Other Collection Of Same type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oc"></param>
        /// <param name="collection"></param>
        public static void AddRange<T>(this Collection<T> oc, Collection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (var item in collection)
            {
                oc.Add(item);
            }
        }
        /// <summary>
        /// Formats a string with a list of literal placeholders.
        /// </summary>
        /// <param name="astrText">The extension text</param>
        /// <param name="aarrArgs">The argument list</param>
        /// <returns>The formatted string</returns>
        public static string Format(this string astrText, params object[] aarrArgs)
        {
            return string.Format(astrText, aarrArgs);
        }

        /// <summary>
        /// Determines whether a substring exists within a string.
        /// </summary>
        /// <param name="astrText">String to search.</param>
        /// <param name="astrSubString">Substring to match when searching.</param>
        /// <param name="ablnCaseSensitive">Determines whether or not to ignore case.</param>
        /// <returns>Indicator of substring presence within the string.</returns>
        public static bool Contains(this string astrText, string astrSubString, bool ablnCaseSensitive)
        {
            if (ablnCaseSensitive)
            {
                return astrText.Contains(astrSubString);
            }
            else
            {
                return astrText.ToLower().IndexOf(astrSubString.ToLower(), 0) >= 0;
            }
        }

        /// <summary>
        /// Detects if a string can be parsed to a valid date.
        /// </summary>
        /// <param name="astrText">Value to inspect.</param>
        /// <returns>Whether or not the string is formatted as a date.</returns>
        public static bool IsDate(this string astrText)
        {
            try
            {
                System.DateTime dtDateTime = System.DateTime.Parse(astrText);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Function checks whether the given date is valid as per the specified format.
        /// </summary>
        /// <param name="adtDateString">Date to be validated</param>
        /// <param name="format">Date format</param>
        /// <returns></returns>
        public static bool IsValidDate(this string adtDateString, string format)
        {
            DateTime ldtDateString;
            return DateTime.TryParseExact(adtDateString, format, new CultureInfo("en-US"), DateTimeStyles.None, out ldtDateString)
                   && ldtDateString != DateTime.MinValue && ldtDateString != DateTime.MaxValue;
        }

        public static bool IsDefault(this DateTime adtGivenDate)
        {
            if (adtGivenDate.Equals(default(DateTime)))
            {
                return true;
            }
            return false;
        }


        public static void RemoveRange<T>(this Collection<T> list, IEnumerable aList)
        {
            if (!aList.IsNullOrEmpty())
            {
                foreach (T obj in aList)
                {
                    list.Remove(obj);
                }
            }
        }

        /// <summary>
        /// Determines whether the specified string is null or empty.
        /// </summary>
        /// <param name="astrText">The string value to check.</param>
        /// <returns>Boolean indicating whether the string is null or empty.</returns>
        public static bool IsEmpty(this string astrText)
        {
            return (astrText == null) || (astrText.Length == 0);
        }

        /// <summary>
        /// Determines whether the specified string is not null or empty.
        /// </summary>
        /// <param name="astrText">The string value to check.</param>
        /// <returns>Boolean indicating whether the string is not empty</returns>
        public static bool IsNotEmpty(this string astrText)
        {
            return (!astrText.IsEmpty());
        }

        /// <summary>
        /// Checks whether the string is null and returns a default value in case.
        /// </summary>
        /// <param name="astrDefaultValue">The default value.</param>
        /// <returns>Either the string or the default value.</returns>
        public static string IfNull(this string astrText, string astrDefaultValue)
        {
            return (astrText.IsNull() ? astrText : astrDefaultValue);
        }

        /// <summary>
        /// Determines whether the string is empty and returns a default value in case.
        /// </summary>
        /// <param name="astrDefaultValue">The default value.</param>
        /// <returns>Either the string or the default value.</returns>
        public static string IfEmpty(this string astrText, string astrDefaultValue)
        {
            return (astrText.IsNotEmpty() ? astrText : astrDefaultValue);
        }

        /// <summary>
        /// Determines whether the specified object is null
        /// </summary>
        /// <returns>Boolean indicating whether the object is null</returns>
        public static bool IsNull(this object aobjObject)
        {
            return object.ReferenceEquals(aobjObject, null);
        }

        /// <summary>
        /// Determines whether the specified object is not null
        /// </summary>
        /// <returns>Boolean indicating whether the object is not null</returns>
        public static bool IsNotNull(this object aobjObject)
        {
            return !object.ReferenceEquals(aobjObject, null);
        }


        /// <summary>
        /// Creates a type from the given name
        /// </summary>
        /// <typeparam name="T">The type being created</typeparam>      
        /// <param name="aarrArgs">Arguments to pass into the constructor</param>
        /// <returns>An instance of the type</returns>
        public static T CreateType<T>(this string astrTypeName, params object[] aarrArgs)
        {
            Type ltypType = Type.GetType(astrTypeName, true, true);
            return (T)Activator.CreateInstance(ltypType, aarrArgs);
        }

        /// <summary>
        /// Determines if a string can be converted to an integer.
        /// </summary>
        /// <returns>True if the string is numeric.</returns>
        public static bool IsNumeric(this string astrText)
        {
            System.Text.RegularExpressions.Regex regularExpression = new System.Text.RegularExpressions.Regex("^-[0-9]+$|^[0-9]+$");
            return regularExpression.Match(astrText).Success;
        }

        public static bool IsLenghtGreaterThanInt32(this string astrText)
        {
            try
            {
                Convert.ToInt32(astrText);
            }
            catch (OverflowException ex)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check whether the e-mail is having valid 
        /// </summary>
        /// <param name="astrEmail"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string astrEmail)
        {
            Regex lrexEmail = new Regex(@"(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})");
            return (lrexEmail.IsMatch(astrEmail));
        }

        /// <summary>
        /// Detects whether this instance is a valid email address.
        /// </summary>
        /// <returns>True if instance is valid email address</returns>
        public static bool IsValidEmailAddress(this string astrText)
        {
            return IsValidEmail(astrText);
        }

        /// <summary>
        /// Detects whether the supplied string is a valid IP address.
        /// </summary>
        /// <returns>True if the string is valid IP address.</returns>
        public static bool IsValidIPAddress(this string astrText)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(astrText, @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
        }

        /// <summary>
        /// Checks if url is valid.
        /// </summary>
        /// <returns>True if the url is valid.</returns>
        public static bool IsValidUrl(this string astrURL)
        {
            string lstrRegex = "^(https?://)"
                + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" // user@
                + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
                + "|" // allows either IP or domain
                + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
                + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]" // second level domain
                + @"(\.[a-z]{2,6})?)" // first level domain- .com or .museum is optional
                + "(:[0-9]{1,5})?" // port number- :80
                + "((/?)|" // a slash isn't required if there is no file name
                + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";

            return new System.Text.RegularExpressions.Regex(lstrRegex).IsMatch(astrURL);
        }

        /// <summary>
        /// Retrieves the left x characters of a string.
        /// </summary>
        /// <param name="aintCount">The number of characters to retrieve.</param>
        /// <returns>The resulting substring.</returns>
        public static string Left(this string astrText, int aintCount)
        {
            return astrText.Substring(0, aintCount);
        }

        /// <summary>
        /// Retrieves the right x characters of a string.
        /// </summary>
        /// <param name="aintCount">The number of characters to retrieve.</param>
        /// <returns>The resulting substring.</returns>
        public static string Right(this string astrText, int aintCount)
        {
            return astrText.Substring(astrText.Length - aintCount, aintCount);
        }

        /// <summary>
        /// Capitalizes the first letter of a string
        /// </summary>      
        public static string Capitalize(this string astrText)
        {
            if (astrText.Length == 0)
            {
                return astrText;
            }
            if (astrText.Length == 1)
            {
                return astrText.ToUpper(System.Globalization.CultureInfo.InvariantCulture);
            }
            return astrText.Substring(0, 1).ToUpper(System.Globalization.CultureInfo.InvariantCulture) + astrText.Substring(1);
        }

        /// <summary>
        /// Uses regular expressions to determine if the string matches to a given regex pattern.
        /// </summary>
        /// <param name="astrRegexPattern">The regular expression pattern.</param>
        /// <returns>
        /// 	<c>true</c> if the value is matching to the specified pattern; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code>
        /// var s = "12345";
        /// var isMatching = s.IsMatchingTo(@"^\d+$");
        /// </code>
        /// </example>
        public static bool IsMatchingTo(this string astrText, string astrRegexPattern)
        {
            return IsMatchingTo(astrText, astrRegexPattern, System.Text.RegularExpressions.RegexOptions.None);
        }

        public static bool AnyOfThis(this string astrText, params string[] larrayString)
        {
            foreach (var item in larrayString)
            {
                if (item.ToUpper().Equals(astrText.ToUpper()))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool NoneOfThis(this string astrText, params string[] larrayString)
        {
            foreach (var item in larrayString)
            {
                if (item.ToUpper().Equals(astrText.ToUpper()))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AnyOfThis(this int aintValue, params int[] larrayint)
        {
            foreach (var item in larrayint)
            {
                if (item == aintValue)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool NoneOfThis(this int aintValue, params int[] larrayint)
        {
            foreach (var item in larrayint)
            {
                if (item == aintValue)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Uses regular expressions to determine if the string matches to a given regex pattern.
        /// </summary>
        /// <param name="astrRegexPattern">The regular expression pattern.</param>
        /// <param name="options">The regular expression options.</param>
        /// <returns>
        /// 	<c>true</c> if the value is matching to the specified pattern; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code>
        /// var s = "12345";
        /// var isMatching = s.IsMatchingTo(@"^\d+$");
        /// </code>
        /// </example>
        public static bool IsMatchingTo(this string astrText, string astrRegexPattern, System.Text.RegularExpressions.RegexOptions options)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(astrText, astrRegexPattern, options);
        }

        /// <summary>
        /// Uses regular expressions to replace parts of a string.
        /// </summary>
        /// <param name="astrRegexPattern">The regular expression pattern.</param>
        /// <param name="astrReplaceValue">The replacement value.</param>
        /// <returns>The newly created string</returns>
        /// <example>
        /// <code>
        /// var s = "12345";
        /// var replaced = s.ReplaceWith(@"\d", m => string.Concat(" -", m.Value, "- "));
        /// </code>
        /// </example>
        public static string ReplaceWith(this string astrValue, string astrRegexPattern, string astrReplaceValue)
        {
            return ReplaceWith(astrValue, astrRegexPattern, astrReplaceValue, System.Text.RegularExpressions.RegexOptions.None);
        }

        /// <summary>
        /// Uses regular expressions to replace parts of a string.
        /// </summary>
        /// <param name="astrRegexPattern">The regular expression pattern.</param>
        /// <param name="astrReplaceValue">The replacement value.</param>
        /// <param name="options">The regular expression options.</param>
        /// <returns>The newly created string</returns>
        /// <example>
        /// <code>
        /// var s = "12345";
        /// var replaced = s.ReplaceWith(@"\d", m => string.Concat(" -", m.Value, "- "));
        /// </code>
        /// </example>
        public static string ReplaceWith(this string astrText, string astrRegexPattern, string astrReplaceValue, System.Text.RegularExpressions.RegexOptions options)
        {
            return System.Text.RegularExpressions.Regex.Replace(astrText, astrRegexPattern, astrReplaceValue, options);
        }

        /// <summary>
        /// A case insenstive replace function.
        /// </summary>
        /// <param name="astrText">The string to examine.</param>
        /// <param name="astrOldString">The new value to be inserted.</param>
        /// <param name="astrNewString">The value to replace.</param>
        /// <param name="ablnCaseSensitive">Determines whether or not to ignore case.</param>
        /// <returns>The resulting string.</returns>
        public static string Replace(this string astrText, string astrOldString, string astrNewString, bool ablnCaseSensitive)
        {
            if (ablnCaseSensitive)
            {
                return astrText.Replace(astrOldString, astrNewString);
            }
            else
            {
                System.Text.RegularExpressions.Regex aRegex = new System.Text.RegularExpressions.Regex(astrOldString, System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Multiline);

                return aRegex.Replace(astrText, astrNewString);
            }
        }

        /// <summary>
        /// Reverses a string.
        /// </summary>
        /// <param name="astrText">The string to reverse.</param>
        /// <returns>The resulting string.</returns>
        public static string Reverse(this string astrText)
        {
            char[] larrChar = astrText.ToCharArray();
            Array.Reverse(larrChar);
            return new string(larrChar);
        }

        /// <summary>
        /// Splits a string into an array by delimiter.
        /// </summary>
        /// <param name="astrText">String to split.</param>
        /// <param name="astrDelimiter">Delimiter string.</param>
        /// <returns>Array of strings.</returns>
        public static string[] Split(this string astrText, string astrDelimiter)
        {
            return astrText.Split(astrDelimiter.ToCharArray());
        }

        /// <summary>
        /// Wraps the passed string up the total number of characters until the next whitespace on or after 
        /// the total character count has been reached for that line.  
        /// Uses the environment new line symbol for the break text.
        /// </summary>
        /// <param name="astrText">The string to wrap.</param>
        /// <param name="aintCount">The number of characters per line.</param>
        /// <returns>The resulting string.</returns>
        public static string WordWrap(this string astrText, int aintCount)
        {
            return WordWrap(astrText, aintCount, false, Environment.NewLine);
        }

        /// <summary>
        /// Wraps the passed string up the total number of characters (if cutOff is true)
        /// or until the next whitespace (if cutOff is false).  Uses the environment new line
        /// symbol for the break text.
        /// </summary>
        /// <param name="astrText">The string to wrap.</param>
        /// <param name="aintCount">The number of characters per line.</param>
        /// <param name="ablnCutOff">If true, will break in the middle of a word.</param>
        /// <returns>The resulting string.</returns>
        public static string WordWrap(this string astrText, int aintCount, bool ablnCutOff)
        {
            return WordWrap(astrText, aintCount, ablnCutOff, Environment.NewLine);
        }

        /// <summary>
        /// Wraps the passed string up the total number of characters (if cutOff is true)
        /// or until the next whitespace (if cutOff is false).  Uses the supplied breakText
        /// for line breaks.
        /// </summary>
        /// <param name="astrText">The string to wrap.</param>
        /// <param name="aintCount">The number of characters per line.</param>
        /// <param name="ablnCutOff">If true, will break in the middle of a word.</param>
        /// <param name="astrBreakText">The line break text to use.</param>
        /// <returns>The resulting string</returns>
        public static string WordWrap(this string astrText, int aintCount, bool ablnCutOff, string astrBreakText)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(astrText.Length + 100);
            int lintCounter = 0;

            if (ablnCutOff)
            {
                while (lintCounter < astrText.Length)
                {
                    if (astrText.Length > lintCounter + aintCount)
                    {
                        sb.Append(astrText.Substring(lintCounter, aintCount));
                        sb.Append(astrBreakText);
                    }
                    else
                    {
                        sb.Append(astrText.Substring(lintCounter));
                    }

                    lintCounter += aintCount;
                }
            }
            else
            {
                string[] larrStrings = astrText.Split(' ');

                for (int lintIndex = 0; lintIndex < larrStrings.Length; lintIndex++)
                {
                    lintCounter += larrStrings[lintIndex].Length + 1; // the added one is to represent the inclusion of the space.

                    if (lintIndex != 0 && lintCounter > aintCount)
                    {
                        sb.Append(astrBreakText);
                        lintCounter = 0;
                    }

                    sb.Append(larrStrings[lintIndex] + ' ');
                }
            }

            return sb.ToString().TrimEnd(); // to get rid of the extra space at the end.
        }

        /// <summary>
        /// Converts String to Any Other Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="astrText">The input.</param>
        /// <returns>Return converted type</returns>
        public static T? ConvertTo<T>(this string astrText) where T : struct
        {
            T? ret = null;

            if (!string.IsNullOrEmpty(astrText))
            {
                ret = (T)Convert.ChangeType(astrText, typeof(T));
            }

            return ret;
        }

        /// <summary>
        /// Converts String to Any Other Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="astrText">The input.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static T? ConvertTo<T>(this string astrText, IFormatProvider provider) where T : struct
        {
            T? ret = null;

            if (!string.IsNullOrEmpty(astrText))
            {
                ret = (T)Convert.ChangeType(astrText, typeof(T), provider);

            }

            return ret;
        }

        /// <summary>
        /// Returns string converted from char.
        /// </summary>
        /// <param name="achrText"></param>
        /// <returns>Return string</returns>
        public static string ToString(this char? achrText)
        {
            return achrText.HasValue ? achrText.Value.ToString() : String.Empty;
        }

        /// <summary>
        /// Returns a Boolean value indicating whether a variable is of the indicated type.
        /// </summary>
        /// <param name="aobjObject">Object instance.</param>
        /// <param name="atypType">The Type to check the object against.</param>
        /// <returns>Result of the comparison.</returns>
        public static bool IsType(this object aobjObject, Type atypType)
        {
            return aobjObject.GetType().Equals(atypType);
        }

        /// <summary>
        /// Creates an instance of the generic type specified using the default constructor.
        /// </summary>
        /// <typeparam name="T">The type to instantiate.</typeparam>
        /// <param name="atypType">The System.Type being instantiated.</param>
        /// <returns>An instance of the specified type.</returns>
        /// <example>
        /// typeof(MyObject).CreateInstance();
        /// </example>
        public static T CreateInstance<T>(this System.Type atypType) where T : new()
        {
            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Determines whether an expression evaluates to the DBNull class.
        /// </summary>
        /// <param name="aobjObject">Object instance.</param>
        /// <returns>Returns true if the object is DBNull.</returns>
        public static bool IsDBNull(this object aobjObject)
        {
            return aobjObject.IsType(typeof(DBNull));
        }

        /// <summary>
        /// Rounds the supplied decimal to the specified amount of decimal points.
        /// </summary>
        /// <param name="adecValue">The decimal to round.</param>
        /// <param name="aintDecimalPoints">The number of decimal points to round the output value to.</param>
        /// <returns>A rounded decimal.</returns>
        public static decimal RoundDecimalPoints(this decimal adecValue, int aintDecimalPoints)
        {
            return Math.Round(adecValue, aintDecimalPoints, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Rounds the supplied decimal value to two decimal points.
        /// </summary>
        /// <param name="adecValue">The decimal to round.</param>
        /// <returns>A decimal value rounded to two decimal points.</returns>
        public static decimal RoundToTwoDecimalPoints(this decimal adecValue)
        {
            return Math.Round(adecValue, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Rounds the supplied decimal value to four decimal points.
        /// </summary>
        /// <param name="adecValue">The decimal to round.</param>
        /// <returns>A decimal value rounded to four decimal points.</returns>
        public static decimal RoundToFourDecimalPoints(this decimal adecValue)
        {
            return Math.Round(adecValue, 4, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Rounds the supplied decimal value to six decimal points.
        /// </summary>
        /// <param name="adecValue">The decimal to round.</param>
        /// <returns>A decimal value rounded to six decimal points.</returns>
        public static decimal RoundToSixDecimalPoints(this decimal adecValue)
        {
            return Math.Round(adecValue, 6, MidpointRounding.AwayFromZero);
        }


        /// <summary>
        /// Determine whether the collection/list is null or empty;
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Returns true if the list is null or empty.</returns>
        public static bool IsNullOrEmpty(this System.Collections.IEnumerable list)
        {
            return list == null ? true : list.GetEnumerator().MoveNext() == false;
        }

        /// <summary>
        /// Determine whether the collection/list is empty
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Returns true if the list is empty.</returns>
        public static bool IsEmpty(this System.Collections.IEnumerable list)
        {
            return list == null ? true : list.GetEnumerator().MoveNext() == false;
        }

        /// <summary>
        /// Checks a System.Type to see if it implements a given interface.
        /// </summary>
        /// <param name="source">The System.Type to check.</param>
        /// <param name="iface">The System.Type interface to check for.</param>
        /// <returns>True if the source implements the interface type, false otherwise.</returns>
        public static bool IsImplementationOf(this Type atypSource, Type atypInterfaceType)
        {
            if (atypSource == null)
                throw new ArgumentNullException("source");

            return atypSource.GetInterface(atypInterfaceType.FullName) != null;
        }

        /// <summary>
        /// Get age in Years for the given birth date
        /// </summary>
        /// <param name="adtDateOfBirth">Date of Birth</param>
        /// <returns>Age In Years</returns>
        public static int AgeInYears(this DateTime adtDateOfBirth)
        {
            return adtDateOfBirth.AgeInYearsAsOfDate(busGlobalFunction.ApplicationDateTime().Date);
        }

        /// <summary>
        /// Get age in Years for the given birth date
        /// </summary>
        /// <param name="adtDateOfBirth">Date of Birth</param>
        /// <param name="adtAsOfDate">As of Date</param>
        /// <returns>Age in Years</returns>
        public static int AgeInYearsAsOfDate(this DateTime adtDateOfBirth, DateTime adtAsOfDate)
        {
            // find the difference in days, months and years
            int lintNoOfDays = adtAsOfDate.Day - adtDateOfBirth.Day;
            int lintNoOfMonths = adtAsOfDate.Month - adtDateOfBirth.Month;
            int lintNoOfYears = adtAsOfDate.Year - adtDateOfBirth.Year;

            if (lintNoOfDays < 0)
            {
                lintNoOfDays += DateTime.DaysInMonth(adtAsOfDate.Year, adtAsOfDate.Month);
                lintNoOfMonths--;
            }

            if (lintNoOfMonths < 0)
            {
                lintNoOfMonths += 12;
                lintNoOfYears--;
            }

            return lintNoOfYears;
        }

        /// <summary>
        /// Checksum validation for the Bank Routing Number.
        /// </summary>
        /// <param name="iargRoutingNo">Routing Number</param>
        /// <returns>TRUE - If valid, FALSE - if Invalid</returns>
        public static bool IsValidCheckSum(string astrRoutingNo)
        {
            // If there is no CheckSum Entered, No Need to validate. Dont throw any error.
            if (astrRoutingNo.IsNull())
                return true;

            string lstrRoutingNo = astrRoutingNo;
            // If the length of the routing number is not 9
            if (lstrRoutingNo.Trim().Length != 9)
                return false;

            //Leading and trailing whitespaces in the string trimmed
            lstrRoutingNo = lstrRoutingNo.Trim();

            // If characters are entered.
            int lintRoutingNumber;
            if (int.TryParse(lstrRoutingNo, out lintRoutingNumber) == false)
                return false;

            int[] larrWeight = new int[] { 3, 7, 1, 3, 7, 1, 3, 7 };
            int lintSum = 0;
            int lintTemp = 0;

            for (int lintCount = 0; lintCount < 8; lintCount++)
            {
                lintTemp = Convert.ToInt16(lstrRoutingNo.Substring(lintCount, 1)) * larrWeight[lintCount];
                lintSum += lintTemp;
            }

            int lintChecksumDigit = lintSum % 10;               // Identify the Last Digit

            int lintCompareDigit = 10 - lintChecksumDigit;      // Subtract by 10

            if (lintCompareDigit == 10)                         // Checksum is 0, Make the Compare digit to 0, instead of 10, Because 10 will always return false.
                lintCompareDigit = 0;

            if (Convert.ToInt16(lstrRoutingNo.Substring(8, 1)) == lintCompareDigit) // The value should be the Last digit of the Routing Number
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns the date difference between two date values in months.
        /// </summary>
        /// <param name="adtDateValue1">Date value to compare.</param>
        /// <param name="adtDateValue2">Date value to compare.</param>
        /// <returns>Date difference in months.</returns>
        public static int DateDiffInMonths(DateTime adtDateValue1, DateTime adtDateValue2)
        {
            DateTime ldtLowestDate, ldtHighestDate;

            if (adtDateValue1 > adtDateValue2)
            {
                ldtHighestDate = adtDateValue1;
                ldtLowestDate = adtDateValue2;
            }
            else if (adtDateValue1 < adtDateValue2)
            {
                ldtHighestDate = adtDateValue2;
                ldtLowestDate = adtDateValue1;
            }
            else
            {
                return 0;
            }

            int lintMonths = 0;

            while (ldtLowestDate < ldtHighestDate)
            {
                lintMonths++;
                ldtLowestDate = ldtLowestDate.AddMonths(1);

                if (ldtLowestDate > ldtHighestDate)
                {
                    lintMonths--;
                }
            }

            return Math.Abs(lintMonths);
        }

        /// <summary>
        /// Returns Formatted SSN.
        /// </summary>
        /// <param name="astrSSN">SSN</param>
        /// <returns></returns>
        public static string GetFormattedSSN(string astrSSN)
        {
            string lstrFormattedSSN = String.Empty;

            if (astrSSN.IsNotNullOrEmpty() && astrSSN.Length >= 9)
            {
                lstrFormattedSSN = string.Join("-", astrSSN.Substring(0, 3), astrSSN.Substring(3, 2), astrSSN.Substring(5, 4));
            }
            return lstrFormattedSSN;
        }
        /// <summary>
        /// Returns the Round Up Month Difference 
        /// </summary>
        /// <param name="lValue"></param>
        /// <param name="rValue"></param>
        /// <returns></returns>
        public static int MonthDifferenceRoundedUp(this DateTime adtFromDate, DateTime adtToDate)
        {
            return Convert.ToInt32(Math.Round(DateDiff(enmDateInterval.Day, adtToDate, adtFromDate) / (365.25 / 12), 0));
            // return Math.Abs((adtFromDate.Month - adtToDate.Month) + 12 * (adtFromDate.Year - adtToDate.Year));
        }

        /// <summary>
        /// Method to Trim the end of string with String Parameter.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="trimChars"></param>
        /// <returns></returns>
        public static string TrimEnd(this string target, string trimChars)
        {
            return target.TrimEnd(trimChars.ToCharArray());
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection) action(item);
            return collection;
        }

        //public static string GetSortExpression(this GridParams param, string override_defaultColumn = "")
        //{
        //    var defaultSort = override_defaultColumn.IsNullOrEmpty() ? param.Key : override_defaultColumn;
        //    var sortExpression = param.SortNames.IsNullOrEmpty() ? String.Concat(defaultSort, " desc") : String.Concat(param.SortNames[0], " ", param.SortDirections[0]);
        //    return (sortExpression.IsNotNullOrEmpty() && sortExpression.Contains(" asc")) ? sortExpression.Replace(" asc", "") : sortExpression;
        //}

        //public static int GetPage(this GridParams param)
        //{
        //    return param.Page == busConstant.Numbers.Integer.ZERO ? busConstant.Numbers.Integer.ZERO : param.Page - busConstant.Numbers.Integer.One;
        //}

        //public static int GetPageSize(this GridParams param)
        //{
        //    return param.PageSize.GetValueOrDefault() == busConstant.Numbers.Integer.ZERO ? busConstant.Numbers.Integer.Ten : param.PageSize.GetValueOrDefault();
        //}

        //Add New Extention Methode Here

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                // Setting Column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    // Inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            // Put breakpoint here and check datatable
            return dataTable;
        }

        public static string Crypt(this string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public static string Decrypt(this string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }

        public static object ToType<T>(this object obj, T type)
        {

            //create instance of T type object:
            var tmp = Activator.CreateInstance(Type.GetType(type.ToString()));

            //loop through the properties of the object you want to covert:          
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                try
                {

                    //get the value of property and try 
                    //to assign it to the property of T type object:
                    tmp.GetType().GetProperty(pi.Name).SetValue(tmp, pi.GetValue(obj, null), null);
                }
                catch { }
            }

            //return the T type object:         
            return tmp;
        }

        public static object ToNonAnonymousList<T>(this List<T> list, Type t)
        {

            //define system Type representing List of objects of T type:
            var genericType = typeof(List<>).MakeGenericType(t);

            //create an object instance of defined type:
            var l = Activator.CreateInstance(genericType);

            //get method Add from from the list:
            MethodInfo addMethod = l.GetType().GetMethod("Add");

            //loop through the calling list:
            foreach (T item in list)
            {

                //convert each object of the list into T object 
                //by calling extension ToType<T>()
                //Add this object to newly created list:
                addMethod.Invoke(l, new object[] { item.ToType(t) });
            }

            //return List of T objects:
            return l;
        }

        #endregion Extension Method


    }

    public static class busHoliday
    {
        public static bool IsDateAWeekWorkDay(DateTime adtDateFrom)
        {
            var lblnIsDateAWeekWorkDay = false;

            switch (adtDateFrom.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    lblnIsDateAWeekWorkDay = false;
                    break;
                case DayOfWeek.Monday:
                    lblnIsDateAWeekWorkDay = true;
                    break;
                case DayOfWeek.Tuesday:
                    lblnIsDateAWeekWorkDay = true;
                    break;
                case DayOfWeek.Wednesday:
                    lblnIsDateAWeekWorkDay = true;
                    break;
                case DayOfWeek.Thursday:
                    lblnIsDateAWeekWorkDay = true;
                    break;
                case DayOfWeek.Friday:
                    lblnIsDateAWeekWorkDay = true;
                    break;
                case DayOfWeek.Saturday:
                    lblnIsDateAWeekWorkDay = false;
                    break;
                default:
                    lblnIsDateAWeekWorkDay = false;
                    break;
            }
            //ToDo Add Compare date with Declared Holidays in DataBase.

            return lblnIsDateAWeekWorkDay;
        }

        public static bool IsWeekend(DateTime adtDate)
        {
            var lblnIsWeekend = false;

            switch (adtDate.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    lblnIsWeekend = true;
                    break;
                case DayOfWeek.Monday:
                    lblnIsWeekend = false;
                    break;
                case DayOfWeek.Tuesday:
                    lblnIsWeekend = false;
                    break;
                case DayOfWeek.Wednesday:
                    lblnIsWeekend = false;
                    break;
                case DayOfWeek.Thursday:
                    lblnIsWeekend = false;
                    break;
                case DayOfWeek.Friday:
                    lblnIsWeekend = false;
                    break;
                case DayOfWeek.Saturday:
                    lblnIsWeekend = true;
                    break;
                default:
                    lblnIsWeekend = false;
                    break;
            }

            return lblnIsWeekend;
        }

        public static bool IsHoliday(DateTime adtDate)
        {
            var lblnIsHoliday = false;

            return lblnIsHoliday;
        }

        public static int GetNoOfWorkingDays(DateTime adtStartDate, DateTime adtEndDate)
        {
            var lintNoOfWorkingDays = busConstant.Numbers.Integer.ZERO;

            return lintNoOfWorkingDays;
        }
    }

    public enum enmAppendCharacter
    {
        Comma,
        CommaSpace,
        Space,
        FullStopSpace,
        Newline,
        Dash,
        QuestionSpace,
        ExclamationSpace,
        None
    }

    public enum enmDateInterval
    {
        Day,
        Month,
        Year
    }


}
