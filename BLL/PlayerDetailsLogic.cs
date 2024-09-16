using BLL.Map;
using DAL.DbSets;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;

namespace BLL
{
    public static class PlayerDetailsLogic
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets, SheetsService.Scope.DriveFile };
        static string ApplicationName = "Google Sheets API .NET Quickstart";

        public static List<GamePlayerDetails2> GetDetails()
        {
            List<GamePlayerDetails2> returnValue = new List<GamePlayerDetails2>();
            using (var context = new AppDbContext())
            {
                returnValue = context.GamePlayerDetails2.ToList();
            }
            return returnValue;
        }
        public static List<EnglishGamePlayerDetails> GetEnglishDetails()
        {
            List<EnglishGamePlayerDetails> returnValue = new List<EnglishGamePlayerDetails>();
            using (var context = new AppDbContext())
            {
                returnValue = context.EnglishGamePlayerDetails.ToList();
            }
            return returnValue;
        }
        public static void UploadHungarianGames()
        {
            try
            {
                UserCredential credential;

                using (var stream =
                    new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "nagy.karoly.92@gmail.com",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                string spreadsheetId = "1tDYEjIyjQFZQ_B2OL0KZpYt4SacUrL0VD2cdJv-okZg";
                string range = $"Sheet1!B:B"; // Ez az oszlop, amelyet ellenőrizni fogunk az utolsó sor megtalálásához

                var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;

                int lastRow = values != null ? values.Count + 1 : 1;

                var list = GetDetails();

                var newRange = $"Sheet1!A{lastRow}:BX{lastRow + list.Count}"; // Az új adatokat ide illesztjük be

                List<IList<object>> data = new List<IList<object>>();
                data.AddRange(ConvertToObjectList(list));
                
                var valueRange = new ValueRange();
                valueRange.Values = data;

                var appendRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, newRange);
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
                var appendResponse = appendRequest.Execute();
                SettingsLogic.SetLastRow();
                
            }
            catch (Exception ex)
            { }
        }
        public static void UploadEnglishGames()
        {
            try
            {
                UserCredential credential;

                using (var stream =
                    new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "nagy.karoly.92@gmail.com",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                string spreadsheetId = "1tDYEjIyjQFZQ_B2OL0KZpYt4SacUrL0VD2cdJv-okZg";
                string range = $"Sheet2!B:B"; // Ez az oszlop, amelyet ellenőrizni fogunk az utolsó sor megtalálásához

                var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;

                int lastRow = values != null ? values.Count + 1 : 1;

                var list = GetEnglishDetails();

                var newRange = $"Sheet2!A{lastRow}:BX{lastRow + list.Count}"; // Az új adatokat ide illesztjük be

                List<IList<object>> data = new List<IList<object>>();
                data.AddRange(ConvertToEnglishObjectList(list));

                var valueRange = new ValueRange();
                valueRange.Values = data;

                var appendRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, newRange);
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
                var appendResponse = appendRequest.Execute();
                SettingsLogic.SetEnglishLastRow();

            }
            catch (Exception ex)
            { }
        }

        public static List<List<object>> ConvertToObjectList(List<GamePlayerDetails2> details)
        {
            var result = new List<List<object>>();

            foreach (var detail in details)
            {
                var row = new List<object>
        {
            detail.TimeStamp,
            detail.RoomName,
            detail.GameStartTime,
            detail.TeamSize,
            detail.Email1,
            detail.Name1,
            detail.BirthDate1,
            detail.BirthYear1,
            detail.ZipCode1,
            detail.Email2,
            detail.Name2,
            detail.BirthDate2,
            detail.BirthYear2,
            detail.ZipCode2,
            detail.Email3,
            detail.Name3,
            detail.BirthDate3,
            detail.BirthYear3,
            detail.ZipCode3,
            detail.Email4,
            detail.Name4,
            detail.BirthDate4,
            detail.BirthYear4,
            detail.ZipCode4,
            detail.Email5,
            detail.Name5,
            detail.BirthDate5,
            detail.BirthYear5,
            detail.ZipCode5,
            detail.Email6,
            detail.Name6,
            detail.BirthDate6,
            detail.BirthYear6,
            detail.ZipCode6,
            detail.Email7,
            detail.Name7,
            detail.BirthDate7,
            detail.BirthYear7,
            detail.ZipCode7,
            detail.Email8,
            detail.Name8,
            detail.BirthDate8,
            detail.BirthYear8,
            detail.ZipCode8,
            detail.Consent1,
            detail.Consent2,
            detail.Consent3,
            detail.Consent4,
            detail.Consent5,
            detail.Consent6,
            detail.Consent7,
            detail.Consent8
        };

                result.Add(row);
            }

            return result;
        }

        public static List<List<object>> ConvertToEnglishObjectList(List<EnglishGamePlayerDetails> details)
        {
            var result = new List<List<object>>();

            foreach (var detail in details)
            {
                var row = new List<object>
        {
            detail.TimeStamp,
            detail.RoomName,
            detail.GameStartTime,
            detail.TeamSize,
            detail.Email1,
            detail.Name1,
            detail.BirthDate1,
            detail.BirthYear1,
            detail.ZipCode1,
            detail.Email2,
            detail.Name2,
            detail.BirthDate2,
            detail.BirthYear2,
            detail.ZipCode2,
            detail.Email3,
            detail.Name3,
            detail.BirthDate3,
            detail.BirthYear3,
            detail.ZipCode3,
            detail.Email4,
            detail.Name4,
            detail.BirthDate4,
            detail.BirthYear4,
            detail.ZipCode4,
            detail.Email5,
            detail.Name5,
            detail.BirthDate5,
            detail.BirthYear5,
            detail.ZipCode5,
            detail.Email6,
            detail.Name6,
            detail.BirthDate6,
            detail.BirthYear6,
            detail.ZipCode6,
            detail.Email7,
            detail.Name7,
            detail.BirthDate7,
            detail.BirthYear7,
            detail.ZipCode7,
            detail.Email8,
            detail.Name8,
            detail.BirthDate8,
            detail.BirthYear8,
            detail.ZipCode8,
            detail.Consent1,
            detail.Consent2,
            detail.Consent3,
            detail.Consent4,
            detail.Consent5,
            detail.Consent6,
            detail.Consent7,
            detail.Consent8
        };

                result.Add(row);
            }

            return result;
        }

        public static List<List<object>> GetDetailsAsObjectList()
        {
            List<GamePlayerDetails2> details = new List<GamePlayerDetails2>();
            using (var context = new AppDbContext())
            {
                details = context.GamePlayerDetails2.ToList();
            }

            return ConvertToObjectList(details);
        }
    }
}
