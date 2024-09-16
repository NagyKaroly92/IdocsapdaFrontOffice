using DAL.DbSets;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GoogleSheetContext : IDisposable
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets, SheetsService.Scope.DriveFile };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        /*
        public void Upload(string sheet, List<GamePlayerDetails2> dTOSeos)
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

                string spreadsheetId = "StaticSettings.SheetId";
                string range = $"{sheet}!C:C"; // Ez az oszlop, amelyet ellenőrizni fogunk az utolsó sor megtalálásához

                var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;

                int lastRow = values != null ? values.Count + 1 : 1;

                var newRange = $"{sheet}!C{lastRow}:H{lastRow + dTOSeos.Count}"; // Az új adatokat ide illesztjük be

                List<IList<object>> data = new List<IList<object>>();
                data.AddRange(PlayerDetailsLogic.GetDetails());
                
                foreach (var dto in dTOSeos)
                {
                    var objectList = new List<object> { dto.Email, dto.Name, dto.BirthDate, dto.BirthYear, dto.ZipCode, dto.Sex };
                    data.Add(objectList);
                }
                
                var valueRange = new ValueRange();
                //var objectList = new List<object>() { "NewData1", "NewData2" }; // Az új adatok
                valueRange.Values = data;//new List<IList<object>> { objectList };

                var appendRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, newRange);
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
                var appendResponse = appendRequest.Execute();
            }
            catch (Exception ex)
            { }
        }*/
        public void Dispose()
        { }
    }
}
